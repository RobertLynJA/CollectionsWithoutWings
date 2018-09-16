using System;
using Xunit;
using System.Collections.Generic;
using CollectionsWithoutWings.Sorting;


namespace CollectionsWithoutWiings.Tests.Sorting
{
    public class MergeSortExtensionTests
    {
        [Fact]
        public void MergeSortSort_Null_Exception()
        {
            var list = new int[] { };

            Assert.Throws<ArgumentNullException>(() => list.MergeSort(null));
        }

        [Fact]
        public void MergeSort_List_SortedList()
        {
            foreach (var lst in Data.TestLists.Lists)
            {
                var expectedList = new List<int>(lst);
                expectedList.Sort();

                var testList = new List<int>(lst);
                testList.MergeSort();

                Assert.Equal(expectedList, testList);
            }
        }

        [Fact]
        public void MergeSort_ListComparer_SortedList()
        {
            foreach (var lst in Data.TestLists.Lists)
            {
                var expectedList = new List<int>(lst);
                expectedList.Sort();

                var testList = new List<int>(lst);
                testList.MergeSort(new Data.IntComparer());

                Assert.Equal(expectedList, testList);
            }
        }
    }
}
