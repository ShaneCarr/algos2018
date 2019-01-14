using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algos
{
    [TestClass]
    public class nextgreatestNumberInArray
    {
        [TestMethod]
        public void nextgreatestNumberInArrayMidTest_four()
        {
            int testCases = 1;
            int size = 5;
            int[] caseArray = { 1, 2, 3, 5 };

            var value = findMisingElementBetweenConsequetiveIntegers(caseArray);
            
            Assert.AreEqual(4, value);
        }

        [TestMethod]
        public void nextgreatestNumberInArrayEnd_zero()
        {
            int testCases = 1;
            int size = 5;
            int[] caseArray = { 1, 2, 3, 4 };

            var value = findMisingElementBetweenConsequetiveIntegers(caseArray);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void nextgreatestNumberInArrayEnd_One()
        {
            int testCases = 1;
            int size = 5;
            int[] caseArray = { 2, 3, 4, 5 };

            var value = findMisingElementBetweenConsequetiveIntegers(caseArray);

            Assert.AreEqual(1, value);
        }


        [TestMethod]
        public void nextgreatestNumberInArrayEnd_Duplicates()
        {
            int testCases = 1;
            int size = 5;
            int[] caseArray = { 2, 3, 4, 4 };

            var value = findMisingElementBetweenConsequetiveIntegers(caseArray);

            Assert.AreEqual(1, value);
        }

        [TestMethod]
        public void nextgreatestNumberInArrayEnd_SignChangeStart()
        {
            int testCases = 1;
            int size = 5;
            int[] caseArray = { 0, 1, 2, 3 };

            var value = findMisingElementBetweenConsequetiveIntegers(caseArray);

            Assert.AreEqual(-1, value);
        }

        [TestMethod]
        public void nextgreatestNumberInArrayEnd_SignChangeStartMid()
        {
            int testCases = 1;
            int size = 6;
            int[] caseArray = { -1, 0,1, 2, 3 };

            var value = findMisingElementBetweenConsequetiveIntegers(caseArray);

            Assert.AreEqual(-2, value);
        }

        [TestMethod]
        public void nextgreatestNumberInArrayEnd_SignChangeMidMid()
        {
            int testCases = 1;
            int size = 7;
            int[] caseArray = { -3, -2, -1, 1, 1, 2};

            var value = findMisingElementBetweenConsequetiveIntegers(caseArray);

            Assert.AreEqual(0, value);
        }

        private int findMisingElementBetweenConsequetiveIntegers(int[] caseArray)
        {
            if (caseArray.Length == 0)
            {
                throw new ArgumentException();
            }

            if (caseArray.Length == 1)
            {
                return caseArray[0];
            }

            for (int i = 0; i < caseArray.Length - 1; i++)
            {
                int k = Math.Abs(caseArray[i] - caseArray[i+1]);

                if(k > 1)
                {
                    return caseArray[i] + 1;
                }
            }

            // sign change
            return caseArray[0] - 1;
        }
    }
}
