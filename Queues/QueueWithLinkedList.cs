using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class QueueWithLinkedList<T> : IEnumerable<T>
    {
        private LinkedList<T> backingStore = new LinkedList<T>();

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

            var itemToReturn = backingStore.Head;
            backingStore.RemoveFirst();
            return itemToReturn.Value;
        }

        public void Enqueue()
        {

        }




        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
