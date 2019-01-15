using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace peakfinding
{
    /// <summary>
    /// peak is an item where 
    /// bigger than left or right
    /// if end and bigger than left than peak
    /// if beginnign and bigger than right than peak
    /// if all same peak (
    /// 
    /// values don't need to be sorted.
    /// 
    /// inspriation from this slide https://courses.csail.mit.edu/6.006/spring11/lectures/lec02.pdf
    /// slide is useful because nice little refresh on complexity 
    /// </summary>
    [TestClass]
    public class binarySearch
    {
        [TestMethod]
        public void peakMine()
        {
            // only 9 is peak
            int[] values = { 1, 9, 7, 6, 5 };
            var result = BinarySearch.FindPeak(values, values.Length - 1, 0);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void peakFromOnlineExample()
        {
            // only 9 is peak
            int[] values = { 1, 2, 6, 5, 3, 7, 4};
            var result = BinarySearch.FindPeak(values, values.Length - 1, 0);
            Assert.AreEqual(6, result);
        }
    }

    public class BinarySearch
    {
        public static int FindPeak(int[] values, int high, int low)
        {
            if (values.Length == 0)
            {
                // throw?
                return 0;
            }

            // Items was not found
            if (high <= low)
            {
                return 0;
            }

            int mid = (high + low) / 2;

            // possible peaks.
            if (values.Length == 1)
            {
                return values[0];
            }
            else if ( mid == 0 && values[mid] > values[mid + 1]
                // beginning; no erro already bigger than one
                ||

                // end no erro already bigger than one
                mid == values.Length - 1 && values[mid] >= values[mid - 1] ||

                // in array
                (mid != values.Length - 1 && values[mid] >= values[mid + 1] ) && (mid != 0 && values[mid] >= values[mid - 1]))
            {
                return values[mid];
            }

            
            // right is bigger.
            if (values[mid] < values[mid +1])
            {
                return FindPeak(values, high, mid);
            }

            return FindPeak(values, mid, low);
        }
    }
}
