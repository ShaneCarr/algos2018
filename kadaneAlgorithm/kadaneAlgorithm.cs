using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kadaneAlgorithm
{
    [TestClass]
    public class kadaneAlgorithm
    {
        [TestMethod]
        public void kadaneAlgorithmPostive()
        {
            int testCases = 2;
            int case1ArraySize = 3;
            int[] case1Array = { 1, 2, 3 };
            Assert.AreEqual(kadaneAlgorithmExecutor(case1Array), 6);
        }

        [TestMethod]
        public void kadaneAlgorithmtest()
        {
            int testCases = 2;
            int case2ArraySize = 4;
            int[] case2Array = { -1, -2, -3, -4 };
            Assert.AreEqual(kadaneAlgorithmExecutor(case2Array), -1);
        }

        [TestMethod]
        public void kadaneAlgorithmPolarityChangeNegative()
        {
            int[] case2Array = { -1,-1, 2, 4, -4 };
            Assert.AreEqual(kadaneAlgorithmExecutor(case2Array), 6);
        }

        [TestMethod]
        public void kadaneAlgorithmPolarityChangeNegativeContigious()
        {
            // from any point "current" i need to know if 
            int[] case2Array = { -1, 100, 1, -2, 10, -4,-40, 110 };
            Assert.AreEqual(kadaneAlgorithmExecutor(case2Array), 175);
        }

        public int kadaneAlgorithmExecutor(int[] arrayToFindMaxSequence)
        {
            int currentMax = -999;
            for (int i = 0; i < arrayToFindMaxSequence.Length; i++)
            {
                currentMax = Math.Max(currentMax, arrayToFindMaxSequence[i]);

             
                int currentArrayTotal = 0;

                // store the max value
                int largestArraySumFound = -999;

                // find largest array after current, add it if it results in a number
                // that increase size add it. 
                for (int k = i+1; k < arrayToFindMaxSequence.Length; k++)
                {
                    currentArrayTotal += arrayToFindMaxSequence[k];
                    largestArraySumFound = Math.Max(largestArraySumFound, currentArrayTotal);

                    if (currentArrayTotal > largestArraySumFound)
                    {
                        largestArraySumFound += currentArrayTotal;
                    }
                    
                }

                currentMax = Math.Max(currentMax, largestArraySumFound + arrayToFindMaxSequence[i]);
            }

            return currentMax;
        }
    }
}
