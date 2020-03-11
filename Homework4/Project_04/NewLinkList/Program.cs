using System;

namespace NewLinkList
{
    // 链表节点
  public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    // 泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void Seal()
        {
            tail.Next = null;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> node = Head;
            while (node != null) 
            {
                action(node.Data);
                node = node.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> linkList = new GenericList<int>();
            while (true) 
            {
                Console.Write("请输入数据元素，或输入Stop结束输入：");
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    linkList.Seal();
                    break;
                }
                else 
                {
                    int data = 0;
                    try 
                    {
                        data = Convert.ToInt32(input);
                        linkList.Add(data);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("请输入整数！");
                    }
                }
            }
            Console.Write("链表内容输出：");
            linkList.ForEach(m => Console.Write(m + " "));
            Console.WriteLine("");

            int maxNum = linkList.Head.Data;
            linkList.ForEach(m => { if (m > maxNum) maxNum = m; });
            Console.WriteLine("链表最大值为：" + maxNum);

            int minNum = linkList.Head.Data;
            linkList.ForEach(m => { if (m < minNum) minNum = m; });
            Console.WriteLine("链表最小值为：" + minNum);

            int sum = 0;
            linkList.ForEach(m => sum += m);
            Console.WriteLine("链表元素和为：" + sum);
        }
    }
}
