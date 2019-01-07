using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace binarySearch
{
    [TestClass]
    public class binarySearch
    {
        [TestMethod]
        public void squareRoot()
        {
            BinarySearch.Number = 64;
            var result = BinarySearch.SquareRoot(64);
            Assert.AreEqual(8, result);
        }


    }

    public class BinarySearch
    {
        public static int Number; 

        public static int SquareRoot(int high, int low = 0)
        {
            
            int mid = high / 2;

            if(mid * mid == Number)
            {
                return mid;
            }

            if (mid * mid > Number)
            {
                high = mid;
            }
            else if (mid * mid < Number)
            {
                low = mid;
            }
            else if(high == low || high < low)
            {
                return 0;
            }

            return SquareRoot(high, low);
        }


    }
}
