using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionsWithoutWings.Sorting
{
    public static class MergeSortExtension
    {
        public static void MergeSort<T>(this IList<T> list) where T : IComparable<T>
        {
            MergeSortHelper(list, null);
        }

        public static void MergeSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            MergeSortHelper(list, comparer);
        }

        private static void MergeSortHelper<T>(this IList<T> list, IComparer<T> comparer)
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

            if (list.Count == 0) return;

            var result = MergeSortHelper(list, 0, list.Count - 1, compareFunction);
            list.Clear();
            result.ToList().ForEach(i => list.Add(i));
        }

        private static IList<T> MergeSortHelper<T>(IList<T> list, int low, int high, Func<T, T, int> compareFunction)
        {
            if (low == high)
            {
                return new T[] { list[low] };
            }

            var mid = (low + high) / 2;

            var left = MergeSortHelper(list, low, mid, compareFunction);
            var right = MergeSortHelper(list, mid + 1, high, compareFunction);

            return Merge(left, right, compareFunction);
        }

        private static IList<T> Merge<T>(IList<T> left, IList<T> right, Func<T, T, int> compareFunction)
        {
            var result = new List<T>();

            var i = 0;
            var j = 0;

            while (i < left.Count() && j < right.Count)
            {
                if (compareFunction(left[i], right[j]) < 0)
                {
                    result.Add(left[i++]);
                }
                else
                {
                    result.Add(right[j++]);
                }
            }

            if (i < left.Count())
            {
                result.AddRange(left.Skip(i));
            }

            if (j < right.Count())
            {
                result.AddRange(right.Skip(j));
            }

            return result;
        }

        private static void Swap<T>(IList<T> list, int v, int i)
        {
            var tmp = list[v];
            list[v] = list[i];
            list[i] = tmp;
        }
    }
}