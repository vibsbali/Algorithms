using System;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }


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
            var node = new LinkedListNode<T>(item);

            //First entry
            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }

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
            var current = Head;
            while (current.Next != null)
            {
                array[arrayIndex] = current.Value;
                ++arrayIndex;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var current = Head;
            while (current != null)
            {
                //If we have a match
                if (current.Value.Equals(item))
                {
                    //First item could be head
                    if (current.Previous == null)
                    {
                        RemoveFirst();
                        return true;
                    }
                    
                    //Last item could be tail
                    if (current.Next == null)
                    {
                        RemoveLast();
                        return true;
                    }

                    //otherwise
                    var currentsPrevious = current.Previous;
                    var currentsNext = current.Next;
                    current = null;
                    currentsPrevious.Next = currentsNext;
                    currentsNext.Previous = currentsPrevious;
                    --Count;
                    return true;
                }

                current = current.Next;
            }
            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call Remove on empty linked list");
            }

            //check if Head and Tail are same
            if (Head == Tail)
            {
                Clear();
            }
            else
            {
                var temp = Head;
                Head = null;
                Head = temp.Next;
                Head.Previous = null; //TODO Check if Head.Previous required or is it already null because we set Head to null
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call Remove on empty linked list");
            }

            if (Head == Tail)
            {
                Clear();
            }
            else
            {
                var tailsPrevious = Tail.Previous;
                Tail = null;
                Tail = tailsPrevious;
                Count--;
            }
        }

        public void AddBack(T item)
        {
            if (Tail == null)
            {
                Add(item);
                return;
            }

            var node = new LinkedListNode<T>(item);
            Tail.Next = node;
            node.Previous = Tail;
            Tail = Tail.Next;
            ++Count;
        }

        public void AddFront(T item)
        {
            if (Head == null)
            {
                Add(item);
                return;
            }

            var node = new LinkedListNode<T>(item);
            Head.Previous = node;
            node.Next = Head;
            Head = Head.Previous;
            ++Count;
        }
    }
}