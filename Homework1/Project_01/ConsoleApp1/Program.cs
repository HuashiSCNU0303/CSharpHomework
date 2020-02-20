using System;

namespace Calculator_Console
{
    class Calculator
    {
        public static double calculate(double num_1, double num_2, string opera)
        {
            double result = double.NaN;
            switch (opera)
            {
                case "+": result = num_1 + num_2; break;
                case "-": result = num_1 - num_2; break;
                case "*": result = num_1 * num_2; break;
                //除数为0的异常情况已在输入数字时处理，这里就不做处理了
                case "/": result = num_1 / num_2; break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            //重复计算，直到用户选择不再继续计算
            while (true) 
            {
                //循环第一次时不提示是否重新计算，到了第二次以后再出现
                if (flag) 
                {
                    Console.WriteLine("重新计算吗？(Y/N)");
                    if (Console.ReadLine() != "Y")
                    {
                        break;
                    }
                }
                flag = true;
                Console.WriteLine("--------------------------");
                Console.WriteLine("请输入两个数：");
                double num_1 = 0, num_2 = 0;
                try
                {
                    num_1 = Convert.ToDouble(Console.ReadLine());
                    num_2 = Convert.ToDouble(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("没有数字输入，不能计算！");
                    continue;
                }
                Console.WriteLine("请输入操作符：");
                string opera = Console.ReadLine();
                if (opera != "+" && opera != "-" && opera != "*" && opera != "/")
                {
                    Console.WriteLine("输入运算符无效，不能计算！");
                    continue;
                }
                if (opera == "/" && num_2 == 0) 
                {
                    Console.WriteLine("除数为0，不能计算！");
                    continue;
                }
                Console.WriteLine("计算结果为：" + Calculator.calculate(num_1, num_2, opera));
            }
        }
    }
}
