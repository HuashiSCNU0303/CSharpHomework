//第三题：用“埃氏筛法”求2~100以内的素数。
using System;

namespace PrimeNumber_Eratos
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 100; // 利用埃氏筛法求素数的范围是2~maxNumber
            bool[] numbers = new bool[maxNumber + 1]; // 布尔型数组，每个元素存的是表示下标数字是否为素数的布尔型变量
            for (int i = 0; i < numbers.Length; i++)  
            {
                numbers[i] = true;
            }
            for (int i = 2; i * i <= maxNumber; i++)  
            {
                if (!numbers[i])  
                {
                    continue;
                }
                for (int j = 2 * i; j <= maxNumber; j += i) 
                {
                    numbers[j] = false;
                }
            }
            for (int i = 2; i < numbers.Length; i++) 
            {
                if (numbers[i]) 
                {
                    Console.WriteLine($"2~{maxNumber}之间有素数{i}");
                }
            }
        }
    }
}
