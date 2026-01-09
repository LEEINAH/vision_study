using System;
using System.Windows.Forms;

namespace ChattingApp
{
    public partial class User1 : Form
    {
        Form1 _form1;
        public User1(Form1 form)
        { // 생성자에서 받아옴
            InitializeComponent();
            _form1 = form;
        }

        public User1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_form1.serialPort2.IsOpen)
            {
                string msg = textBox1.Text;
                _form1.serialPort2.Write(msg); // 상대에게 전송
                listBox1.Items.Add($"[나] {msg}"); // 내 리스트박스에 기록
                textBox1.Clear();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // 누른 키가 Enter인지 확인
            if (e.KeyCode == Keys.Enter)
            {
                // 소리 방지 (띵 소리 안 나게)
                e.SuppressKeyPress = true;

                // 이미 만들어둔 버튼 클릭 메서드 호출
                btnSend_Click(sender, e);
            }
        }
    }
}
