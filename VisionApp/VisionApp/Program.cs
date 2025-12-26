using System;
using OpenCvSharp;

namespace VisionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 원본 이미지 불러오기
            string path = @"C:\Users\PC\Desktop\사진\아기짱구.jpg";
            Mat src = Cv2.ImRead(path, ImreadModes.Color);

            if (src.Empty())
            {
                Console.WriteLine("이미지를 불러오지 못했습니다. 경로를 확인하세요!");
                return;
            }

            // 2. 흑백 이미지를 저장할 빈 그릇(Mat) 만들기
            Mat gray = new Mat();

            // 3. 컬러 -> 흑백 변환 (BGR2GRAY)
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            // 4. 결과 화면에 띄우기
            Cv2.ImShow("Original (Color)", src);
            Cv2.ImShow("Result (Grayscale)", gray);

            // 5. 아무 키나 누르면 종료
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
