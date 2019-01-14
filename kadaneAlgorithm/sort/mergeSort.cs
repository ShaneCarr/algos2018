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

            Array.Copy(a, b, a.Length);

            mergeSort(a, 0, a.Length-1, b);
            Assert.AreEqual(0, b[0]);
            Assert.AreEqual(0, b[1]);
            Assert.AreEqual(1, b[2]);
            Assert.AreEqual(2, b[3]);
            Assert.AreEqual(2, b[4]);
        }

        public static void mergeSort(int[] a, int start, int end, int[] b)
        {
            if( end-start < 2)
            {
                return;
            }

            int middle = (start +end) / 2;
            // 2=s,4=e = 3=m
            // first split:

            // split left
            mergeSort(a, start, middle, b);

            // split right
            mergeSort(a, middle, end, b);

            // merge 
            mergeArraysBounded(a, start, middle, end, b);

        }

        /// <summary>
        /// merges two arrays defined by bounds start middle and middle end.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="start"></param>
        /// <param name="middle"></param>
        /// <param name="end"></param>
        /// <param name="b"></param>
        public static void mergeArraysBounded(int [] a, int start, int middle, int end, int[] b)
        {
            int leftPtr = start;
            int rightPtr = middle+1;

            // go though each iem in array. 
            for(int k = start; k <= end; k++)
            {
                // while there are items to consume in left. 
                // put left in left if there are no items from the right
                // or the left is smaller we want to take the left, otherwise we'll write the larger 
                // value later when the right ptr is empty.
                if (leftPtr < middle && (rightPtr > end || a[leftPtr] <= a[rightPtr]))
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