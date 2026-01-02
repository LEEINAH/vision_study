using Basler.Pylon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BaslerTest
{
    public partial class Form1 : Form
    {
        private Camera camera = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectGrab_Click(object sender, EventArgs e)
        {
            try
            {
                // 첫 번째 사용 가능한 카메라 디바이스를 생성.
                camera = new Camera();
                MessageBox.Show("Using device: " + camera.CameraInfo[CameraInfoKey.ModelName]);

                // 카메라를 연다.
                camera.Open();

                // 이미지를 한 장만 가져오도록 설정한다 (One-shot grab).
                // 연속 촬영 (Continuous shot)은 별도 설정이 필요하다.
                camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.SingleFrame);

                // 이미지 획득 시작.
                camera.StreamGrabber.Start();

                // 이미지 그랩 결과(grab result)를 가져옴.
                IGrabResult grabResult = camera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);

                using (grabResult)
                {
                    // 이미지 획득이 성공했는지 확인.
                    if (grabResult.GrabSucceeded)
                    {
                        // 그랩된 이미지를 Bitmap으로 변환하여 PictureBox에 표시.
                        // 이 과정에서는 pylon의 이미지 포맷 변환 유틸리티를 사용하는 것이 좋다.
                        Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                        // 실제 구현에서는 Basler.Pylon.ImageFormatConverter 클래스를 사용하여 안전하게 변환해야 함.

                        // PictureBox에 이미지 표시 (실제 구현 시 변환 코드 추가 필요)
                        pictureBoxDisplay.Image = bitmap;
                        MessageBox.Show("Image grabbed successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Error grabbing image: " + grabResult.ErrorCode + " " + grabResult.ErrorDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // 그랩 중지 및 카메라 닫기
                if (camera != null)
                {
                    camera.StreamGrabber.Stop();
                    camera.Close();
                    camera.Dispose();
                    camera = null;
                }
            }
        }
    }
}
