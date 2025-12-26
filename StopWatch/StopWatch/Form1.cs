using System;
using System.Threading; // Thread 사용
using System.Diagnostics; // Stopwatch 사용
using System.Windows.Forms;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        // 도구들 선언
        Stopwatch sw = new Stopwatch(); // 스톱워치
        System.Windows.Forms.Timer uiTimer = new System.Windows.Forms.Timer(); // 화면 갱신용 타이머
        Thread threadWorker; // 쓰레드
        bool isRunning = false; // 작동 상태 체크

        long t = 0; // 쓰레드
        long s = 0; // 스톱워치
        long ti = 0; // 타이머

        // 쓰레드용 중지 전까지 흐른 시간을 기억할 변수
        TimeSpan pausedTime = TimeSpan.Zero;

        public Form1()
        {
            InitializeComponent();

            // 1. 타이머 설정 (0.01초마다 화면 갱신)
            uiTimer.Interval = 10;
            uiTimer.Tick += UiTimer_Tick;

            // 2. 프로그램 시작 시 라벨들의 초기 텍스트 설정
            // 디자인 창에서 지정한 이름(thread, stopwatch, timer)으로 작성하세요.
            thread.Text = "쓰레드: 00:00.00";
            stopwatch.Text = "스톱워치: 00:00.00";
            timer.Text = "타이머: 00:00.00";

            // 3. 버튼 텍스트 초기화
            btnStart.Text = "시작";
            btnLap.Text = "랩";
        }

        // [시작/중단] 버튼 클릭 이벤트
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning) // [시작] 혹은 [계속] 누를 때
            {
                isRunning = true;
                btnStart.Text = "중단";
                btnLap.Text = "랩"; // 다시 랩 버튼으로 변경

                // A. 스톱워치 시작 (Label2)
                sw.Start();

                // B. 타이머 시작 (Label3 업데이트 포함)
                uiTimer.Start();

                // C. 쓰레드 시작 (Label1)
                threadWorker = new Thread(RunThreadTimer);
                threadWorker.IsBackground = true; // 프로그램 종료 시 함께 종료되도록 설정
                threadWorker.Start();
            }
            else // [중단] 누를 때
            {
                isRunning = false;
                btnStart.Text = "시작";
                btnLap.Text = "초기화"; // 중단 시 초기화 버튼으로 변경

                sw.Stop();
                uiTimer.Stop();
                // 쓰레드는 isRunning이 false가 되면 루프를 빠져나가 종료됨.
            }
        }

        // 초기화 버튼(btnLap) 클릭 시 
        private void btnLap_Click(object sender, EventArgs e)
        {
            if (btnLap.Text == "초기화")
            {
                // 1. 시간 및 도구 초기화
                sw.Reset();
                isRunning = false; // 혹시 모르니 안전하게 종료 상태 확인

                // 2. 추가해야 할 변수 초기화
                t = 0; // 쓰레드 카운트 리셋
                s = 0; // 스톱워치 밀리초 리셋
                ti = 0; // 타이머 카운트 리셋

                // 3. 라벨 텍스트 초기화
                thread.Text = "쓰레드: 00:00.00";
                stopwatch.Text = "스톱워치: 00:00.00";
                timer.Text = "타이머: 00:00.00";

                // 4. DataGridView 기록 싹 지우기 (초기화 시에만 실행)
                dgvRecords.Rows.Clear();

                // 5. 버튼 텍스트 복구
                btnLap.Text = "랩"; 
            }
            else // 버튼 텍스트가 "랩"일 때
            {
                // 스톱워치가 돌아가고 있을 때만 기록을 남긴다.
                if (sw.IsRunning)
                {
                    // long 값을 mm:ss.ff 형식의 문자열로 변환
                    string threadVal = TimeSpan.FromMilliseconds(t).ToString(@"mm\:ss\.ff");
                    string swVal = TimeSpan.FromMilliseconds(s).ToString(@"mm\:ss\.ff");
                    string timerVal = TimeSpan.FromMilliseconds(ti).ToString(@"mm\:ss\.ff");

                    // DataGridView에 새로운 행(Row)으로 기록 추가
                    dgvRecords.Rows.Add(threadVal, swVal, timerVal);

                    // 가장 최근에 추가된 행으로 스크롤 이동 (선택 사항)
                    dgvRecords.FirstDisplayedScrollingRowIndex = dgvRecords.RowCount - 1;
                }
            }
        }

        // 방법 1: 쓰레드 (Label1 업데이트)
        private void RunThreadTimer()
        {
            while (isRunning)
            {
                t += 10;
  
                // 중요: 쓰레드에서 UI(라벨)를 직접 건드리면 에러가 나므로 Invoke 사용
                // 이유 찾아보기
                if (thread.IsHandleCreated)
                {
                    thread.Invoke(new MethodInvoker(delegate
                    {
                        thread.Text = "쓰레드: " + TimeSpan.FromMilliseconds(t).ToString(@"mm\:ss\.ff");
                    }));
                }
                Thread.Sleep(10); // CPU 과부하 방지
            }
        }

        // 방법 2 & 3: 스톱워치와 타이머 갱신 (Label2, Label3)
        private void UiTimer_Tick(object sender, EventArgs e)
        {
            // Label2: 스톱워치 방식
            s = sw.ElapsedMilliseconds;
            stopwatch.Text = "스톱워치: " + TimeSpan.FromMilliseconds(s).ToString(@"mm\:ss\.ff");

            // Label3: 타이머 방식 (타이머가 호출될 때마다 찍히는 시간)
            ti += 10;
            timer.Text = "타이머: " + TimeSpan.FromMilliseconds(ti).ToString(@"mm\:ss\.ff");
        }        
    }
}
