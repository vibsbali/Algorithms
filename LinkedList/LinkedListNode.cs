using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public LinkedListNode<T> Next { get; set; }
    }
}
