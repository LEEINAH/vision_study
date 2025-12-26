using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace VisionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Mat originalImg; // 원본을 저장할 변수

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 1. 선택한 경로에서 이미지 읽기
                    originalImg = Cv2.ImRead(openFile.FileName);

                    // 2. PictureBox에 표시 (Mat을 Bitmap으로 변환해서 넣어야함)
                    pictureBox1.Image = BitmapConverter.ToBitmap(originalImg);
                }
            }
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            if (originalImg == null) return; // 이미지가 없으면 실행 안 함

            // 1. 흑백 결과를 담을 그릇 생성
            Mat grayImg = new Mat();

            // 2. 흑백 변환 알고리즘 적용
            Cv2.CvtColor(originalImg, grayImg, ColorConversionCodes.BGR2GRAY);

            // 3. 변환된 이미지를 PictureBox에 바로 업데이트
            pictureBox1.Image = BitmapConverter.ToBitmap(grayImg);
        }
    }
}
