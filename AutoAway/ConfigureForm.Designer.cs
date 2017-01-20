namespace AutoAway
{
    partial class ConfigureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbox_killProcesses = new System.Windows.Forms.CheckBox();
            this.cbox_httpPost = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_awayMsg = new System.Windows.Forms.TextBox();
            this.lbl_awayMsg = new System.Windows.Forms.Label();
            this.tbox_autoAwayMsg = new System.Windows.Forms.TextBox();
            this.lbl_awayURL = new System.Windows.Forms.Label();
            this.tbox_awayURL = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.tbox_process = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbox_runCmds = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_awaySeconds = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_killProcesses);
            this.groupBox1.Controls.Add(this.cbox_httpPost);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Active services";
            // 
            // cbox_killProcesses
            // 
            this.cbox_killProcesses.AutoSize = true;
            this.cbox_killProcesses.Location = new System.Drawing.Point(7, 44);
            this.cbox_killProcesses.Name = "cbox_killProcesses";
            this.cbox_killProcesses.Size = new System.Drawing.Size(74, 17);
            this.cbox_killProcesses.TabIndex = 1;
            this.cbox_killProcesses.Text = "Run cmds";
            this.cbox_killProcesses.UseVisualStyleBackColor = true;
            this.cbox_killProcesses.CheckedChanged += new System.EventHandler(this.cbox_killProcesses_CheckedChanged);
            // 
            // cbox_httpPost
            // 
            this.cbox_httpPost.AutoSize = true;
            this.cbox_httpPost.Location = new System.Drawing.Point(7, 20);
            this.cbox_httpPost.Name = "cbox_httpPost";
            this.cbox_httpPost.Size = new System.Drawing.Size(87, 17);
            this.cbox_httpPost.TabIndex = 0;
            this.cbox_httpPost.Text = "HTTP POST";
            this.cbox_httpPost.UseVisualStyleBackColor = true;
            this.cbox_httpPost.CheckedChanged += new System.EventHandler(this.cbox_httpPost_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbox_awayMsg);
            this.groupBox2.Controls.Add(this.lbl_awayMsg);
            this.groupBox2.Controls.Add(this.tbox_autoAwayMsg);
            this.groupBox2.Controls.Add(this.lbl_awayURL);
            this.groupBox2.Controls.Add(this.tbox_awayURL);
            this.groupBox2.Location = new System.Drawing.Point(118, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HTTP post to send with away message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Manual away text";
            // 
            // tbox_awayMsg
            // 
            this.tbox_awayMsg.Location = new System.Drawing.Point(106, 68);
            this.tbox_awayMsg.Name = "tbox_awayMsg";
            this.tbox_awayMsg.Size = new System.Drawing.Size(253, 20);
            this.tbox_awayMsg.TabIndex = 4;
            this.tbox_awayMsg.TextChanged += new System.EventHandler(this.tbox_awayMsg_TextChanged);
            // 
            // lbl_awayMsg
            // 
            this.lbl_awayMsg.AutoSize = true;
            this.lbl_awayMsg.Location = new System.Drawing.Point(10, 48);
            this.lbl_awayMsg.Name = "lbl_awayMsg";
            this.lbl_awayMsg.Size = new System.Drawing.Size(74, 13);
            this.lbl_awayMsg.TabIndex = 3;
            this.lbl_awayMsg.Text = "Autoaway text";
            // 
            // tbox_autoAwayMsg
            // 
            this.tbox_autoAwayMsg.Location = new System.Drawing.Point(106, 44);
            this.tbox_autoAwayMsg.Name = "tbox_autoAwayMsg";
            this.tbox_autoAwayMsg.Size = new System.Drawing.Size(253, 20);
            this.tbox_autoAwayMsg.TabIndex = 2;
            this.tbox_autoAwayMsg.TextChanged += new System.EventHandler(this.tbox_autoAwayMsg_TextChanged);
            // 
            // lbl_awayURL
            // 
            this.lbl_awayURL.AutoSize = true;
            this.lbl_awayURL.Location = new System.Drawing.Point(10, 24);
            this.lbl_awayURL.Name = "lbl_awayURL";
            this.lbl_awayURL.Size = new System.Drawing.Size(29, 13);
            this.lbl_awayURL.TabIndex = 1;
            this.lbl_awayURL.Text = "URL";
            // 
            // tbox_awayURL
            // 
            this.tbox_awayURL.Location = new System.Drawing.Point(45, 20);
            this.tbox_awayURL.Name = "tbox_awayURL";
            this.tbox_awayURL.Size = new System.Drawing.Size(314, 20);
            this.tbox_awayURL.TabIndex = 0;
            this.tbox_awayURL.TextChanged += new System.EventHandler(this.tbox_awayURL_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnHelp);
            this.groupBox3.Controls.Add(this.btn_remove);
            this.groupBox3.Controls.Add(this.btn_add);
            this.groupBox3.Controls.Add(this.tbox_process);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lbox_runCmds);
            this.groupBox3.Location = new System.Drawing.Point(12, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 131);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commands to run";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(325, 105);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(19, 20);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(406, 105);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(58, 20);
            this.btn_remove.TabIndex = 5;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(346, 105);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(58, 20);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tbox_process
            // 
            this.tbox_process.Location = new System.Drawing.Point(71, 105);
            this.tbox_process.Name = "tbox_process";
            this.tbox_process.Size = new System.Drawing.Size(244, 20);
            this.tbox_process.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Command";
            // 
            // lbox_runCmds
            // 
            this.lbox_runCmds.FormattingEnabled = true;
            this.lbox_runCmds.Location = new System.Drawing.Point(7, 19);
            this.lbox_runCmds.Name = "lbox_runCmds";
            this.lbox_runCmds.Size = new System.Drawing.Size(457, 82);
            this.lbox_runCmds.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_awaySeconds);
            this.groupBox4.Controls.Add(this.trackBar1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(118, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(365, 71);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Set away timer";
            // 
            // lbl_awaySeconds
            // 
            this.lbl_awaySeconds.AutoSize = true;
            this.lbl_awaySeconds.Location = new System.Drawing.Point(9, 29);
            this.lbl_awaySeconds.Name = "lbl_awaySeconds";
            this.lbl_awaySeconds.Size = new System.Drawing.Size(56, 13);
            this.lbl_awaySeconds.TabIndex = 2;
            this.lbl_awaySeconds.Text = "5 seconds";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(94, 20);
            this.trackBar1.Maximum = 7200;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(264, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 5;
            this.trackBar1.ValueChanged += new System.EventHandler(this.SliderChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Set away after";
            // 
            // ConfigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 329);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigureForm";
            this.Text = "Configure";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbox_killProcesses;
        private System.Windows.Forms.CheckBox cbox_httpPost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_awayMsg;
        private System.Windows.Forms.TextBox tbox_autoAwayMsg;
        private System.Windows.Forms.Label lbl_awayURL;
        private System.Windows.Forms.TextBox tbox_awayURL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_awaySeconds;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox tbox_process;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbox_runCmds;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_awayMsg;
    }
}