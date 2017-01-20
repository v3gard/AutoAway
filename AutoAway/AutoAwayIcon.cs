using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Http;
using System.Diagnostics;
using NLog;

namespace AutoAway
{
    public class AutoAwayIcon : IDisposable
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private NotifyIcon ni;
        private IKeyboardMouseEvents m_GlobalHook;
        private Watchdog m_watchdog;
        private bool m_manualAway;
        private MenuItem m_mi_away;

        public AutoAwayIcon()
        {
            m_manualAway = false;
            ni = new NotifyIcon();
            ContextMenu cm = new ContextMenu();
            MenuItem mi_configure = new MenuItem("&Configure");
            MenuItem mi_about = new MenuItem("About");
            m_mi_away = new MenuItem("Set away");
            MenuItem mi_exit = new MenuItem("E&xit");
            cm.MenuItems.Add(m_mi_away);
            cm.MenuItems.Add(mi_configure);
            cm.MenuItems.Add(mi_about);
            cm.MenuItems.Add(mi_exit);
            
            mi_configure.Click += new EventHandler(ConfigureClickedEvent);
            mi_exit.Click += new EventHandler(ExitClickedEvent);
            m_mi_away.Click += new EventHandler(AwayClickedEvent);
            mi_about.Click += new EventHandler(AboutClickedEvent);

            ni.ContextMenu = cm;
            ni.Icon = Properties.Resources.awake;

            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseDownExt += MouseClickedEvent;
            m_GlobalHook.MouseMove += MouseMovementEvent;
            m_GlobalHook.KeyPress += KeyboardPressedEvent;

            m_watchdog = new Watchdog(Properties.Settings.Default.AwayAfter, TimeoutEvent, SetBack);
            Thread t_watchdog = new Thread(new ThreadStart(m_watchdog.Run));
            t_watchdog.Start();
            logger.Info("Watchdog initialized. Logging keystrokes and mouse movement...");
        }
        public void Display()
        {
            ni.Visible = true;
        }
        #region Event Handlers
        private void MouseMovementEvent(object sender, MouseEventArgs e)
        {
            if (!m_manualAway)
            {
                m_watchdog.Update();
            }
        }
        private void MouseClickedEvent(object sender, MouseEventExtArgs e)
        {
            if (!m_manualAway)
            {
                m_watchdog.Update();
            }
        }
        /// <summary>
        /// Records all keypresses. Yes, I know. Tempting to store :)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardPressedEvent(object sender, KeyPressEventArgs e)
        {
            if (!m_manualAway)
            {
                m_watchdog.Update();
            }
        }
        private void ConfigureClickedEvent(object sender, EventArgs e)
        {
            ConfigureForm cf = new ConfigureForm();
            cf.ShowDialog();
        }
        private void AwayClickedEvent(object sender, EventArgs e)
        {
            if (m_manualAway)
            {
                // we are back
                m_manualAway = false;
                m_mi_away.Text = "Set away";
                SetBack();
            }
            else
            {
                // we are away
                m_manualAway = true; ;
                m_mi_away.Text = "Set back";
                SetAway();
            }
        }
        private void AboutClickedEvent(object sender, EventArgs e)
        {
            About af = new About();
            af.ShowDialog();
        }
        private void ExitClickedEvent(object sender, EventArgs e)
        {
            this.Dispose();
            m_watchdog.Stop();
            Application.Exit();
        }
        #endregion

        private async void SendMsg(Dictionary<string, string> keyval)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(keyval);
                    var response = await client.PostAsync(Properties.Settings.Default.HTTPPostURL, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }
        }
        private void SetAway()
        {
            string message;
            ni.Icon = Properties.Resources.asleep;
            if (m_manualAway)
            {
                // Manual away
                logger.Info("Setting status to away manually");
                message = Properties.Settings.Default.AwayMessage;
            }
            else
            {
                // Autoaway
                message = Properties.Settings.Default.AutoAwayMessage;
            }
            if (Properties.Settings.Default.activate_httppost)
            {
                // TODO: Hacked together. Should add a key/value store somewhere to make this configurable
                Dictionary<string, string> keyval = new Dictionary<string, string>();
                keyval["Melding"] = message;
                keyval["svar"] = "1";
                keyval["submit"] = "Lagre";
                SendMsg(keyval);
            }
            if (Properties.Settings.Default.active_runCmds)
            {
                try
                {
                    string[] cmds = Properties.Settings.Default.RunCmds.Split(';');
                    foreach (var cmd in cmds)
                    {
                        Process p = new Process();
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.FileName = cmd.Split(' ')[0];
                        p.StartInfo.Arguments = String.Join(" ", cmd.Split(' ').Skip(1).ToArray());
                        p.Start();
                        p.WaitForExit(3000);
                    }
                }
                catch (Exception e)
                {
                    logger.Warn(e, "Unable to execute command. ");
                }
            }
        }
        #region Callback functions for Watchdog class
        private int SetBack()
        {
            logger.Info("Woke up from manual away status.");
            ni.Icon = Properties.Resources.awake;
            if (Properties.Settings.Default.activate_httppost)
            {
                // TODO: Hacked together. Should add a key/value store somewhere to make this configurable
                Dictionary<string, string> keyval = new Dictionary<string, string>();
                keyval["fjernmelding"] = "Fjern melding";
                keyval["svar"] = "2";
                SendMsg(keyval);
            }
            return 0;
        }
        public int TimeoutEvent()
        {
            if (m_manualAway == false)
            {
                SetAway();
                return 0;
            }
            return -1;
        }
        #endregion
        public void Dispose()
        {
            m_GlobalHook.MouseDownExt -= MouseClickedEvent;
            m_GlobalHook.KeyPress -= KeyboardPressedEvent;
            m_GlobalHook.Dispose();
            ni.Visible = false;
            ni.Dispose();
        }
    }
    public class Watchdog
    {
        DateTime m_lastEventTime;
        bool m_stop, m_notified;
        private int m_timeoutSeconds;
        Func<int> m_alertcallback;
        Func<int> m_backcallback;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Watchdog(int timeoutSeconds, Func<int> alertcallback, Func<int> backcallback)
        {
            m_timeoutSeconds = timeoutSeconds;
            m_lastEventTime = DateTime.Now;
            m_stop = false;
            m_alertcallback = alertcallback;
            m_backcallback = backcallback;
            m_notified = false;
        }
        public void UpdateSettings(int timeoutSeconds)
        {
            m_timeoutSeconds = timeoutSeconds;
        }
        public void Update()
        {
            if (m_notified == true)
            {
                logger.Info("Woke up from autoaway status.");
                m_notified = false;
                m_backcallback();
            }
            m_timeoutSeconds = Properties.Settings.Default.AwayAfter;
            m_lastEventTime = DateTime.Now;
        }
        public void Stop()
        {
            m_stop = true;
        }
        public void Run()
        {
            while (m_stop == false)
            {
                if ((DateTime.Now-m_lastEventTime).Seconds > m_timeoutSeconds && !m_notified)
                {
                    logger.Info("Setting status to autoaway.");
                    m_alertcallback();
                    m_notified = true;
                }
                Thread.Sleep(1000);
            }
        }
    }
}
