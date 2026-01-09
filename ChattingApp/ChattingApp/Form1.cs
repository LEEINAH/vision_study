using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace ChattingApp
{
    public partial class Form1 : Form
    {
        User1 user1;
        User2 user2;

        public Form1()
        {
            InitializeComponent();
            user1 = new User1(this);
            user2 = new User2(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 포트 가져오기
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length > 0)
            {
                // 찾은 포트들(COM1, COM2...)을 한꺼번에 추가
                comboBox1.Items.AddRange(ports);
                comboBox2.Items.AddRange(ports);
            }
            else
            {
                // 포트가 하나도 없을 경우 대비
                comboBox1.Items.Add("None");
                comboBox2.Items.Add("None");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
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

                serialPort1.Open(); // 시리얼 포트 열기                
            }

            if (!serialPort2.IsOpen)
            {
                serialPort2.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                serialPort2.PortName = comboBox2.Text; // 콤보박스의 선택된 COM 포트명을 시리얼 포트명으로 지정
                serialPort2.BaudRate = 9600; 
                serialPort2.DataBits = 8;
                serialPort2.StopBits = StopBits.One;
                serialPort2.Parity = Parity.None;
                serialPort2.Encoding = System.Text.Encoding.UTF8; // 한글 깨짐 방지
                

                serialPort2.Open(); // 시리얼 포트 열기                
            }

            MessageBox.Show("연결이 성공했습니다.");

            // user1이 없거나(null) 이미 닫혔다면(IsDisposed) 새로 생성
            if (user1 == null || user1.IsDisposed)
                user1 = new User1(this);

            if (user2 == null || user2.IsDisposed)
                user2 = new User2(this);

            user1.Show();
            user2.Show();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting(); // 들어온 데이터를 한 번에 읽음

            // UI 스레드 접근을 위해 Invoke 사용
            this.Invoke(new MethodInvoker(delegate {
                if (sp.PortName == comboBox1.Text)
                {
                    user2.listBox1.Items.Add($"[수신] {data}");
                }
                else if (sp.PortName == comboBox2.Text)
                {
                    user1.listBox1.Items.Add($"[수신] {data}");
                }
            }));
        }
    }
}
