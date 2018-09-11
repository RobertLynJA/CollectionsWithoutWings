using System;
using Xunit;
using System.Collections.Generic;
using CollectionsWithoutWings.Sorting;


namespace CollectionsWithoutWiings.Tests.Sorting
{
    public class InsertionSortExtensionTests
    {
        [Fact]
        public void InsertionSort_Null_Exception()
        {
            var list = new int[] { };

            Assert.Throws<ArgumentNullException>(() => list.InsertionSort(null));
        }

        [Fact]
        public void InsertionSort_List_SortedList()
        {
            foreach (var lst in Data.TestLists.Lists)
            {
                var expectedList = new List<int>(lst);
                expectedList.Sort();

                var testList = new List<int>(lst);
                testList.InsertionSort();

                Assert.Equal(expectedList, testList);
                ;
            }
        }

        [Fact]
        public void InsertionSort_ListComparer_SortedList()
        {
            foreach (var lst in Data.TestLists.Lists)
            {
                var expectedList = new List<int>(lst);
                expectedList.Sort();

                var testList = new List<int>(lst);
                testList.InsertionSort(new Data.IntComparer());

                Assert.Equal(expectedList, testList);
                ;
            }
        }
    }
}
