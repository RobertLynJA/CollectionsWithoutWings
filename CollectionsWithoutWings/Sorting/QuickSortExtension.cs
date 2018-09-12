using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsWithoutWings.Sorting
{
    public static class QuickSortExtension
    {
        public static void QuickSort<T>(this IList<T> list) where T : IComparable<T>
        {
            QuickSortHelper(list, null);
        }

        public static void QuickSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            QuickSortHelper(list, comparer);
        }

        private static void QuickSortHelper<T>(this IList<T> list, IComparer<T> comparer)
        {
            Func<T, T, int> compareFunction;

            if (comparer == null)
            {
                compareFunction = (x, y) => ((IComparable<T>)x).CompareTo(y);
            }
            else
            {
                compareFunction = (x, y) => comparer.Compare(x, y);
            }

            QuickSortHelper(list, 0, list.Count - 1, compareFunction);
        }

        private static void QuickSortHelper<T>(IList<T> list, int low, int high, Func<T, T, int> compareFunction)
        {
            if (low < high)
            {
                var p = PartitionHelper(list, low, high, compareFunction);
                QuickSortHelper(list, low, p, compareFunction);
                QuickSortHelper(list, p + 1, high, compareFunction);
            }
        }

        private static int PartitionHelper<T>(IList<T> list, int low, int high, Func<T, T, int> compareFunction)
        {
            var pivot = list[low];
            var i = low - 1;
            var j = high + 1;

            while (true)
            {
                do
                {
                    i = i + 1;
                } while (compareFunction(list[i], pivot) < 0);

                do
                {
                    j = j - 1;
                } while (compareFunction(list[j], pivot) > 0);

                if (i >= j)
                {
                    return j;
                }

                Swap(list, i, j);
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