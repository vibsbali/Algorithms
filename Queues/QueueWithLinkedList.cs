using System;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
    public class QueueWithLinkedList<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> backingStore = new LinkedList<T>();

        public T Peek()
        {
            if (backingStore.Count == 0)
            {
                throw new InvalidOperationException("Cannot call Peek on empty Queue");
            }

            return backingStore.Head.Value;
        }

        public T Dequeue()
        {
            if (backingStore.Count == 0)
            {
                throw new InvalidOperationException("Cannot call Peek on empty Queue");
            }

            var valueToReturn = backingStore.Head.Value;
            backingStore.RemoveFirst();
            return valueToReturn;
        }

        public void Enqueue(T item)
        {
            backingStore.Add(item);
        }

        public int Count => backingStore.Count;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in backingStore)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
