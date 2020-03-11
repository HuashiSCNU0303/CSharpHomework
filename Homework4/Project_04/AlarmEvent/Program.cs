using System;
using System.Threading;

namespace AlarmEvent
{
    public delegate void ClockEventHandler(object sender, ClockEventArgs args);
    public class ClockEventArgs
    {
        public DateTime alarmingTime { get; set; }
        public DateTime tickingTime { get; set; }
    }
    class Clock
    {
        public event ClockEventHandler TickEvent;
        public event ClockEventHandler AlarmEvent;
        public void Tick()
        {
            Thread.Sleep(1000);
            ClockEventArgs args = new ClockEventArgs()
            {
                tickingTime = DateTime.Now
            };
            TickEvent(this, args);
        }
        public void Alarm()
        {
            ClockEventArgs args = new ClockEventArgs()
            {
                alarmingTime = DateTime.Now
            };
            AlarmEvent(this, args);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            clock.TickEvent += TickListener;
            clock.AlarmEvent += AlarmListener;
            while(true)
            {
                Console.Write("你想让闹钟几秒钟后开始响：");
                string input = Console.ReadLine();
                int alarmingTime = 0;
                while(true)
                {
                    try
                    { 
                        alarmingTime = Convert.ToInt32(input);
                        break;
                    }   
                    catch(FormatException)
                    {
                        Console.WriteLine("请输入整数！");
                        Console.Write("重新输入：");
                        input = Console.ReadLine();
                    }
                }
                for (int i = 0; i < alarmingTime; i++) 
                {
                    clock.Tick();
                }
                clock.Alarm();
                Console.Write("还需要继续响铃吗？如果不需要，输入Stop，否则，输入任意字符：");
                if (Console.ReadLine() == "Stop")
                {
                    break;
                }
            }          
        }
        static void TickListener(object sender, ClockEventArgs args)
        {
            Console.WriteLine("秒针摆动！当前时间：" + args.tickingTime);
        }
        static void AlarmListener(object sender, ClockEventArgs args)
        {
            Console.WriteLine("响铃啦！当前时间：" + args.alarmingTime);
        }
    }
}
