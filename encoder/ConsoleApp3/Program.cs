using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        

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

           // decodeEncoded(0, encoded.Length - 1, encoded);

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

    }
}
