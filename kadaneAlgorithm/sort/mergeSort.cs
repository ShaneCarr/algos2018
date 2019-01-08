using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algos.sort
{
    [TestClass]
    public class MergeSort
    {
        [TestMethod]
        public void testMergeSort()
        {
            int[] a = { 0, 2, 1, 2, 0 };
            int[] b = new int[5];

            mergeSorts(a, 0, a.Length, b);
            Assert.AreEqual(0, a[0]);
            Assert.AreEqual(0, a[1]);
            Assert.AreEqual(1, a[2]);
            Assert.AreEqual(2, a[3]);
            Assert.AreEqual(2, a[4]);
        }

        public static void mergeSorts(int[] a, int start, int end, int[] b)
        {
            if(a.Length < 2)
            {
                return;
            }

            int middle = a.Length / 2;

            // first split:

            // split left
            mergeSorts(a, start, middle, b);

            // split right
            mergeSorts(a, middle + 1, end, b);

            // merge 
            merges(a, start, middle, end, b);

        }

        public static void merges(int [] a, int start, int middle, int end, int[] b)
        {
            int leftPtr = start;
            int rightPtr = middle;

            // go though each iem in array. 
            for(int k = start; k < end; k++)
            {
                // while there are items to consume in left. 
                // put in left if there are no items from the right
                // or the left is smaller
                if (leftPtr < middle && (rightPtr >= end || a[leftPtr] <= b[rightPtr]))
                {
                    b[k] = a[leftPtr];
                    leftPtr++;
                }
                else
                {
                    // otherwise put item from right right.
                    b[k] = a[rightPtr];
                    rightPtr++;
                }
            }
        }

        ////public copyAToBByIndex(int[] a, int[] b, int start, int end)
        ////{
        ////    for(int i =start; i < end; i++)
        ////    {
        ////        b[i] = a[i];
        ////    }
        ////}
    }
}