using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algos.sort
{
    [TestClass]
    public class QuickSort
    {
        [TestMethod]
        public void testBaseCaseqs()
        {
            int[] a = { 0, 2, 1, 2, 0 };
            int n = 5;

            sortQuickSort(a);
            Assert.AreEqual(0, a[0]);
            Assert.AreEqual(0, a[1]);
            Assert.AreEqual(1, a[2]);
            Assert.AreEqual(2, a[3]);
            Assert.AreEqual(2, a[4]);
        }

        private static void sortQuickSort(int[] a, int start = 0, int end = -1)
        {
            if(end == -1)
            {
                end = a.Length - 1;
            }

            if(start >= end)
            {
                return;
            }

            int pivot = start + ((end - start)/2);

            int value = a[pivot];

            int currentLoc = 0;
            int searchIndex = currentLoc;
            for (int i = start; i <= end; i++)
            {
                if(a[i] < a[pivot] && i > pivot)
                {
                    a[pivot] = a[i];
                    a[i] = value;
                }
            }

            // quick sort left
            sortQuickSort(a, 0, pivot);

            // quick sort right
            sortQuickSort(a, pivot + 1, end);

        }
    }
}