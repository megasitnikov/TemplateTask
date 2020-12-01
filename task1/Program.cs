using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
	class Program
	{
        static void Main(string[] args)
        {
            Queue<int> queue_1 = new Queue<int>(4);
            for (int i = 1; i <= 5; i++)
            {
                queue_1.Push(i);
            }
            Console.WriteLine("First queue");
            queue_1.Print();
            queue_1.Pop_back();
            queue_1.Print();

            Queue<int> queue_2 = new Queue<int>(2);
            for (int i = 6; i <= 10; i++)
            {
                queue_2.Push(i);
            }
            Console.WriteLine("Second queue");
            queue_2.Print();
            queue_2.Pop();
            queue_2.Print();

            Queue<int> queue_1_2 = new Queue<int>(6);
            queue_1_2.MergingQueues(queue_1);
            queue_1_2.MergingQueues(queue_2);
            Console.WriteLine("First + Second");
            queue_1_2.Print();
        }
    }
}