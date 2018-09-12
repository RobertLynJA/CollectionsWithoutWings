using System;
using Xunit;
using System.Collections.Generic;
using CollectionsWithoutWings.Sorting;


namespace CollectionsWithoutWiings.Tests.Sorting
{
    public class QuickSortExtensionTests
    {
        [Fact]
        public void QuickSortSort_Null_Exception()
        {
            var list = new int[] { };

            Assert.Throws<ArgumentNullException>(() => list.QuickSort(null));
        }

        [Fact]
        public void QuickSort_List_SortedList()
        {
            foreach (var lst in Data.TestLists.Lists)
            {
                var expectedList = new List<int>(lst);
                expectedList.Sort();

                var testList = new List<int>(lst);
                testList.QuickSort();

                Assert.Equal(expectedList, testList);
            }
        }

        [Fact]
        public void QuickSort_ListComparer_SortedList()
        {
            foreach (var lst in Data.TestLists.Lists)
            {
                var expectedList = new List<int>(lst);
                expectedList.Sort();

                var testList = new List<int>(lst);
                testList.QuickSort(new Data.IntComparer());

                Assert.Equal(expectedList, testList);
            }
        }
    }
}
