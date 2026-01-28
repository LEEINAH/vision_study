namespace RobotSignal
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
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSend = new System.Windows.Forms.GroupBox();
            this.btnManualMode = new System.Windows.Forms.Button();
            this.tbED = new System.Windows.Forms.TextBox();
            this.tbTR = new System.Windows.Forms.TextBox();
            this.tbMD1 = new System.Windows.Forms.TextBox();
            this.tbST1 = new System.Windows.Forms.TextBox();
            this.btnSendED = new System.Windows.Forms.Button();
            this.btnSendTR = new System.Windows.Forms.Button();
            this.btnSendMD = new System.Windows.Forms.Button();
            this.btnSendST = new System.Windows.Forms.Button();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnAutoMode = new System.Windows.Forms.Button();
            this.gbConfig.SuspendLayout();
            this.gbSend.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.btnConnect);
            this.gbConfig.Controls.Add(this.comboBox1);
            this.gbConfig.Controls.Add(this.label1);
            this.gbConfig.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConfig.Location = new System.Drawing.Point(13, 13);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(200, 110);
            this.gbConfig.TabIndex = 0;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Config";
            // 
            // btnConnect
            // 
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConnect.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(58, 69);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 30);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 25);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comport";
            // 
            // gbSend
            // 
            this.gbSend.Controls.Add(this.btnAutoMode);
            this.gbSend.Controls.Add(this.btnManualMode);
            this.gbSend.Controls.Add(this.tbED);
            this.gbSend.Controls.Add(this.tbTR);
            this.gbSend.Controls.Add(this.tbMD1);
            this.gbSend.Controls.Add(this.tbST1);
            this.gbSend.Controls.Add(this.btnSendED);
            this.gbSend.Controls.Add(this.btnSendTR);
            this.gbSend.Controls.Add(this.btnSendMD);
            this.gbSend.Controls.Add(this.btnSendST);
            this.gbSend.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSend.Location = new System.Drawing.Point(13, 138);
            this.gbSend.Name = "gbSend";
            this.gbSend.Size = new System.Drawing.Size(200, 367);
            this.gbSend.TabIndex = 1;
            this.gbSend.TabStop = false;
            this.gbSend.Text = "Send Data";
            // 
            // btnManualMode
            // 
            this.btnManualMode.Location = new System.Drawing.Point(11, 83);
            this.btnManualMode.Name = "btnManualMode";
            this.btnManualMode.Size = new System.Drawing.Size(176, 34);
            this.btnManualMode.TabIndex = 9;
            this.btnManualMode.Text = "Manual Mode";
            this.btnManualMode.UseVisualStyleBackColor = true;
            this.btnManualMode.Click += new System.EventHandler(this.btnManualMode_Click);
            // 
            // tbED
            // 
            this.tbED.Location = new System.Drawing.Point(11, 311);
            this.tbED.Name = "tbED";
            this.tbED.Size = new System.Drawing.Size(100, 25);
            this.tbED.TabIndex = 8;
            this.tbED.Text = "ED";
            // 
            // tbTR
            // 
            this.tbTR.Location = new System.Drawing.Point(11, 253);
            this.tbTR.Name = "tbTR";
            this.tbTR.Size = new System.Drawing.Size(100, 25);
            this.tbTR.TabIndex = 7;
            this.tbTR.Text = "TR";
            // 
            // tbMD1
            // 
            this.tbMD1.Location = new System.Drawing.Point(11, 196);
            this.tbMD1.Name = "tbMD1";
            this.tbMD1.Size = new System.Drawing.Size(100, 25);
            this.tbMD1.TabIndex = 6;
            this.tbMD1.Text = "MD1";
            // 
            // tbST1
            // 
            this.tbST1.Location = new System.Drawing.Point(11, 138);
            this.tbST1.Name = "tbST1";
            this.tbST1.Size = new System.Drawing.Size(100, 25);
            this.tbST1.TabIndex = 5;
            this.tbST1.Text = "ST1";
            // 
            // btnSendED
            // 
            this.btnSendED.Enabled = false;
            this.btnSendED.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSendED.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendED.Location = new System.Drawing.Point(121, 308);
            this.btnSendED.Name = "btnSendED";
            this.btnSendED.Size = new System.Drawing.Size(66, 30);
            this.btnSendED.TabIndex = 4;
            this.btnSendED.Text = "Send";
            this.btnSendED.UseVisualStyleBackColor = true;
            this.btnSendED.Click += new System.EventHandler(this.btnSendED_Click);
            // 
            // btnSendTR
            // 
            this.btnSendTR.Enabled = false;
            this.btnSendTR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSendTR.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendTR.Location = new System.Drawing.Point(121, 250);
            this.btnSendTR.Name = "btnSendTR";
            this.btnSendTR.Size = new System.Drawing.Size(66, 30);
            this.btnSendTR.TabIndex = 3;
            this.btnSendTR.Text = "Send";
            this.btnSendTR.UseVisualStyleBackColor = true;
            this.btnSendTR.Click += new System.EventHandler(this.btnSendTR_Click);
            // 
            // btnSendMD
            // 
            this.btnSendMD.Enabled = false;
            this.btnSendMD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSendMD.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMD.Location = new System.Drawing.Point(121, 193);
            this.btnSendMD.Name = "btnSendMD";
            this.btnSendMD.Size = new System.Drawing.Size(66, 30);
            this.btnSendMD.TabIndex = 2;
            this.btnSendMD.Text = "Send";
            this.btnSendMD.UseVisualStyleBackColor = true;
            this.btnSendMD.Click += new System.EventHandler(this.btnSendMD_Click);
            // 
            // btnSendST
            // 
            this.btnSendST.Enabled = false;
            this.btnSendST.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSendST.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendST.Location = new System.Drawing.Point(121, 136);
            this.btnSendST.Name = "btnSendST";
            this.btnSendST.Size = new System.Drawing.Size(66, 30);
            this.btnSendST.TabIndex = 1;
            this.btnSendST.Text = "Send";
            this.btnSendST.UseVisualStyleBackColor = true;
            this.btnSendST.Click += new System.EventHandler(this.btnSendST_Click);
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.lbLog);
            this.gbLog.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLog.Location = new System.Drawing.Point(238, 13);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(437, 492);
            this.gbLog.TabIndex = 2;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Log";
            // 
            // lbLog
            // 
            this.lbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 17;
            this.lbLog.Location = new System.Drawing.Point(16, 37);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(405, 427);
            this.lbLog.TabIndex = 0;
            // 
            // btnAutoMode
            // 
            this.btnAutoMode.Location = new System.Drawing.Point(11, 36);
            this.btnAutoMode.Name = "btnAutoMode";
            this.btnAutoMode.Size = new System.Drawing.Size(176, 34);
            this.btnAutoMode.TabIndex = 10;
            this.btnAutoMode.Text = "Auto Mode";
            this.btnAutoMode.UseVisualStyleBackColor = true;
            this.btnAutoMode.Click += new System.EventHandler(this.btnAutoMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(689, 534);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbSend);
            this.Controls.Add(this.gbConfig);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.gbSend.ResumeLayout(false);
            this.gbSend.PerformLayout();
            this.gbLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.GroupBox gbSend;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btnConnect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox tbMD1;
        private System.Windows.Forms.TextBox tbST1;
        private System.Windows.Forms.Button btnSendED;
        private System.Windows.Forms.Button btnSendTR;
        private System.Windows.Forms.Button btnSendMD;
        private System.Windows.Forms.Button btnSendST;
        private System.Windows.Forms.TextBox tbED;
        private System.Windows.Forms.TextBox tbTR;
        private System.Windows.Forms.Button btnManualMode;
        private System.Windows.Forms.Button btnAutoMode;
    }
}

