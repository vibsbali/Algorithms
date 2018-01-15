using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sorting
{
    public static class SortingHelpers<T>
    {
        private static readonly object locker = new object();
        public static void Swap(T[] items, int firstIndex, int secondIndex)
        {
            lock (locker)
            {
                var temp = items[firstIndex];
                items[secondIndex] = items[firstIndex];
                items[secondIndex] = temp;
            }
        }
    }
}
