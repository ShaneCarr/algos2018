using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        const char startP = '[';
        const char endP = '[';

        static void Main(string[] args)
        {

            string s = "2[lg2[p]]g2[a]";
            /*
            lgpplgppgaa

            3 f(x) g
                [lg2[p]]
                    lg 2(fx)
                          p
*/
            char[] encoded = s.ToArray();
          
            
            int parenCount = 0;
            //for(int i =0; i<encodedArray.Length; i++)
            //{
            //    string cur = encodedArray[i];

            //    if(cur == startP)
            //    {
            //        parenCount++;
            //    }

            //    if (cur == endP)
            //    {
            //        parenCount--;
            //    }

            //    // collecting for child call
            //    if(parenCount > 0)
            //    {

            //    }

            //    if(parenCount == 0)
            //    {
            //        // if no paren return
            //    }
            //}

            decodeEncoded(0, encoded.Length - 1, encoded);

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        public static string decodeEncoded(int start, int end, char[] encoded)
        {
            bool isP = false;
            
            int parenCount = start;
            int sSubString =start;
            int eSubString;
            string result = "";
            string expandEncoded = "";
            for (int currIndex = start; currIndex <= end; currIndex++)
            {
                expandEncoded = "";

                char currVal = encoded[currIndex];

                // [ (need to recurse)
                if (currVal == startP)
                {
                    // [a] point to a. after first [
                    if (!isP)
                    {
                        sSubString = currIndex++;
                    }

                    isP = true;
                    parenCount++;
                }

                if (currVal == endP)
                {
                    parenCount--;
                }

                // existing [... ] 
                if (parenCount == 0 && isP)
                {
                    // [a] point to a. after last]
                    eSubString = currIndex--;

                    // if no paren return
                    expandEncoded = decodeEncoded(sSubString, eSubString, encoded);
                    isP = false;
                }

                // collect characters
                if (isP == false && currVal != startP || currVal != endP)
                {
                    result += currVal.ToString();
                }


                // points to [
                int digitIndex = sSubString--;

                // points to first number, maybe
                digitIndex = digitIndex--;
                

                string encodeDigits = "";

                int sdigit = start;
                while (char.IsDigit(encoded[digitIndex]) && digitIndex >= start)
                {
                    encodeDigits.Insert(0, encoded[digitIndex].ToString());
                    digitIndex--;
                }
               
                // clone result.
                for(int digit =0; digit < Convert.ToInt32(encodeDigits); digit++)
                {
                    expandEncoded += expandEncoded;
                }
            }

        }

    }
}
