using System;
using System.Collections.Generic;

namespace CollectionsWithoutWings.Sorting
{
    public static class BubbleSortExtension
    {
        public static void BubbleSort<T>(this System.Collections.Generic.IList<T> list) where T : IComparable<T>
        {
            BubbleSortHelper(list, null);
        }

        public static void BubbleSort<T>(this System.Collections.Generic.IList<T> list, IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            BubbleSortHelper(list, comparer);
        }

        private static void BubbleSortHelper<T>(this System.Collections.Generic.IList<T> list, IComparer<T> comparer)
        {
            var n = list.Count;
            var swapped = true;

            while (swapped)
            {
                swapped = false;

                for (var i = 1; i < n; i++)
                {
                    if (comparer == null ? ((IComparable<T>)list[i - 1]).CompareTo(list[i]) == 1 : comparer.Compare(list[i - 1], list[i]) == 1)
                    {
                        Swap(list, i - 1, i);
                        swapped = true;
                    }
                }
            }
        }

        private static void Swap<T>(IList<T> list, int v, int i)
        {
            var tmp = list[v];
            list[v] = list[i];
            list[i] = tmp;
        }
    }
}
