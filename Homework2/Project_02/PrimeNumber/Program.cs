//第一题：编写程序输出用户指定数据的所有素数因子。
using System;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字：");
            int number;
            number = Convert.ToInt32(Console.ReadLine());
            if (number <= 1) 
            {
                Console.WriteLine("该数字没有素数因子！");
                return;
            }
            for (int i = 2; i <= number; i++)
            {
                while ((number != i) && (number % i == 0))
                {
                    Console.WriteLine($"你输入的数字有素数因子{i}");
                    number = number / i;                   
                }                
            }
            Console.WriteLine($"你输入的数字有素数因子{number}");
        }
    }
}
