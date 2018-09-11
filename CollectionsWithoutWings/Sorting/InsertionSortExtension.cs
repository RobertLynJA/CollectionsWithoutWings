using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsWithoutWings.Sorting
{
    public static class InsertionSortExtension
    {
        public static void InsertionSort<T>(this IList<T> list) where T : IComparable<T>
        {
            InsertionSortHelper(list, null);
        }

        public static void InsertionSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            InsertionSortHelper(list, comparer);
        }

        private static void InsertionSortHelper<T>(this IList<T> list, IComparer<T> comparer)
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

            var i = 1;

            while (i < list.Count)
            {
                var x = list[i];
                var j = i - 1;

                while (j >= 0 && compareFunction(list[j], x) == 1)
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }

                list[j + 1] = x;
                i = i + 1;
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