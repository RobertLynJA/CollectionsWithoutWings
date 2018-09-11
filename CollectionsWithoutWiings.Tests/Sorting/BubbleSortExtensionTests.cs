using System;
using Xunit;
using System.Collections.Generic;
using CollectionsWithoutWings.Sorting;


namespace CollectionsWithoutWiings.Tests.Sorting
{
    public class BubbleSortExtensionTests
    {
        [Fact]
        public void BubbleSort_Null_Exception()
        {
            var list = new int[] { };

            Assert.Throws<ArgumentNullException>(() => list.BubbleSort(null));
        }

        [Fact]
        public void BubbleSort_List_SortedList()
        {
            foreach (var lst in Data.TestLists.Lists)
            {
                var expectedList = new List<int>(lst);
                expectedList.Sort();

                var testList = new List<int>(lst);
                testList.BubbleSort();

                Assert.Equal(expectedList, testList);
            }
        }

        [Fact]
        public void BubbleSort_ListComparer_SortedList()
        {
            foreach (var lst in Data.TestLists.Lists)
            {
                var expectedList = new List<int>(lst);
                expectedList.Sort();

                var testList = new List<int>(lst);
                testList.BubbleSort(new Data.IntComparer());

                Assert.Equal(expectedList, testList);
            }
        }
    }
}
