using System;
using System.Windows.Forms;

namespace VisionApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 이 줄이 핵심입니다! Form1 창을 실행한다는 뜻이에요.
            Application.Run(new Form1());
        }
    }
}
