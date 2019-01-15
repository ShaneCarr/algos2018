using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace peakfinding2d
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
    /// 
    /// really neat example of divide and conquer at the above link. 
    /// 
    /// This is the only rule. 
    /// Want an entry not smaller than its (up to) 4 neighbors:
    /// 
    /// </summary>
    [TestClass]
    public class peakFinding2d
    {
        [TestMethod]
        public void peakMine()
        {
            ////// 3x3
            ////// Three-dimensional array.
            ////int[,] array = new int[,]
            ////{
            ////    {0, 1, 99},
            ////    {4, 10, 101},
            ////    {4, 10, 101},
            ////};
            // .
            int[,] values = new int[3, 4] {
                {0,1,2,3},
                {11,9,10,8},
                {4, 5,6 ,7}};

            // 11, 10
            
            int mColumn = 4;
            int mRow = 3

                // todo,  
                // 1 start at those two indexes
                // run binary 1-d to get a peak. of column
                // if not peak of current run run again this time 
                // if max  (row of current column) is less than the item to the left, move left
                // otherwise we move right (it would have to have been teh right one that was bigger other wise this woudl have been a max.

            var result = peakFinding2d.FindPeak(values, values.Length - 1, 0);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void peakFromOnlineExample()
        {
            // only 9 is peak
            int[] values = { 1, 2, 6, 5, 3, 7, 4 };
            var result = peakFinding2d.FindPeak(values, values.Length - 1, 0);
            Assert.AreEqual(6, result);
        }
    }

    public class peakFinding2d
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
            else if (mid == 0 && values[mid] > values[mid + 1]
                // beginning; no erro already bigger than one
                ||

                // end no erro already bigger than one
                mid == values.Length - 1 && values[mid] >= values[mid - 1] ||

                // in array
                (mid != values.Length - 1 && values[mid] >= values[mid + 1]) && (mid != 0 && values[mid] >= values[mid - 1]))
            {
                return values[mid];
            }


            // right is bigger.
            if (values[mid] < values[mid + 1])
            {
                return FindPeak(values, high, mid);
            }

            return FindPeak(values, mid, low);
        }
    }
}
