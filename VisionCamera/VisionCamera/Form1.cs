using Basler.Pylon;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace VisionCamera
{
    public partial class Form1 : Form
    {
        private Camera camera1 = null;                                      // 카메라 1
        private Camera camera2 = null;                                      // 카메라 2
        private Mat originalImg1;                                           // 카메라 1 원본을 저장할 변수
        private Mat originalImg2;                                           // 카메라 2 원본을 저장할 변수
        private PixelDataConverter converter = new PixelDataConverter();    // 이미지 변환 도구

        public Form1()
        {
            InitializeComponent();
        }

        // 라이브
        private void btnLive_Click(object sender, EventArgs e)
        {
            try
            {
                // 카메라 객체가 없으면 생성
                if (camera1 == null)
                {
                    List<ICameraInfo> allCameras = CameraFinder.Enumerate();
                    if (allCameras.Count < 2) return;
                    camera1 = new Camera(allCameras[0]);
                    camera2 = new Camera(allCameras[1]);
                }

                // 이미 열려 있는지 확인 후, 닫혀 있을 때만 Open
                if (!camera1.IsOpen) camera1.Open();
                if (!camera2.IsOpen) camera2.Open();

                // 이미 동작 중이면 정지 후 재시작 (충돌 방지)
                if (camera1.StreamGrabber.IsGrabbing) camera1.StreamGrabber.Stop();
                if (camera2.StreamGrabber.IsGrabbing) camera2.StreamGrabber.Stop();

                // 이벤트 연결 (중복 등록 방지를 위해 한 번 빼고 다시 넣기)
                camera1.StreamGrabber.ImageGrabbed -= OnImageGrabbed1;
                camera1.StreamGrabber.ImageGrabbed += OnImageGrabbed1;
                camera2.StreamGrabber.ImageGrabbed -= OnImageGrabbed2;
                camera2.StreamGrabber.ImageGrabbed += OnImageGrabbed2;

                // 라이브 시작 (LatestImages)
                camera1.StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
                camera2.StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("라이브 에러: " + ex.Message);
            }
        }

        // camera1 라이브 이벤트 로직
        private void OnImageGrabbed1(object sender, ImageGrabbedEventArgs e)
        {      
            using (IGrabResult grabResult = e.GrabResult)
            {
                if (grabResult.GrabSucceeded)
                {
                    // 비트맵 생성 (해상도에 맞게)
                    Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);

                    BitmapData bitmapData = bitmap.LockBits(
                        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.WriteOnly,
                        PixelFormat.Format32bppRgb);

                    // 여기서 변환기(Converter)가 중요하다. 
                    // 카메라의 어떤 포맷이든 PictureBox가 읽을 수 있는 BGRA8로 바꾼다.
                    converter.OutputPixelFormat = PixelType.BGRA8packed;
                    converter.Convert(bitmapData.Scan0, bitmapData.Stride * bitmap.Height, grabResult);

                    bitmap.UnlockBits(bitmapData);

                    // UI 업데이트
                    // 중요: 창 핸들이 있는지 확인 후 Invoke 호출
                    if (pictureBox1.IsHandleCreated && !pictureBox1.IsDisposed)
                    {
                        pictureBox1.BeginInvoke(new Action(() =>
                        {
                            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                            pictureBox1.Image = bitmap;
                        }));
                    }
                }
            }
        }

        // camera2 라이브 이벤트 로직
        private void OnImageGrabbed2(object sender, ImageGrabbedEventArgs e)
        {
            using (IGrabResult grabResult = e.GrabResult)
            {
                if (grabResult.GrabSucceeded)
                {
                    // 비트맵 생성 (해상도에 맞게)
                    Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);

                    BitmapData bitmapData = bitmap.LockBits(
                        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.WriteOnly,
                        PixelFormat.Format32bppRgb);

                    // 여기서 변환기(Converter)가 중요하다. 
                    // 카메라의 어떤 포맷이든 PictureBox가 읽을 수 있는 BGRA8로 바꾼다.
                    converter.OutputPixelFormat = PixelType.BGRA8packed;
                    converter.Convert(bitmapData.Scan0, bitmapData.Stride * bitmap.Height, grabResult);

                    bitmap.UnlockBits(bitmapData);

                    // UI 업데이트
                    // 중요: 창 핸들이 있는지 확인 후 Invoke 호출
                    if (pictureBox2.IsHandleCreated && !pictureBox2.IsDisposed)
                    {
                        pictureBox2.BeginInvoke(new Action(() =>
                        {
                            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                            pictureBox2.Image = bitmap;
                        }));
                    }
                }
            }
        }

        // 캡쳐
        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                // 실시간 중지 및 '확실한' 대기
                if (camera1 != null && camera1.StreamGrabber.IsGrabbing)
                {
                    // 이벤트 핸들러를 먼저 떼야 RetrieveResult와 충돌하지 않습니다.
                    camera1.StreamGrabber.ImageGrabbed -= OnImageGrabbed1;
                    camera1.StreamGrabber.Stop();
                }
                if (camera2 != null && camera2.StreamGrabber.IsGrabbing)
                {
                    camera2.StreamGrabber.ImageGrabbed -= OnImageGrabbed2;
                    camera2.StreamGrabber.Stop();
                }

                // 엔진 안정화를 위해 충분한 시간을 줍니다.
                System.Threading.Thread.Sleep(300);

                // 카메라가 Open되어 있지 않다면 열어줌 (Live를 안 누르고 사진부터 누를 경우 대비)
                if (camera1 == null)
                {
                    List<ICameraInfo> allCameras = CameraFinder.Enumerate();
                    if (allCameras.Count < 2) return;
                    camera1 = new Camera(allCameras[0]);
                    camera2 = new Camera(allCameras[1]);
                    camera1.Open();
                    camera2.Open();
                }             

                // 각각 설정 (예: 노출 시간)
                camera1.Parameters[PLCamera.ExposureTimeAbs].SetValue(5000);
                camera2.Parameters[PLCamera.ExposureTimeAbs].SetValue(5000);

                // 각각 촬영 시작
                camera1.StreamGrabber.Start();
                camera2.StreamGrabber.Start();

                // 결과 가져오기 (각각 호출)
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
                        pictureBox1.Image = bitmap;
                        originalImg1 = BitmapConverter.ToMat(bitmap);
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
                        pictureBox2.Image = bitmap;
                        originalImg2 = BitmapConverter.ToMat(bitmap);
                    }
                }
            }
            // 코드 실행 중 오류(IP 미설정 등)가 발생하면 상세 내용을 출력한다.
            catch (Exception ex)
            {
                MessageBox.Show("캡처 실패 에러: " + ex.Message);
            }
            // 성공하든 실패하든 마지막에는 반드시 카메라 연결을 끄고 메모리를 정리한다.
            finally
            {
                // 캡처 후 정리
                if (camera1 != null && camera1.StreamGrabber.IsGrabbing) camera1.StreamGrabber.Stop();
                if (camera2 != null && camera2.StreamGrabber.IsGrabbing) camera2.StreamGrabber.Stop();
            }
        }

        // 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null) return;

            // 공통 시간 이름 생성 (예: 20260106_153022)
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string folderPath = @"C:\Users\PC\Desktop\사진\";

            // 파일명 규칙: 시간_카메라번호.jpg
            string path1 = folderPath + timestamp + "_Cam1.jpg";
            string path2 = folderPath + timestamp + "_Cam2.jpg";

            // originalImg1, 2는 캡처 시 저장된 Mat 객체
            Cv2.ImWrite(path1, originalImg1);
            Cv2.ImWrite(path2, originalImg2);
            MessageBox.Show("저장되었습니다!");
        }

        // 불러오기
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // 라이브가 켜져 있다면 먼저 끈다.
            if (camera1 != null && camera1.StreamGrabber.IsGrabbing)
            {
                camera1.StreamGrabber.ImageGrabbed -= OnImageGrabbed1;
                camera1.StreamGrabber.Stop();
            }
            if (camera2 != null && camera2.StreamGrabber.IsGrabbing)
            {
                camera2.StreamGrabber.ImageGrabbed -= OnImageGrabbed2;
                camera2.StreamGrabber.Stop();
            }

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "이미지 파일|*_Cam1.jpg;*_Cam2.jpg;*_Cam1.png;*_Cam2.png"; // 규칙에 맞는 파일만 표시
                openFile.Title = "아무 카메라의 사진 하나만 선택하세요";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openFile.FileName;
                    string partnerPath = "";

                    // 선택한 파일이 1번인지 2번인지 판단해서 짝꿍 경로 생성
                    if (selectedPath.Contains("_Cam1"))
                    {
                        partnerPath = selectedPath.Replace("_Cam1", "_Cam2");
                        LoadToPictureBox(selectedPath, 1); // 선택한 건 1번에
                        if (System.IO.File.Exists(partnerPath))
                            LoadToPictureBox(partnerPath, 2); // 짝꿍은 2번에
                        else
                            MessageBox.Show("2번 카메라 짝꿍 파일을 찾을 수 없습니다.");
                    }
                    else if (selectedPath.Contains("_Cam2"))
                    {
                        partnerPath = selectedPath.Replace("_Cam2", "_Cam1");
                        LoadToPictureBox(selectedPath, 2); // 선택한 건 2번에
                        if (System.IO.File.Exists(partnerPath))
                            LoadToPictureBox(partnerPath, 1); // 짝꿍은 1번에
                        else
                            MessageBox.Show("1번 카메라 짝꿍 파일을 찾을 수 없습니다.");
                    }
                }
            }
        }

        // 이미지 로드 공용 함수
        private void LoadToPictureBox(string path, int camNum)
        {
            if (camNum == 1)
            {
                originalImg1 = Cv2.ImRead(path);
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = BitmapConverter.ToBitmap(originalImg1);
            }
            else
            {
                originalImg2 = Cv2.ImRead(path);
                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = BitmapConverter.ToBitmap(originalImg2);
            }
        }

        // 창을 닫으면 카메라 정리
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (camera1 != null && camera1.StreamGrabber.IsGrabbing) camera1.StreamGrabber.Stop();
            if (camera2 != null && camera2.StreamGrabber.IsGrabbing) camera2.StreamGrabber.Stop();
        }
    }
}