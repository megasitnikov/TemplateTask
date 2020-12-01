using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Queue<T>
    {
        int n = 0;
        T save, s;
        T[] value;
        int N;
        public Queue(int N)
        {
            value = new T[N];
            this.N = N;
        }
        public void Push(T number) // Вставка чисел в очередь
        {
            if (n == N)
            {
                Console.WriteLine("Error. The queue is full. Failed to add: " + number);
            }
            else
            {
                value[n] = number;
                n++;
                Console.WriteLine("A number was added to the queue: " + number);
            }
        }
        public void Pop() // Удаление первого числа в очереди
        {
            s = value[0];
            for (int i = 0; i < n - 1; i++)
            {
                value[i] = value[i + 1];
            }
            n--;
            Console.WriteLine("Deleting the first number in the queue: " + s);
        }

        public void Pop_back() // Удаление последнего числа в очереди
        {
            s = value[n - 1];
            for (int z = 0; z < n - 1; z++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    save = value[j];
                    value[j] = value[j + 1];
                    value[j + 1] = save;
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                value[i] = value[i + 1];
            }
            n--;
            Console.WriteLine("Deleting the last number in the queue: " + s);
        }
        public void Print() // Вывод очереди
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(Convert.ToString(value[i]) + "  ");
            }
            Console.WriteLine();
        }
        public void MergingQueues(Queue<T> num) // Объединение очередей    
        {
            T[] arr = new T[N];
            for (int i = 0; i < n; i++)
            {
                arr[i] = value[i];
            }
            int x = n;
            n = n + num.n;
            N = N + num.N;
            value = new T[N];
            int j = 0;
            for (int i = x; i < n; i++)
            {
                value[i] = num.value[j];
                j++;
            }
            for (int i = 0; i < x; i++)
            {
                value[i] = arr[i];
            }
        }
    }
}

