using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordHelper
{
    internal static class CalcHelper
    {

        public static List<string> GetArrayPermutations(char[] list)
        {
            // step 1, create a master list for your words
                List<string> masterList = new List<string>();

            // step 2 - save the length of the letter list

            int length = list.Length - 1; //Adjusting for 0-based array

            // step 3 - get the permutations
            masterList = GetCharacterPermutations(masterList, list, 0, length);
            
            // step 4 - return the list
            return masterList;
        }

        public static List<string> GetArrayPermutations(string listStr)
        {
            char[] list = listStr.ToCharArray();
            return GetArrayPermutations(list);
        }

        private static List<string> GetCharacterPermutations(List<string> masterList, char[] list, int start, int end)
        {
         
          //we've reached the end of our recursion, and have our permutation
            
            if (start == end)
            {
               //step 1 - take each substring of 1, 2, ... up to N characters
                
                string result = string.Join("", list.ToArray());
                Debug.WriteLine("result is: " + result);


                //step 2 (inside a loop) - if the substring is not already in our master list, we'll add it

                for (int i = start; i <= end; i++)
                {

                    //masterList.Contains(result.Substring(0,i+1)));
                    if (!masterList.Contains(result.Substring(0, i + 1)))
                    {
                        Debug.WriteLine(result.Substring(0, i + 1));
                        masterList.Add(result.Substring(0, i + 1));
                    }
                }


            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    //step 3 - swap another pair of characters until we swap them all
                        Swap(ref list[start], ref list[i]);

                    //step 4 - get the permutations for the new pair of letters
                        GetCharacterPermutations(masterList, list, start + 1, end);

                    //step 5 - swap them back before moving to the next sequence/swap
                        Swap(ref list[start], ref list[i]);
                }
                
            }
            return masterList; // this is our final list
        }

        private static void Swap(ref char a, ref char b)
        {
            // this is a fast swap using bitwise operators
            if (a == b) return;
            // this is kind of sneaky
            // we calculate the XOR between the two numbers, store in a
            a ^= b;
            // then apply that XOR to b generate the original number a, b is now a
            b ^= a;
            // then apply that XOR to a to generate the original number b, a is now b
            a ^= b;
        }
    }
}
