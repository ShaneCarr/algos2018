using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testBase()
        {
            string input = "abc10[a]";
            string outputExpected    = "abcaaaaaaaaaa";

            string outputActual = decodeEncoded(0, input.Length -1, input.ToCharArray());

            Assert.AreEqual(outputExpected, outputActual);
        }


        public static string decodeEncoded(int start, int end, char[] encoded)
        {
            //if(start == end)
            //{
            //    return string.Empty;
            //}
            
            // special brace character
            const char sP = '[';
            const char eP = ']';
            string timesToDuplicate = "";
            // currently in between startP and endP
            bool inBracketCollecting = false;

            int parenCount = 0;
            int sInBracketSubstring = 0;
            int eInBracketSubstring = 0;
            string result = "";
            string expandEncoded = "";
            for (int currIndex = start; currIndex <= end; currIndex++)
            {
                expandEncoded = "";

                char cVal = encoded[currIndex];

                // [ (need to recurse) this string so collecting
                if (cVal == sP)
                {
                    // [a] point to a. after FIRST [
                    if (!inBracketCollecting)
                    {
                        sInBracketSubstring = currIndex + 1;
                        inBracketCollecting = true;
                    }

                    parenCount++;
                }

                if (cVal == eP && inBracketCollecting)
                {
                    parenCount--;

                    // existing [<content>] 
                    if (parenCount == 0)
                    {
                        // [a] point to a. after last]
                        eInBracketSubstring = currIndex - 1;

                        // encoded => <content> the indexs are first and last of same.
                        expandEncoded = decodeEncoded(sInBracketSubstring, eInBracketSubstring, encoded);

                        int encodeTimes = 0; //GetNumberOfTimesToDup(encoded, sInBracketSubstring, start);
                        if(!string.IsNullOrWhiteSpace(timesToDuplicate))
                        {
                            encodeTimes = Convert.ToInt32(timesToDuplicate);
                        }

                        // clone result in example above this would be 10. print the a 10 times
                        for (int digit = 0; digit < Convert.ToInt32(encodeTimes); digit++)
                        {
                            result = result + expandEncoded;
                        }

                        timesToDuplicate = "";
                        inBracketCollecting = false;
                    }
                }
                  
                // collect characters from no collecting to pass part
                // need to remove the numbers
                if (!inBracketCollecting && cVal != sP && cVal != eP)
                {
                    bool skip = false;

                    // don't include the numbers that are used for encoding.
                    if (char.IsDigit(cVal))
                    {
                        int lookAhead = currIndex;

                        // while there are a string of numbers up to the point of a sP: 29[ the (2; current vale should be skipped)
                        while (char.IsDigit(encoded[lookAhead]))
                        {
                            timesToDuplicate = timesToDuplicate + encoded[lookAhead];
                            lookAhead++;
                        }

                        // all numbers up to the sp.
                        if(encoded[lookAhead] == sP)
                        {
                            skip = true;

                            // keep for loop adds one to index
                            currIndex = lookAhead -1;
                        }
                    }

                    if (!skip)
                    {
                        result += cVal.ToString();
                    }
                }
            }

            return result;
        }

        private static int GetNumberOfTimesToDup(char[] encoded, int sInBracketSubstring, int start)
        {
            // points to [, go back one to number or character.
            int digitIndex = sInBracketSubstring - 1;

            // points to first number, maybe, assume could be a string too then do nothing. 
            digitIndex = digitIndex--;
            string encodeDigits = "";

            while (char.IsDigit(encoded[digitIndex]) && digitIndex >= start)
            {
                //abc10[a]
                //0
                //10
                // then stop
                encodeDigits.Insert(0, encoded[digitIndex].ToString());
                digitIndex--;
            }

            return Convert.ToInt32(encodeDigits);
        }
    }
}
