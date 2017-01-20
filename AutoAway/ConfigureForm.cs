using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAway
{
    public partial class ConfigureForm : Form
    {
        List<string> mcol_processes = new List<string>();
        public ConfigureForm()
        {
            InitializeComponent();
            trackBar1.Value = Properties.Settings.Default.AwayAfter;
            tbox_autoAwayMsg.Text = Properties.Settings.Default.AutoAwayMessage;
            tbox_awayMsg.Text = Properties.Settings.Default.AwayMessage;
            tbox_awayURL.Text = Properties.Settings.Default.HTTPPostURL;
            mcol_processes = Properties.Settings.Default.RunCmds.Split(';').ToList();
            cbox_httpPost.Checked = Properties.Settings.Default.activate_httppost;
            cbox_killProcesses.Checked = Properties.Settings.Default.active_runCmds;
            UpdateRunCmdsListbox();
        }
        private void UpdateRunCmdsListbox()
        {
            lbox_runCmds.Items.Clear();
            foreach (string process in mcol_processes)
            {
                lbox_runCmds.Items.Add(process);
            }
            Properties.Settings.Default.RunCmds = String.Join(";", mcol_processes.ToArray());
            Properties.Settings.Default.Save();
        }
        private void SetSliderChanged(int rawValue)
        {
            double factor = 1;
            string unit = "";
            if (rawValue < 60 * 2)
            {
                factor = 1;
                unit = "second(s)";
            }
            if (rawValue >= 60 * 2)
            {
                factor = 1.0 / 60;
                unit = "minute(s)";
            }
            if (rawValue >= 60 * 60)
            {
                factor = 1.0 / 3600;
                unit = "hour(s)";
            }
            double value = rawValue * factor;

            lbl_awaySeconds.Text = String.Format("{0:#,###.##} {1}", value, unit);
        }
        #region Event handlers
        public void SliderChanged(object sender, EventArgs e)
        {
            int rawValue = ((TrackBar)sender).Value;
            Properties.Settings.Default.AwayAfter = rawValue;
            Properties.Settings.Default.Save();
            SetSliderChanged(rawValue);
        }
        private void btn_remove_Click(object sender, EventArgs e)
        {
            int index = lbox_runCmds.SelectedIndex;
            if (index >= 0)
            {
                mcol_processes.RemoveAt(index);
                UpdateRunCmdsListbox();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (tbox_process.Text.Contains(";")) return;
            mcol_processes.Add(tbox_process.Text);
            UpdateRunCmdsListbox();
            Properties.Settings.Default.RunCmds = String.Join(";", mcol_processes.ToArray());
            Properties.Settings.Default.Save();
        }

        private void cbox_httpPost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.activate_httppost = cbox_httpPost.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbox_killProcesses_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.active_runCmds = cbox_killProcesses.Checked;
            Properties.Settings.Default.Save();
        }

        private void tbox_awayURL_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HTTPPostURL = tbox_awayURL.Text;
            Properties.Settings.Default.Save();
        }
        private void tbox_autoAwayMsg_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoAwayMessage = tbox_autoAwayMsg.Text;
            Properties.Settings.Default.Save();
        }

        private void tbox_awayMsg_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AwayMessage = tbox_awayMsg.Text;
            Properties.Settings.Default.Save();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here you can insert commands that can be\r\nrun from the command line. Examples:\r\ncmd /c start notepad.exe\r\ncmd /c taskkill /F /IM notepad.exe", "Commands to run:", MessageBoxButtons.OK);
        }
        #endregion
    }
}
