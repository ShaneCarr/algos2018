using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace binarySearch2
{
    // classic sorted list.
    [TestClass]
    public class binarySearch
    {
        [TestMethod]
        public void squareRoot()
        {
            int[] values = { 1, 2, 3, 4, 5 };
            int key = 3;
            var result = BinarySearch.Search(values, key, values.Length -1, 0);
            Assert.AreEqual(key, result);
        }


    }

    public class BinarySearch
    {
        public static int Search(int[] values, int key, int high, int low)
        {

            int mid = (high + low) / 2;

            if (values[mid] == values[key])
            {
                return key;
            }

            if (mid  > key)
            {
                high = mid;
            }
            else if (mid < key)
            {
                low = mid;
            }

            // Items was not found
            else if (high == low || high < low)
            {
                return 0;
            }

            return Search(values, key, high, low);
        }


    }
}
