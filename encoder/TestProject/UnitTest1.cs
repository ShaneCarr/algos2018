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

            string outputActual = decodeEncoded(0, input.Length, input.ToCharArray());

            Assert.AreEqual(outputExpected, outputActual);
        }


        public static string decodeEncoded(int start, int end, char[] encoded)
        {
            if(start == end)
            {
                return string.Empty;
            }

            // special brace character
            const char sP = '[';
            const char eP = ']';

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
                        sInBracketSubstring = currIndex++;
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
                        eInBracketSubstring = currIndex--;

                        // encoded => <content> the indexs are first and last of same.
                        expandEncoded = decodeEncoded(sInBracketSubstring, eInBracketSubstring, encoded);

                        int encodeTimes = GetNumberOfTimesToDup(encoded, sInBracketSubstring, start);
                        

                        // clone result in example above this would be 10. print the a 10 times
                        for (int digit = 0; digit < Convert.ToInt32(encodeTimes); digit++)
                        {
                            result = result + expandEncoded;
                        }

                        inBracketCollecting = false;
                    }
                }

                // collect characters from no collecting to pass part
                // need to remove the numbers
                if (!inBracketCollecting && cVal != sP && cVal != eP)
                {
                    // exclude digit[
                    if (char.IsDigit(cVal))
                    {
                        bool skip = false;
                        int lookAhead = currIndex;
                        while (char.IsDigit(encoded[lookAhead]))
                        {
                            lookAhead++;
                        }

                        if(encoded[lookAhead] == sP)
                        {
                            skip = true;
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
