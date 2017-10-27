using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Previous { get; set; }

    }
}
