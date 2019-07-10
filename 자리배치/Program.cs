using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace seatMaster
{
    public class LineMaker
    {
        public void MakeLine(Int32[] a, int b)
        {
            int x = a.Count();
            double b1 = x / b;
            int y = (int)Math.Ceiling(b1);

            Console.WriteLine("결과는???\n");
            for (int i = 0; i < b1 + 1; i++)
            {
                int n = i * b;
                int row = (i + 1) * b;
                for (int n1 = n; n1 < row && row <= x; n1++)
                {
                    Console.Write("{0} ", a[n1]);
                }
                int n2 = n;
                while (row > x && n2 < x)
                {
                    Console.Write("{0} ", a[n2]);
                    n2++;
                }

                Console.Write("\n");
            }

            Console.Write("\n\n");
        }
    }
    public class RandomForSeats
    {
        public Int32[] GetRandomNumbers(Int32 start, Int32 end)
        {
            Int32 startIndex = start > end ? end : start;
            Int32 endIndex = start > end ? start : end;
            Int32 nCount = endIndex - startIndex + 1;
            Int32 nLoopCount = startIndex + endIndex + 1;
            List<Int32> numberList = new List<Int32>(nCount);
            List<Int32> resultList = new List<Int32>(nCount);

            for (Int32 i = startIndex; i < nLoopCount; i++)
                numberList.Add(i);

            Stopwatch sw = new Stopwatch();

            sw.Start();

            while (numberList.Count > 0)
            {

                Random rGen = new Random((Int32)sw.ElapsedTicks + resultList.Count);
                Int32 pickedIndex = rGen.Next(0, numberList.Count);
                resultList.Add(numberList[pickedIndex]);
                numberList.RemoveAt(pickedIndex);
            }

            sw.Stop();

            return resultList.ToArray();
        }
    }
    public class ShowCredit
    {
        public void Show()
        {
            Console.WriteLine("\n제작기간: 2019년 7월 9일 ~ 10일");
            Console.WriteLine("총 제작시간: 2시간");
            Console.WriteLine("사용 언어: .NET 4.7 'C# 7.2'");
            Console.WriteLine("코드 라인 수: 114줄");
            Console.WriteLine("제작자: 대구가톨릭대학교사범대학부속무학중학교 2학년 6반 9번");
            Console.WriteLine("박성헌\n");
            Console.WriteLine("개발자의 말:");
            Console.WriteLine("디자인은 못했습니다. (할 줄 몰라서)\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 클래스를 불러옵니다.
            RandomForSeats rdm = new RandomForSeats();
            LineMaker mkln = new LineMaker();
            ShowCredit credit = new ShowCredit();

            // 학생 수, 행 수를 입력받고 각각 inputStudents, rows에 저장합니다.
            Console.Write("학생 수를 입력하세요: ");
            Int32 inputStudents = Int32.Parse(Console.ReadLine()); // string을 Int32로 변환하기 위해 Parse를 사용합니다.
            Console.Write("행 수를 입력하세요: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("\n");

            Int32[] students = rdm.GetRandomNumbers(1, inputStudents - 1);
            mkln.MakeLine(students, rows);

            Console.Write("크레딧 보고싶습디까?: "); 
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                credit.Show();
            }

            Console.WriteLine("끄려면 아무거나 누르란 말이야~~");
            Console.ReadKey();
        }
    }
}
