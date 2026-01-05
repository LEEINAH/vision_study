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
        private Camera camera1 = null;
        private Camera camera2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectGrab_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 연결된 모든 카메라 리스트 가져오기
                List<ICameraInfo> allCameras = CameraFinder.Enumerate();

                if (allCameras.Count < 2)
                {
                    MessageBox.Show("카메라가 2대 이상 연결되어야 합니다. 현재: " + allCameras.Count + "대");
                    return;
                }

                // 2. 각각의 객체 생성 및 오픈
                camera1 = new Camera(allCameras[0]); // 첫 번째 카메라
                camera2 = new Camera(allCameras[1]); // 두 번째 카메라

                camera1.Open();
                camera2.Open();

                // 3. 각각 설정 (예: 노출 시간)
                camera1.Parameters[PLCamera.ExposureTimeAbs].SetValue(5000);
                camera2.Parameters[PLCamera.ExposureTimeAbs].SetValue(5000);

                // 4. 각각 촬영 시작
                camera1.StreamGrabber.Start();
                camera2.StreamGrabber.Start();

                // 5. 결과 가져오기 (각각 호출)
                IGrabResult result1 = camera1.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);
                IGrabResult result2 = camera2.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);

                using (result1)
                {
                    // 이미지 획득이 성공했는지 확인.
                    if (result1.GrabSucceeded)
                    {
                        // Pylon의 이미지 변환기 생성
                        PixelDataConverter converter = new PixelDataConverter();

                        // 윈도우 PictureBox에서 쓸 수 있는 비트맵 도화지 생성
                        Bitmap bitmap = new Bitmap(result1.Width, result1.Height, PixelFormat.Format32bppRgb);

                        // 비트맵의 메모리 영역을 잠시 고정 (데이터를 쓰기 위함)
                        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

                        // 카메라 데이터를 윈도우용 컬러 포맷(BGRA8)으로 변환해서 복사
                        converter.OutputPixelFormat = PixelType.BGRA8packed;
                        IntPtr ptrBmp = bmpData.Scan0; // 도화지의 시작 주소
                        converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, result1);

                        // 메모리 고정 해제
                        bitmap.UnlockBits(bmpData);

                        // 드디어 화면에 표시!
                        pictureBoxDisplay1.Image = bitmap;
                    }
                }
                using (result2)
                {
                    // 이미지 획득이 성공했는지 확인.
                    if (result2.GrabSucceeded)
                    {
                        // Pylon의 이미지 변환기 생성
                        PixelDataConverter converter = new PixelDataConverter();

                        // 윈도우 PictureBox에서 쓸 수 있는 비트맵 도화지 생성
                        Bitmap bitmap = new Bitmap(result2.Width, result2.Height, PixelFormat.Format32bppRgb);

                        // 비트맵의 메모리 영역을 잠시 고정 (데이터를 쓰기 위함)
                        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

                        // 카메라 데이터를 윈도우용 컬러 포맷(BGRA8)으로 변환해서 복사
                        converter.OutputPixelFormat = PixelType.BGRA8packed;
                        IntPtr ptrBmp = bmpData.Scan0; // 도화지의 시작 주소
                        converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, result2);

                        // 메모리 고정 해제
                        bitmap.UnlockBits(bmpData);

                        // 드디어 화면에 표시!
                        pictureBoxDisplay2.Image = bitmap;
                    }
                }
            }
            // 코드 실행 중 오류(IP 미설정 등)가 발생하면 상세 내용을 출력한다.
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // 성공하든 실패하든 마지막에는 반드시 카메라 연결을 끄고 메모리를 정리한다.
            finally
            {
                // 그랩 중지 및 카메라 닫기
                if (camera1 != null)
                {
                    camera1.StreamGrabber.Stop(); // 스트림 중지
                    camera1.Close();              // 카메라 닫기
                    camera1.Dispose();            // 리소스 해제
                    camera1 = null;               // 객체 초기화
                }

                // 그랩 중지 및 카메라 닫기
                if (camera2 != null)
                {
                    camera2.StreamGrabber.Stop(); // 스트림 중지
                    camera2.Close();              // 카메라 닫기
                    camera2.Dispose();            // 리소스 해제
                    camera2 = null;               // 객체 초기화
                }
            }
        }
    }    
}
