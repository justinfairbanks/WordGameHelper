using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WordHelper
{
    public partial class frmMain : Form
    {

    /* DONE */  // TODO #1, add the following controls at a minimum:
                    // 4 textboxes with lables
                    // 4 numeric updown controls with labels
                    // 2 status lables
                    // one checkbox
                    // one button
                    // either 1) multiline textbox or 2) another list

        static List<string> biggestList = new List<string>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // TODO #2 - reinitialize biggestList, your input textbox
            biggestList.Clear();

            // TODO #3 - just for clarity sake, make sure all user inputs are uppercase
            string tempInput = txtInput.Text.ToUpper(); //Reads text box (in all caps) to tempInput string


            // TODO #4 - you need to convert the input from a string to a character array
            char[] arr = tempInput.ToCharArray(); //copies character by character into array

            // then get all permutations

            GetArrayPerutations(arr);




            // TODO #5 - now add some tests, first remove any items not equal to the requested word length
            // if any of the character placements are used, delete unqualified entries
            // note that you will need to loop through all characters
            // here is some starter code to help



            /*
            if (udNumChars.Value > 0)
            {
                // remove all list items whose length is not equal to specified
                for (int i = biggestList.Count - 1; i >= 0; i--)
                {
                }
            }
            this.lblStatus.Text = "Removing specified combinations";
            this.Refresh();
            */





            // TODO #7 - for this next part you will ensure that if the user wants to restricts
            // words to those with certain letters in certain locations, they can do it
            // check for the 3 letter options
            // here is some code to help you get started
            // test #1




            /*
            if (txtLetter.Text != string.Empty && udLetterAtPos.Value > 0)
            {
                // remove all list items whose letter at position specified is not the letter specified
                for (int i = biggestList.Count - 1; i >= 0; i--)
                {
                }

            }
            // test #2
            // test #3
            this.lblStatus.Text = "Spell checking...";
            this.Refresh();
            */




            // TODO #6 - see whether or not any given word is spelled properly (i.e. is in the dictionary)
            // if not, remove it



            // TODO #7 - create a new dictionary object
            // but first you need to assign the dictionary file's path
            // here's an example
            //oDict.DictionaryFile = @"C:\Users\Kevin\source\repos\WordHelper\packages\NetSpell.2.1.7\dic\en-US.dic";
            // however, you need to make this portable, so the dictionary file should be a relative path
            // Can you figure out how to do it?




            // TODO #8 - now create the spell checker




            // TODO #9 - iterate over the remaining list items
            // some code to get you started


            /*
            for (int i = biggestList.Count - 1; i >= 0; i--)
            {
                // get a word
                // get the dictionary for spell checking
                // test the word
                if (!oSpell.TestWord(wordToCheck))
                {
                    //Word does not exist in dictionary - remove it if specified
                }
            }
            */



            // TODO #10 - sort the remaining words to make it easy to scan for the user
            // load list or textbox with words
            // status code


            /*
            this.lblStatus.Text = "Completed";
            this.Refresh();
            */


        }
        private static void GetCharacterPermutations(char[] list, int k, int m)
        {
            // code to get you started
            /*
            // if we've reached the end
            if (k == m)
            {

                // TODO #11 - combine the array into a long string
                // do this by converting the array into a enumerable object
                // then join into a string



                // TODO #12 - scan the whole string in increasingly larger chunks
                for (int i = 0; i < result.Length; i++)
                {
                    // add anything you don't find into the overall master list
                    // this will generate a huge list of this particular permutation
                }
            }
            else
            {
                // otheriwse for each little snippet, generate a permutation
                for (int i = k; i <= m; i++)
                {
                    // build an array of all possibilities
                    Swap(ref list[k], ref list[i]);
                    GetCharacterPermutations(list, k + 1, m);   // recursion, sweet!
                    Swap(ref list[k], ref list[i]);
                }
            }
            */
        }
        public static void GetArrayPerutations(char[] list)
        {
            int x = list.Length - 1;
            GetCharacterPermutations(list, 0, x);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
