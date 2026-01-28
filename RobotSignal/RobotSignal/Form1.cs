using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace RobotSignal
{
    public partial class Form1 : Form
    {
        // 체크섬
        char STX = (char)0x02;
        char ETX = (char)0x03;

        // 하트비트
        Stopwatch ControlWatch = new Stopwatch();
        bool isRunning = false;
        long hbSendTime; 
        Thread sendThread;

        // 시그널
        int signalIndex;
        long sgSendTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 모든 포트 가져오기
            string[] ports = SerialPort.GetPortNames(); 

            if (ports.Length > 0)
            {
                // 찾은 포트들 콤보박스에 한꺼번에 추가
                comboBox1.Items.AddRange(ports);
            }
            else
            {
                // 포트가 하나도 없을 경우 대비
                comboBox1.Items.Add("None");
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                serialPort1.PortName = comboBox1.Text; // 콤보박스의 선택된 COM 포트명을 시리얼 포트명으로 지정
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.Encoding = System.Text.Encoding.UTF8; // 한글 깨짐 방지                

                // 변수 초기화
                this.ControlWatch.Restart();
                this.hbSendTime = 1000;
                this.sgSendTime = 3000;
                this.signalIndex = 1;
                
                serialPort1.Open(); // 시리얼 포트 열기
                MessageBox.Show("연결이 성공했습니다.");

                StartTimer();
            }
        }                

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting(); // 들어온 데이터를 한 번에 읽음

            this.Invoke(new MethodInvoker(delegate
            {
                lbLog.Items.Add($"[수신] {data}");

                if (lbLog.Items.Count > 0)
                {
                    lbLog.SelectedIndex = lbLog.Items.Count - 1;
                    lbLog.TopIndex = lbLog.Items.Count - 1;
                }
            }));
        }

        // 8bit 16진수 BSD 체크섬
        private string BSD(string senddata)
        {
            byte[] bData = System.Text.Encoding.ASCII.GetBytes(senddata);
            int CS = 0;

            for (int i = 0; i < bData.Length; i++)
            {
                byte element = bData[i];
                CS = (CS >> 1) + ((CS & 1) << 7);
                CS += element;
                CS &= 0xff;
            }
            string Checksum = System.Convert.ToString(CS, 16);
            return Checksum.ToUpper();
        }

        // 스톱워치 세팅
        private void StartTimer()
        {
            if (isRunning) return; // 이미 실행 중이면 무시

            isRunning = true;

            // 별도 쓰레드에서 시간 감시 루프 실행
            sendThread = new Thread(new ThreadStart(SendLoop));
            sendThread.IsBackground = true; // 프로그램 종료 시 함께 종료되도록 설정
            sendThread.Start();
        }
        
        private void SendLoop()
        {         
            while (isRunning)
            {
                // 스톱워치의 현재 경과 시간이 목표 시간을 넘었는지 체크 (1000ms)
                if (ControlWatch.ElapsedMilliseconds >= hbSendTime)
                {
                    SendHeartBeat();
                    hbSendTime += 1000;
                }

                // 스톱워치의 현재 경과 시간이 목표 시간을 넘었는지 체크 (3000ms)
                if (ControlWatch.ElapsedMilliseconds >= sgSendTime)
                {
                    SendSignal();
                    sgSendTime += 3000;
                }

                // CPU 점유율 폭주 방지를 위해 아주 미세하게 쉬어줌 (1ms)
                Thread.Sleep(1);
            }
        }

        // 하트비트
        private void SendHeartBeat()
        {
            if (serialPort1.IsOpen)
            {
                string msg = STX + "CKJ0";
                msg += BSD(msg) + ETX;
                serialPort1.Write(msg); // 상대에게 전송
            }            
        }

        // 시그널
        private void SendSignal()
        {
            if (serialPort1.IsOpen)
            {
                string msg;
                
                switch(signalIndex)
                {
                    case 1:
                        msg = STX + "CST1";
                        msg += BSD(msg) + ETX;
                        serialPort1.Write(msg); // 상대에게 전송

                        this.Invoke(new MethodInvoker(delegate
                        {
                            lbLog.Items.Add($"[송신] {msg}");

                            if (lbLog.Items.Count > 0)
                            {
                                lbLog.SelectedIndex = lbLog.Items.Count - 1;
                                lbLog.TopIndex = lbLog.Items.Count - 1;
                            }
                        }));

                        signalIndex++;
                        break;
                    case 2:
                        msg = STX + "CMD1";
                        msg += BSD(msg) + ETX;
                        serialPort1.Write(msg); // 상대에게 전송

                        this.Invoke(new MethodInvoker(delegate
                        {
                            lbLog.Items.Add($"[송신] {msg}");

                            if (lbLog.Items.Count > 0)
                            {
                                lbLog.SelectedIndex = lbLog.Items.Count - 1;
                                lbLog.TopIndex = lbLog.Items.Count - 1;
                            }
                        }));

                        signalIndex++;
                        break;
                    case 3:
                        msg = STX + "CTR1";
                        msg += BSD(msg) + ETX;
                        serialPort1.Write(msg); // 상대에게 전송

                        this.Invoke(new MethodInvoker(delegate
                        {
                            lbLog.Items.Add($"[송신] {msg}");

                            if (lbLog.Items.Count > 0)
                            {
                                lbLog.SelectedIndex = lbLog.Items.Count - 1;
                                lbLog.TopIndex = lbLog.Items.Count - 1;
                            }
                        }));

                        signalIndex++;
                        break;
                    case 4:
                        msg = STX + "CED1";
                        msg += BSD(msg) + ETX;
                        serialPort1.Write(msg); // 상대에게 전송

                        this.Invoke(new MethodInvoker(delegate
                        {
                            lbLog.Items.Add($"[송신] {msg}");

                            if (lbLog.Items.Count > 0)
                            {
                                lbLog.SelectedIndex = lbLog.Items.Count - 1;
                                lbLog.TopIndex = lbLog.Items.Count - 1;
                            }
                        }));

                        signalIndex = 1;
                        break;
                }                 
            }
        }

        // 자동 모드
        private void btnAutoMode_Click(object sender, EventArgs e)
        {
            // Send 버튼 비활성화
            btnSendST.Enabled = false;
            btnSendMD.Enabled = false;
            btnSendTR.Enabled = false;
            btnSendED.Enabled = false;

            // 시그널 기능 켜기
            signalIndex = 1;
        }

        // 수동 모드
        private void btnManualMode_Click(object sender, EventArgs e)
        {
            // Send 버튼 활성화
            btnSendST.Enabled = true;
            btnSendMD.Enabled = true;
            btnSendTR.Enabled = true;
            btnSendED.Enabled = true;

            // 시그널 기능 끄기
            signalIndex = 0;
        }

        private void btnSendST_Click(object sender, EventArgs e)
        {
            string msg = STX + "CST1";
            msg += BSD(msg) + ETX;
            serialPort1.Write(msg); // 상대에게 전송

            this.Invoke(new MethodInvoker(delegate
            {
                lbLog.Items.Add($"[송신] {msg}");

                if (lbLog.Items.Count > 0)
                {
                    lbLog.SelectedIndex = lbLog.Items.Count - 1;
                    lbLog.TopIndex = lbLog.Items.Count - 1;
                }
            }));
        }

        private void btnSendMD_Click(object sender, EventArgs e)
        {
            string msg = STX + "CMD1";
            msg += BSD(msg) + ETX;
            serialPort1.Write(msg); // 상대에게 전송

            this.Invoke(new MethodInvoker(delegate
            {
                lbLog.Items.Add($"[송신] {msg}");

                if (lbLog.Items.Count > 0)
                {
                    lbLog.SelectedIndex = lbLog.Items.Count - 1;
                    lbLog.TopIndex = lbLog.Items.Count - 1;
                }
            }));
        }

        private void btnSendTR_Click(object sender, EventArgs e)
        {
            string msg = STX + "CTR1";
            msg += BSD(msg) + ETX;
            serialPort1.Write(msg); // 상대에게 전송

            this.Invoke(new MethodInvoker(delegate
            {
                lbLog.Items.Add($"[송신] {msg}");

                if (lbLog.Items.Count > 0)
                {
                    lbLog.SelectedIndex = lbLog.Items.Count - 1;
                    lbLog.TopIndex = lbLog.Items.Count - 1;
                }
            }));
        }

        private void btnSendED_Click(object sender, EventArgs e)
        {
            string msg = STX + "CED1";
            msg += BSD(msg) + ETX;
            serialPort1.Write(msg); // 상대에게 전송

            this.Invoke(new MethodInvoker(delegate
            {
                lbLog.Items.Add($"[송신] {msg}");

                if (lbLog.Items.Count > 0)
                {
                    lbLog.SelectedIndex = lbLog.Items.Count - 1;
                    lbLog.TopIndex = lbLog.Items.Count - 1;
                }
            }));
        }
    }
}
