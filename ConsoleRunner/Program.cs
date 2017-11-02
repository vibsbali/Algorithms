

using System;
using LinkedList;
using Queues;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new QueueWithLinkedList<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            //1 -> 2 -> 3
            PrintCountAndItems(queue);

            var item = queue.Dequeue();
            Console.WriteLine(item);
            // 1

            PrintCountAndItems(queue);
            // 2 -> 3

            queue.Enqueue(4);
            PrintCountAndItems(queue);
            // 2 -> 3 -> 4

            var numberOfItems = queue.Count;
            for (int i = 0; i < numberOfItems; i++)
            {
                Console.WriteLine(queue.Dequeue());
                // 2 -> 3 -> 4
            }

            try
            {
                queue.Dequeue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void PrintCountAndItems(QueueWithLinkedList<int> queue)
        {
            Console.WriteLine($"Number of items in queue {queue.Count}");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintCountAndItems(LinkedList<int> myLinkedList)
        {
            Console.WriteLine($"Number of items are {myLinkedList.Count}");

            foreach (var item in myLinkedList)
            {
                Console.WriteLine($"The item is {item}");
            }
        }

        private static void TestQueueLinkedList()
        {
            var myLinkedList = new LinkedList<int>();

            myLinkedList.AddFront(1);
            myLinkedList.Add(2);
            myLinkedList.Add(3);


            PrintCountAndItems(myLinkedList);
            // 1 --> 2 --> 3

            myLinkedList.Remove(2);
            PrintCountAndItems(myLinkedList);
            // 1 --> 3


            myLinkedList.AddFront(1);
            myLinkedList.Add(2);
            myLinkedList.Add(3);
            PrintCountAndItems(myLinkedList);
            // 1 --> 1 --> 3 --> 2 --> 3


            myLinkedList.Remove(3);
            // 1 --> 1 --> 2 --> 3
            PrintCountAndItems(myLinkedList);



            myLinkedList.Remove(1);
            PrintCountAndItems(myLinkedList);
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
