using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsWithoutWiings.Tests.Sorting.Data
{
    class TestLists
    {
        static TestLists()
        {
            List<IList<int>> lists = new List<IList<int>>();
            lists.Add(new int[] { });
            lists.Add(new int[] { 1 });
            lists.Add(new int[] { 2, 1 });
            lists.Add(new int[] { 1, 2 });
            lists.Add(new int[] { 2, 1, 5, 4, 7, 9, 3, 6, 10, 8 });

            Lists = lists;
        }

        public static IEnumerable<IList<int>> Lists;

    }

    class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return 1;
            if (x < y) return -1;
            return 0;
        }
    }
}
