using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        private LinkedListNode<T> Head { get; set; }
        private LinkedListNode<T> Tail { get; set; }

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
            AddToFront(item);
        }

        /// <summary>
        /// Adds item to the front of the Linked List
        /// </summary>
        /// <param name="item"></param>
        public void AddToFront(T item)
        {
            var node = new LinkedListNode<T>(item);
            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                var temp = Head;
                Head = node;
                Head.Next = temp;
            }

            ++Count;
        }

        /// <summary>
        /// Method to add a new item to the back of the list
        /// </summary>
        /// <param name="item"></param>
        public void AddToBack(T item)
        {
            if (Head == null)
            {
                Add(item);
                return;
            }

            var temp = Tail;
            Tail = new LinkedListNode<T>(item);
            temp.Next = Tail;
            ++Count;
        }

        /// <summary>
        /// Clears the Linked List
        /// </summary>
        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Tells if an item is present in the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
            while (current != null)
            {
                array[arrayIndex] = current.Value;
                current = current.Next;
                ++arrayIndex;
            }
        }

        public bool Remove(T item)
        {
            //This is safe to assume as if the first item is not in head then we are ok to proceed
            //We are always going to remove from front
            if (Head.Value.Equals(item))
            {
                RemoveFront();
                return true;
            }

            //Find if item is in the middle or last
            var current = Head.Next; 
            while (current != null) //start at next of Head as head is not the value! previously compared
            {
                if (current.Value.Equals(item))
                {
                    //We have found the item so check if it is tail
                    if (current.Next == null)
                    {
                        RemoveBack();
                        return true;
                    }

                    var temp = current.Next.Next; // 3 -> 4 -> 5 -- remove 4 current is 3 and current.next.next is going to be tail
                    current.Next = null;
                    current.Next = temp;
                    --Count;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void RemoveFront()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Can't call remove on empty linked list");
            }

            var temp = Head;
            Head = null;
            Head = temp.Next;
            --Count;
        }

        /// <summary>
        /// Will have to treverse
        /// </summary>
        public void RemoveBack()
        {
            if (Tail == null)
            {
                throw new InvalidOperationException("Can't call remove on empty linked list");
            }

            //Check if Head and tail are equal
            if (Head == Tail)
            {
                Clear();
            }

            var current = Head;
            while (current.Next != Tail)
            {
                current = current.Next;
            }

            current.Next = null;
            Tail = null;
            Tail = current;
            --Count;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
