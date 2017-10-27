using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class DoubleLinkedList<T> : ICollection<T>
    {
        private DoubleLinkedListNode<T> Head { get; set; }
        private DoubleLinkedListNode<T> Tail { get; set; }


        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            AddFront(item);
        }

        public void AddFront(T item)
        {
            var node = new DoubleLinkedListNode<T>(item);
            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }

            ++Count;
        }

        public void AddBack(T item)
        {
            var node = new DoubleLinkedListNode<T>(item);
            if (Tail == null)
            {
                AddFront(item);
                return;
            }
            // The following code will only run if Tail is not null
            // Head --> 2 --> 4 --> 5 --> Tail
            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
            ++Count;
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            
        }

        public bool Remove(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    //If item is at the begining 
                    //Notice how different it is to Head.Value.Equals(item)
                    if (current.Previous == null)
                    {
                        RemoveFront();
                        return true;
                    }

                    //If item is in tail
                    //Notice how different it is to Tail.Value.Equals(item)
                    if (current.Next == null)
                    {
                        RemoveLast();
                        return true;
                    }

                    var previous = current.Previous;
                    var next = current.Next;
                    previous.Next = next;
                    next.Previous = previous;

                    --Count;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void RemoveFront()
        {
            if (Head == Tail)
            {
                Clear();
                return;
            }

            var nextNode = Head.Next;
            nextNode.Previous = null;
            Head = null;
            Head = nextNode;
            --Count;
        }

        public void RemoveLast()
        {
            if (Head == Tail)
            {
                Clear();
                return;
            }
            
            var previousNode = Tail.Previous;
            previousNode.Next = null;
            Tail = null;
            Tail = previousNode;
            --Count;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;
    }
}
