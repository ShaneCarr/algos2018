using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algos.sort
{
    [TestClass]
    public class n012Nominal
    {
        [TestMethod]
        public void testBaseCase()
        {
            int[] a = { 0, 2, 1, 2, 0 };
            int n = 5;

            SortBubble(a);
            Assert.AreEqual(0, a[0]);
            Assert.AreEqual(0, a[1]);
            Assert.AreEqual(1, a[2]);
            Assert.AreEqual(2, a[3]);
            Assert.AreEqual(2, a[4]);
        }

        private static void SortBubble(int[] a)
        {
            int currentLoc = 0;
            int searchIndex = currentLoc;
            for (int i = 0; i < a.Length - 1; i++)
            {

                for (int s = i + 1; s < a.Length; s++)
                {
                    if (a[i] > a[s])
                    {
                        int temp = a[i];
                        a[i] = a[s];
                        a[s] = temp;
                    }
                }
            }
        }
    }
}