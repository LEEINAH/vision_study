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

            // 3. 원본을 흑백으로 변경
            originalImg = grayImg;

            // 4. 변환된 이미지를 PictureBox에 바로 업데이트
            pictureBox1.Image = BitmapConverter.ToBitmap(originalImg);
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            if (originalImg == null) return;

            Mat flipImg = new Mat();
            // 1: 좌우 반전, 0: 상하 반전, -1: 좌우&상하 반전
            Cv2.Flip(originalImg, flipImg, FlipMode.Y);

            // 화면 업데이트 (원본을 반전된 것으로 교체하고 싶다면 아래처럼 하면 된다)
            originalImg = flipImg;
            pictureBox1.Image = BitmapConverter.ToBitmap(originalImg);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "JPG 파일|*.jpg|PNG 파일|*.png|모든 파일|*.*";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    // PictureBox에 있는 현재 이미지를 Mat으로 다시 바꿔서 저장하거나
                    // 현재 originalImg 변수를 저장한다.
                    Cv2.ImWrite(saveFile.FileName, originalImg);
                    MessageBox.Show("저장되었습니다!");
                }
            }
        }
    }
}
