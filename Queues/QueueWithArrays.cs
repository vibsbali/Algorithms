using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class QueueWithArrays<T> : IEnumerable<T>
    {
        //Initialise with 16
        private T[] backingStore;
        private int head = 0;
        private int tail = -1;

        public int Count { get; private set; }

        public QueueWithArrays()
                : this(16)
        {
        }

        public QueueWithArrays(int initialSize)
        {
            backingStore = new T[initialSize];
        }

        public void Enqueue(T item)
        {
            tail++; // increment tail and check if still within bounds
            if (tail > backingStore.Length - 1)
            {
                IncreaseBackingStore();
            }

            backingStore[tail] = item;
            Count++;

            //Need to consider wrapping and increasing size of the backing array
        }

        private void IncreaseBackingStore()
        {
            var tempArray = backingStore;
            backingStore = new T[tempArray.Length * 2];

            if (IsWrapped())
            {
                var itemsFromHeadToEnd = tempArray.Length - 1;
                Array.Copy(tempArray, head, backingStore, 0, itemsFromHeadToEnd);
                var itemsFromFrontToTail = head - 1;
                Array.Copy(tempArray, 0, backingStore, itemsFromFrontToTail + 1, tempArray.Length - itemsFromFrontToTail);

                head = 0;
                tail = itemsFromHeadToEnd + itemsFromFrontToTail;
            }
            else
            {
                Array.Copy(tempArray, 0, backingStore, 0, tempArray.Length);
            }
            
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call dequeue on empty queue");
            }

            var item = backingStore[head];
            head++;
            Count--;

            return item;

            //Still need to check about wrapping 
        }


        public IEnumerator<T> GetEnumerator()
        {
            if (IsWrapped())
            {
                for (int i = head; i < backingStore.Length; i++)
                {
                    yield return backingStore[i];
                }

                for (int i = 0; i <= tail; i++)
                {
                    yield return backingStore[tail];
                }
            }
            else
            {
                for (int i = head; i <= tail; i++)
                {
                    yield return backingStore[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool IsWrapped()
        {
            if (tail < head)
            {
                return true;
            }

            return false;
        }
    }
}
