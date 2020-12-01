using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
	class Program
	{
        static void Main(string[] args)
        {
            bool search;
            Tree<int> tree = new Tree<int>(13);
            tree.Push(3);
            tree.Push(7);
            tree.Push(21);
            tree.Push(18);
            tree.Push(5);
            tree.Push(28);
            tree.Push(41);
            tree.Push(33);
            Console.WriteLine();
            int[] arr = tree.Leaves();
            for (int i = 0; i < tree.getCount(); i++) Console.Write("{0} ", arr[i]);
            Console.WriteLine();
            Console.WriteLine();
            search = tree.ElementSearch(21);
            Console.WriteLine("Element 21 was found? - " + search.ToString());
            Console.WriteLine();
            tree.DeleteElement(21);
            search = tree.ElementSearch(21);
            Console.WriteLine("Element 21 was found? - " + search.ToString());
            Console.WriteLine();
            arr = tree.Leaves();
            for (int i = 0; i < tree.getCount(); i++) Console.Write("{0} ", arr[i]);
            Console.WriteLine(); Console.WriteLine();
            search = tree.ElementSearch(28);
            Console.WriteLine("Element 28 was found? - " + search.ToString());
            Console.WriteLine();
            search = tree.ElementSearch(69);
            Console.WriteLine("Element 69 was found? - " + search.ToString());
            Console.WriteLine();
        }
    }
}