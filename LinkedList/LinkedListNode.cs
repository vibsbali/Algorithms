using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
        public LinkedListNode<T> Next { get; set; }
    }
}
