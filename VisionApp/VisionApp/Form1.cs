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

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (originalImg == null) return;

            Mat resizedImg = new Mat();
            // 원본 크기의 0.5배(가로, 세로)로 조절한다.
            // InterpolationFlags.Linear는 크기를 조절할 때 화질을 부드럽게 보정하는 알고리즘이다.
            Cv2.Resize(originalImg, resizedImg, new OpenCvSharp.Size(0, 0), 0.5, 0.5, InterpolationFlags.Linear);

            // 결과 적용
            originalImg = resizedImg;
            pictureBox1.Image = BitmapConverter.ToBitmap(originalImg);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (originalImg == null) return;

            // 1. 사각형 그리기 (이미지, 시작점, 끝점, 색상, 두께)
            // Scalar는 (B, G, R) 순서이다. (255, 0, 0)은 파란색이다.
            Cv2.Rectangle(originalImg, new OpenCvSharp.Point(50, 50), new OpenCvSharp.Point(200, 200), new Scalar(255, 0, 0), 3);

            // 2. 원 그리기 (이미지, 중심점, 반지름, 색상, 두께)
            Cv2.Circle(originalImg, new OpenCvSharp.Point(150, 150), 60, new Scalar(0, 255, 0), 3);

            // 3. 글자 쓰기 (이미지, 내용, 위치, 글꼴, 크기, 색상, 두께)
            Cv2.PutText(originalImg, "Hello C# Vision!", new OpenCvSharp.Point(50, 40),
                HersheyFonts.HersheyComplex, 1.2, new Scalar(0, 0, 255), 2);

            // 화면 업데이트
            pictureBox1.Image = BitmapConverter.ToBitmap(originalImg);
        }
    }
}
