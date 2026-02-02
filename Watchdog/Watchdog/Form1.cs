using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Watchdog
{
    public partial class Form1 : Form
    {
        string targetApp;
        int checkInterval;
        bool isMonitoring = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(1, 1, pbStatus.Width - 2, pbStatus.Height - 2);
            pbStatus.Region = new Region(rect);

            string defaultPath = @"E:\Vision PG\DW_Sealer_Single\DW_Sealer_Single C 20260128 A\DW_Sealer_Single\bin\x64\Release\DW_Sealer_Single.exe";

            if (File.Exists(defaultPath))
            {
                SetTargetApp(defaultPath);
                return;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 사용자가 Off 버튼을 누르지 않았고, 감시 중이라면 종료 대신 숨기기
            if (isMonitoring && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; 
                this.Hide();     
            }
            else
            {
                isMonitoring = false;
                niWatchdog.Visible = false;
                niWatchdog.Dispose();
                Environment.Exit(0);
            }
        }

        private void niWatchdog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show(); // 폼 다시 보이기
            this.WindowState = FormWindowState.Normal; // 최소화 되어있다면 원래대로
            this.Activate(); // 창 활성화
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {      
            // 파일 탐색기 객체 생성
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 초기 설정
                openFileDialog.InitialDirectory = "E:\\"; // 처음 열릴 폴더 위치
                openFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*"; // 실행 파일만 보이게 필터링
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SetTargetApp(openFileDialog.FileName);
                }
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            if (isMonitoring) return; // 이미 감시 중이면 중복 실행 방지

            // 경로 확인
            if (cbPath.Text.Length == 0)
            {
                MessageBox.Show("경로를 선택해주세요.");
                cbPath.Focus();
                return;
            }

            // 감시 주기 확인
            if (tbInterval.Text.Length == 0)
            {
                MessageBox.Show("감시 주기를 입력해주세요.");
                tbInterval.Focus();
                return;
            }
            else
            {
                // 입력값 확인
                if (!int.TryParse(tbInterval.Text, out int result))
                {
                    MessageBox.Show("숫자만 입력해 주세요.");
                    tbInterval.Focus();
                    return;
                }
                this.checkInterval = result;
            }

            isMonitoring = true;

            // 버튼 색 변경
            btnOn.BackColor = Color.LightGreen;
            btnOn.FlatAppearance.BorderColor = Color.LightGreen;
            btnOff.BackColor = Color.WhiteSmoke;
            btnOff.FlatAppearance.BorderColor = Color.WhiteSmoke;

            // 프로그레스 바
            pbStatus.Maximum = 100;
            pbStatus.Value = 0;
            pbStatus.ForeColor = Color.FromArgb(98, 222, 133);

            Task.Run(() =>
            {             
                while (isMonitoring)
                {
                    Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(targetApp));
                    if (processes.Length == 0)
                    {
                        try
                        {
                            // 감시 시작
                            Process.Start(targetApp);

                            // 로그 찍기
                            WriteLog("▶  프로그램이 재시작 되었습니다.");
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }

                    int elapsed = 0;
                    int step = 100; // 업데이트 간격 (0.1초마다 게이지 갱신)

                    while (elapsed < this.checkInterval && isMonitoring)
                    {
                        Thread.Sleep(step);
                        elapsed += step;
                        
                        int percent = (int)((double)elapsed / this.checkInterval * 100);

                        // 100을 넘지 않게 방어 코드
                        if (percent > 100) percent = 100;

                        this.Invoke(new MethodInvoker(delegate {
                            if (!this.IsDisposed) pbStatus.Value = percent;
                        }));
                    }
                    Thread.Sleep(200);
                }
            });            
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            if (!isMonitoring)
            {
                MessageBox.Show("감시 중이 아닙니다.");
                return;
            }

            isMonitoring = false;
            pbStatus.Value = 0; // 게이지 초기화

            // 색 변경
            btnOff.BackColor = Color.LightCoral;
            btnOff.FlatAppearance.BorderColor = Color.LightCoral;
            btnOn.BackColor = Color.WhiteSmoke;
            btnOn.FlatAppearance.BorderColor = Color.WhiteSmoke;
            pbStatus.ForeColor = Color.Gainsboro;

            // 로그 찍기
            WriteLog("▶  프로그램 감시가 중지 되었습니다.");
        }

        // 파일 경로 등록
        private void SetTargetApp(string filePath)
        {
            cbPath.Text = filePath;
            this.targetApp = filePath;

            // 화면엔 파일명만, 파일엔 전체 경로 저장
            WriteLog($"▶ 경로가 설정되었습니다. [{Path.GetFileName(filePath)}]", filePath);
        }

        // 감시 주기 변경
        private void btnSaveInterval_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbInterval.Text, out int result))
            {
                this.checkInterval = result;

                // 로그 찍기
                WriteLog($"▶  감시 주기가 {result}ms 로 설정되었습니다.");
            }
            else
            {
                MessageBox.Show("숫자만 입력해 주세요.");
                tbInterval.Focus();
                return;
            }
        }

        // 로그 작성
        private void WriteLog(string message, string detail = "")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => WriteLog(message)));
                return;
            }

            lbLog.Items.Add($"{DateTime.Now:yyyy-MM-dd HH : mm : ss} : {message}");

            string fileLog = string.IsNullOrEmpty(detail) ? message : $"{message} ({detail})";
            SaveLogToFile(fileLog);

            if (lbLog.Items.Count > 0)
            {
                lbLog.SelectedIndex = lbLog.Items.Count - 1;
                lbLog.TopIndex = lbLog.Items.Count - 1;
            }
        }

        // 로그 저장
        private void SaveLogToFile(string message)
        {
            try
            {
                // 로그 파일 경로 설정
                string folderPath = Path.Combine(Application.StartupPath, "Logs");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath); // 폴더가 없으면 생성
                }

                // 파일명 설정
                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                string filePath = Path.Combine(folderPath, fileName);

                // 로그 내용 구성 (시간 : 메시지)
                string logContent = $"{DateTime.Now:yyyy-MM-dd HH : mm : ss} : {message}{Environment.NewLine}";

                // 파일에 이어쓰기
                File.AppendAllText(filePath, logContent);
            }
            catch (Exception ex)
            {
                // 파일 쓰기 실패 시 콘솔에만 출력
                Console.WriteLine("로그 저장 실패: " + ex.Message);
            }
        }        

        //---------- 버튼 디자인 ---------- 
        private void btnOn_MouseEnter(object sender, EventArgs e)
        {
            if (btnOn.BackColor == Color.WhiteSmoke)
                btnOn.BackColor = Color.LightGray;
            else
            {
                btnOn.BackColor = btnOn.BackColor;
                btnOn.FlatAppearance.BorderColor = btnOn.BackColor;
            }                
        }

        private void btnOn_MouseLeave(object sender, EventArgs e)
        {
            if (btnOn.BackColor == Color.LightGray)
                btnOn.BackColor = Color.WhiteSmoke;
        }

        private void btnOff_MouseEnter(object sender, EventArgs e)
        {
            if (btnOff.BackColor == Color.WhiteSmoke)
                btnOff.BackColor = Color.LightGray;
            else
            {
                btnOff.BackColor = btnOff.BackColor;
                btnOff.FlatAppearance.BorderColor = btnOff.BackColor;
            }                
        }

        private void btnOff_MouseLeave(object sender, EventArgs e)
        {
            if (btnOff.BackColor == Color.LightGray)
                btnOff.BackColor = Color.WhiteSmoke;
        }        
    }
}
