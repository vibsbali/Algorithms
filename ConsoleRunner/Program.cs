using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoublyLinkedList;
using LinkedList;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestSinglyLinkedList();

            var myLinkedList = new DoubleLinkedList<int>();

            myLinkedList.Add(1);
            myLinkedList.AddBack(2);
            myLinkedList.AddBack(3);


            PrintCountAndItems(myLinkedList);
            // 1 --> 2 --> 3

            myLinkedList.Remove(2);
            PrintCountAndItems(myLinkedList);
            // 1 --> 3


            myLinkedList.Add(1);
            myLinkedList.AddBack(2);
            myLinkedList.AddBack(3);
            // 1 --> 1 --> 3 --> 2 --> 3


            myLinkedList.Remove(3);
            // 1 --> 1 --> 2 --> 3
            PrintCountAndItems(myLinkedList);

            

            myLinkedList.Remove(1);
            PrintCountAndItems(myLinkedList);
        }

        private static void PrintCountAndItems(DoubleLinkedList<int> myLinkedList)
        {
            Console.WriteLine($"Number of items are {myLinkedList.Count}");

            foreach (var item in myLinkedList)
            {
                Console.WriteLine($"The item is {item}");
            }
        }

        private static void TestSinglyLinkedList()
        {
            var myLinkedList = new SinglyLinkedList<int>();

            myLinkedList.Add(1);
            myLinkedList.AddToBack(2);
            myLinkedList.AddToBack(3);


            PrintCountAndItems(myLinkedList);

            myLinkedList.Remove(2);
            PrintCountAndItems(myLinkedList);

            myLinkedList.Remove(3);
            PrintCountAndItems(myLinkedList);

            myLinkedList.Remove(1);
            PrintCountAndItems(myLinkedList);
        }

        private static void PrintCountAndItems(SinglyLinkedList<int> myLinkedList)
        {
            Console.WriteLine($"Number of items are {myLinkedList.Count}");

            foreach (var item in myLinkedList)
            {
                Console.WriteLine($"The item is {item}");
            }
        }
    }
}
