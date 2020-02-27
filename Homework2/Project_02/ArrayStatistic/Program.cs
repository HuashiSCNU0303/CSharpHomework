//第二题：编程求一个整数数组的最大值、最小值、平均值和所有数组元素的和。
using System;

namespace ArrayStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize;
            Console.Write("请输入数组的大小：");
            arraySize = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[arraySize];
            for (int i = 0; i < array.Length; i++) 
            {
                Console.Write("请输入数组元素：");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            int maxValue = array[0], minValue = array[0], sumValue = 0;
            foreach(int element in array)
            {
                if (element > maxValue) 
                {
                    maxValue = element;
                }
                if (element < minValue) 
                {
                    minValue = element;
                }
                sumValue += element;
            }
            double averValue = (double)sumValue / array.Length;
            Console.WriteLine($"这一整数数组的最大值为{maxValue}，最小值为{minValue}，总和为{sumValue}，平均值为{averValue}");
        }
    }
}
