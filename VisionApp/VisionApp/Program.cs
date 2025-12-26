using System;
using OpenCvSharp;

namespace VisionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2. 이미지 파일 불러오기
            Mat image = Cv2.ImRead(@"C:\Users\PC\Desktop\사진\아기짱구.jpg", ImreadModes.Color);

            // 3. 이미지가 비어있는지 확인
            if (image.Empty())
            {
                Console.WriteLine("이미지를 찾을 수 없습니다.");
                return;
            }

            // 4. 새 창을 만들어 이미지 출력
            Cv2.ImShow("My First Vision App", image);

            // 5. 아무 키나 누를 때까지 대기 (이게 없으면 창이 바로 닫힘)
            Cv2.WaitKey(0);

            // 6. 모든 창 닫기 및 메모리 해제
            Cv2.DestroyAllWindows();
        }
    }
}
