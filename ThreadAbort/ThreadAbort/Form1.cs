using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ThreadAbort
{
    public partial class Form1 : Form
    {
        Thread threadWorker;
        bool isRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isRunning = true;
            threadWorker = new Thread(RunThreadTimer);
            threadWorker.Start();            
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            threadWorker.Abort();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            isRunning = false;

            threadWorker.Join();
        }

        private void RunThreadTimer()
        {
            int count = 0;
            while (isRunning)
            {
                if (label1.IsHandleCreated)
                {
                    label1.Invoke(new MethodInvoker(delegate
                    {
                        if (count > 10)
                        { 
                            label1.Text = string.Empty;
                            count = 0;
                        
                        }
                        else
                        {
                            label1.Text += ".";
                            count++;
                        }
                    })); 
                }             
               Thread.Sleep(100);
            }
            Thread T = new Thread(() =>
            {
                if (label1.IsHandleCreated)
                {
                    label1.Invoke(new MethodInvoker(delegate
                    {
                        label1.Text = "끝";
                    }));
                }
            });
            T.Start();           
        }
    }
}
