namespace Watchdog
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbLog = new System.Windows.Forms.ListBox();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveInterval = new System.Windows.Forms.Button();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnOn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.niWatchdog = new System.Windows.Forms.NotifyIcon(this.components);
            this.gbConfig.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLog
            // 
            this.lbLog.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 16;
            this.lbLog.Location = new System.Drawing.Point(480, 38);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(512, 308);
            this.lbLog.TabIndex = 0;
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.label1);
            this.gbConfig.Controls.Add(this.btnSaveInterval);
            this.gbConfig.Controls.Add(this.cbPath);
            this.gbConfig.Controls.Add(this.label4);
            this.gbConfig.Controls.Add(this.btnFindPath);
            this.gbConfig.Controls.Add(this.tbInterval);
            this.gbConfig.Controls.Add(this.label2);
            this.gbConfig.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConfig.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbConfig.Location = new System.Drawing.Point(24, 171);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(430, 175);
            this.gbConfig.TabIndex = 1;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Config";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "(ms)";
            // 
            // btnSaveInterval
            // 
            this.btnSaveInterval.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveInterval.FlatAppearance.BorderSize = 0;
            this.btnSaveInterval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSaveInterval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveInterval.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaveInterval.Location = new System.Drawing.Point(169, 119);
            this.btnSaveInterval.Name = "btnSaveInterval";
            this.btnSaveInterval.Size = new System.Drawing.Size(70, 25);
            this.btnSaveInterval.TabIndex = 9;
            this.btnSaveInterval.Text = "Save";
            this.btnSaveInterval.UseVisualStyleBackColor = false;
            this.btnSaveInterval.Click += new System.EventHandler(this.btnSaveInterval_Click);
            // 
            // cbPath
            // 
            this.cbPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPath.FormattingEnabled = true;
            this.cbPath.Location = new System.Drawing.Point(20, 62);
            this.cbPath.Margin = new System.Windows.Forms.Padding(0);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(350, 25);
            this.cbPath.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Path";
            // 
            // btnFindPath
            // 
            this.btnFindPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFindPath.FlatAppearance.BorderSize = 0;
            this.btnFindPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnFindPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPath.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFindPath.Location = new System.Drawing.Point(376, 62);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(35, 25);
            this.btnFindPath.TabIndex = 5;
            this.btnFindPath.Text = "...";
            this.btnFindPath.UseVisualStyleBackColor = false;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // tbInterval
            // 
            this.tbInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInterval.Location = new System.Drawing.Point(20, 119);
            this.tbInterval.Margin = new System.Windows.Forms.Padding(0);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(100, 25);
            this.tbInterval.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Check Interval";
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.pbStatus);
            this.gbStatus.Controls.Add(this.btnOff);
            this.gbStatus.Controls.Add(this.btnOn);
            this.gbStatus.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbStatus.Location = new System.Drawing.Point(24, 19);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(220, 134);
            this.gbStatus.TabIndex = 2;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Monitoring Status";
            // 
            // pbStatus
            // 
            this.pbStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.pbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(222)))), ((int)(((byte)(133)))));
            this.pbStatus.Location = new System.Drawing.Point(20, 89);
            this.pbStatus.Margin = new System.Windows.Forms.Padding(0);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(176, 23);
            this.pbStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbStatus.TabIndex = 2;
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOff.FlatAppearance.BorderSize = 0;
            this.btnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOff.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOff.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOff.Location = new System.Drawing.Point(121, 34);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(75, 35);
            this.btnOff.TabIndex = 1;
            this.btnOff.TabStop = false;
            this.btnOff.Text = "OFF";
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            this.btnOff.MouseEnter += new System.EventHandler(this.btnOff_MouseEnter);
            this.btnOff.MouseLeave += new System.EventHandler(this.btnOff_MouseLeave);
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOn.FlatAppearance.BorderSize = 0;
            this.btnOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOn.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOn.Location = new System.Drawing.Point(20, 34);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(75, 35);
            this.btnOn.TabIndex = 0;
            this.btnOn.TabStop = false;
            this.btnOn.Text = "ON";
            this.btnOn.UseVisualStyleBackColor = false;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            this.btnOn.MouseEnter += new System.EventHandler(this.btnOn_MouseEnter);
            this.btnOn.MouseLeave += new System.EventHandler(this.btnOn_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(477, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Log";
            // 
            // niWatchdog
            // 
            this.niWatchdog.Icon = ((System.Drawing.Icon)(resources.GetObject("niWatchdog.Icon")));
            this.niWatchdog.Text = "Watchdog Running";
            this.niWatchdog.Visible = true;
            this.niWatchdog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niWatchdog_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1023, 377);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.gbConfig);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPath;
        private System.Windows.Forms.Button btnSaveInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.NotifyIcon niWatchdog;
    }
}

