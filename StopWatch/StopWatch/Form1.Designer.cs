namespace StopWatch
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
            this.thread = new System.Windows.Forms.Label();
            this.stopwatch = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Label();
            this.btnLap = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.colThread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStopwatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // thread
            // 
            this.thread.AutoSize = true;
            this.thread.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.thread.Location = new System.Drawing.Point(33, 34);
            this.thread.Name = "thread";
            this.thread.Size = new System.Drawing.Size(54, 16);
            this.thread.TabIndex = 0;
            this.thread.Text = "label1";
            // 
            // stopwatch
            // 
            this.stopwatch.AutoSize = true;
            this.stopwatch.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stopwatch.Location = new System.Drawing.Point(257, 34);
            this.stopwatch.Name = "stopwatch";
            this.stopwatch.Size = new System.Drawing.Size(54, 16);
            this.stopwatch.TabIndex = 1;
            this.stopwatch.Text = "label2";
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.timer.Location = new System.Drawing.Point(499, 34);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(54, 16);
            this.timer.TabIndex = 2;
            this.timer.Text = "label3";
            // 
            // btnLap
            // 
            this.btnLap.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLap.Location = new System.Drawing.Point(181, 99);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(104, 36);
            this.btnLap.TabIndex = 3;
            this.btnLap.Text = "랩";
            this.btnLap.UseVisualStyleBackColor = true;
            this.btnLap.Click += new System.EventHandler(this.btnLap_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.Location = new System.Drawing.Point(427, 99);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 36);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgvRecords
            // 
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThread,
            this.colStopwatch,
            this.colTimer});
            this.dgvRecords.Location = new System.Drawing.Point(36, 170);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.RowTemplate.Height = 23;
            this.dgvRecords.Size = new System.Drawing.Size(641, 240);
            this.dgvRecords.TabIndex = 5;
            // 
            // colThread
            // 
            this.colThread.HeaderText = "쓰레드";
            this.colThread.Name = "colThread";
            // 
            // colStopwatch
            // 
            this.colStopwatch.HeaderText = "스톱워치";
            this.colStopwatch.Name = "colStopwatch";
            // 
            // colTimer
            // 
            this.colTimer.HeaderText = "타이머";
            this.colTimer.Name = "colTimer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 437);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnLap);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.stopwatch);
            this.Controls.Add(this.thread);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label thread;
        private System.Windows.Forms.Label stopwatch;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThread;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStopwatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimer;
    }
}

