using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algos.sort
{
    /// <summary>
    /// to do review this a bit. i liek this solution. 
    /// bounds got a litle confusing on base case, and swapping a/b is elegant. 
    /// </summary>
    [TestClass]
    public class MergeSort
    {
        [TestMethod]
        public void testMergeSort()
        {
            int[] unsorted = { 0, 2, 1, 2, 0 };
            int[] newArray = new int[5];

            Array.Copy(unsorted, newArray, unsorted.Length);


            mergeSort(unsorted, 0, unsorted.Length-1, newArray);
            Assert.AreEqual(0, newArray[0]);
            Assert.AreEqual(0, newArray[1]);
            Assert.AreEqual(1, newArray[2]);
            Assert.AreEqual(2, newArray[3]);
            Assert.AreEqual(2, newArray[4]);
        }

        public static void mergeSort(int[] b, int start, int end, int[] a)
        {
            if( end-start <=0 )
            {
                return;
            }

            int middle = (start +end) / 2;
            // 2=s,4=e = 3=m
            // first split:

            // split left
            mergeSort(a, start, middle, b);

            // split right
            mergeSort(a, middle+1, end, b);

            // merge 
            mergeArraysBounded(b, start, middle, end, a);

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

            ////int[] rightarray = new int[end - middle + 1];
            ////int[] leftarray = new int[middle - start];
            ////Array.Copy(sorted, start,leftarray, 0, middle - start);
            ////Array.Copy(sorted,  middle+1, rightarray, 0, end - middle + 1);

            // current array is start to end; . 
            for (int k = start; k <= end; k++)
            {
                // while there are items to consume in left. 
                // put left in left if there are no items from the right
                // or the left is smaller we want to take the left, otherwise we'll write the larger 
                // value later when the right ptr is empty.
                if (leftPtr <= middle && 
                    // out of right items need to take left for the rest, it is already sorted
                    (rightPtr > end 
                    // compare left and right.
                    ||  a[leftPtr] <= a[rightPtr]))
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
    }
}