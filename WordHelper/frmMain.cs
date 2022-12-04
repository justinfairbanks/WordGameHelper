using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Numerics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;
using System.Reflection;

namespace WordHelper
{
    public partial class frmMain : Form
    {

    // TODO #1, add controls

        static List<string> biggestList = new List<string>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
           
            List<String> output = new List<String>(); //List with all combinations       

        // TODO #2 - reinitialize biggestList, your input textbox
            biggestList.Clear();

        // TODO #3 - just for clarity sake, make sure all user inputs are uppercase
            string tempInput = txtInput.Text.ToUpper(); //Reads text box (in all caps) to tempInput string


        // TODO #4 - you need to convert the input from a string to a character array
            char[] arr = tempInput.ToCharArray(); //copies character by character into array

    
    /* All of the words Permuations */

            output = GetArrayPerutations(arr); //All the variations of the given word now stored in output



            // TODO #5 - now add some tests, first remove any items not equal to the requested word length


    /* Remove Words Outside Specified Word Length (Tab 1 Only) */

            if (tabControl1.SelectedTab == tabPage1) //If in the first tab (basic word entry)
            {
                if (numLength.Value > 0)
                {
                    var length = numLength.Value;
                    int wordLength = Convert.ToInt32(length);
                    int inputSize = tempInput.Length;

                    wordLength = inputSize - wordLength;

                    // remove all list items whose length is not equal to specified
                    for (int i = output.Count - 1; i >= 0; i--)
                    {
                        if (numLength.Value > inputSize)
                        {
                            MessageBox.Show("Please make specified word length less than input word size");
                            break;
                        }
                        if (numLength.Value == inputSize)
                        {
                            break;
                        }
                        else
                            output[i] = output[i].Remove(output[i].Length - wordLength);
                    }
                }
            }
            

            this.lblStatus.Text = "Removing specified combinations";
            this.Refresh();


    /* Remove Duplicate Words in List */
            output = output.Distinct().ToList();

            // TODO #7 - for this next part you will ensure that if the user wants to restricts


        /* Basic Word Tab */

            if (tabControl1.SelectedTab == tabPage1) //If in the first tab (basic word entry)
            {

                /* Temp Vars */
                bool delete = false;
                int position = 0;


                /* Checks letters at specific positions */

                if (txtLetter.Text != string.Empty && numPos1.Value > 0)
                {
                    string str = txtLetter.Text.ToUpper();
                    char letter = char.Parse(str);

                    for (int i = output.Count - 1; i >= 0; i--)
                    {
                        delete = true;
                        position = 0;
                        // remove all list items whose letter at position specified is not the letter specified
                        foreach (char c in output[i])
                        {
                            position++;
                            if (position == numPos1.Value)
                            {
                                if (c == letter)
                                    delete = false;
                            }

                        }

                        if (delete == true)
                            output.RemoveAt(i);

                    }
                }

                position = 0;

                if (txtLetter2.Text != string.Empty && numPos2.Value > 0)
                {
                    string str = txtLetter2.Text.ToUpper();
                    var charArray = str.ToCharArray();

                    for (int i = output.Count - 1; i >= 0; i--)
                    {
                        delete = true;
                        position = 0;
                        // remove all list items whose letter at position specified is not the letter specified
                        foreach (char c in output[i])
                        {
                            position++;
                            if (position == numPos2.Value)
                            {
                                if (c == charArray[0])
                                    delete = false;
                            }

                        }

                        if (delete == true)
                            output.RemoveAt(i);

                    }
                }

                position = 0;

                if (txtLetter3.Text != string.Empty && numPos3.Value > 0)
                {
                    string str = txtLetter3.Text.ToUpper();
                    var charArray = str.ToCharArray();

                    for (int i = output.Count - 1; i >= 0; i--)
                    {
                        delete = true;
                        position = 0;
                        // remove all list items whose letter at position specified is not the letter specified
                        foreach (char c in output[i])
                        {
                            position++;
                            if (position == numPos3.Value)
                            {
                                if (c == charArray[0])
                                    delete = false;
                            }

                        }

                        if (delete == true)
                            output.RemoveAt(i);

                    }
                }
            }

        /* Wordle Tab */ 

            if (tabControl1.SelectedTab == tabPage2) //If in the second tab (wordle tab)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (grdWordle.CurrentRow.Cells[i].Style.BackColor == Color.Green) //If letter is in confirmed spot
                    {
                        grdWordle.CurrentRow.Cells[i].Style.BackColor = Color.White;
                        string confirmed = grdWordle.CurrentRow.Cells[i].Value.ToString(); //Needs to be white to read in value?
                        grdWordle.CurrentRow.Cells[i].Style.BackColor = Color.Green;
                    }

                    if (grdWordle.CurrentRow.Cells[i].Style.BackColor == Color.Yellow) //If letter is somewhere in word
                    {
                        grdWordle.CurrentRow.Cells[i].Style.BackColor = Color.White;
                        string somewhere = grdWordle.CurrentRow.Cells[i].Value.ToString();
                        grdWordle.CurrentRow.Cells[i].Style.BackColor = Color.Yellow;
                    }

                    if (grdWordle.CurrentRow.Cells[i].Style.BackColor == Color.White) //If letter is not in word
                    {
                        string delete = grdWordle.CurrentRow.Cells[i].Value.ToString();
                    }
                }
            }









            /* Compare Combinations to Dictionary */

                this.lblStatus.Text = "Spell checking...";
            this.Refresh();

            NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();

            //Debug Dictionary
            string dictPath = Directory.GetCurrentDirectory() + @"\..\..\..\packages\\Netspell.2.1.7\\dic\\en-US.dic";


            oDict.DictionaryFile = dictPath;

            oDict.Initialize();

            NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();



            for (int i = output.Count - 1; i >= 0; i--)
            {
                // get a word
                string wordToCheck = output[i];
                // get the dictionary for spell checking
                oSpell.Dictionary = oDict;
                // test the word
                if (!oSpell.TestWord(wordToCheck))
                {
                    //Word does not exist in dictionary - remove it if specified
                    if (!chkShow.Checked)
                        output.Remove(wordToCheck);

                    //IF WORD DOES NOT EXIST IN DATA BASE EITHER!!


                }
            }


            //TODO #10 - sort the remaining words to make it easy to scan for the user
            
    /* Outputs all combinations to result text box */
            
            Sort(output); //Sorts List in Alphabetical Order

            txtResult.Text = String.Join(Environment.NewLine, output); //Outputs list contents


            this.lblStatus.Text = "Completed";
            this.Refresh();
           
        }


        public void Sort<T>(IList<T> list)
        {
            List<T> tmp = new List<T>(list); //Temp List
           
            tmp.Sort();

            for (int i = 0; i < tmp.Count; i++)
            {
                list[i] = tmp[i]; //Assign items to correct pos
            }
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
        public static List<string> GetArrayPerutations(char[] list)
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
            /* Closes Program */
            Application.Exit();
        }

        /* WORDLE TAB */
        private void frmMain_Load(object sender, EventArgs e)
        {
            /* Set Columns */

            grdWordle.ColumnCount = 5;
            //dgvDub.ColumnCount = 5;

            for (int i = 0; i < 5; i++)
                grdWordle.Columns[i].Width = 50;

            /* Set Rows */

            grdWordle.RowCount = 2;
            //dgvDud.RowCount = 2;

            /* Remove Column + Row Headers */

            grdWordle.ColumnHeadersVisible = false;

            grdWordle.RowHeadersVisible = false;

            /* Create buttons for Grid */

            DataGridViewButtonCell bc = new DataGridViewButtonCell();
            DataGridViewButtonCell bc1 = new DataGridViewButtonCell();
            DataGridViewButtonCell bc2 = new DataGridViewButtonCell();
            DataGridViewButtonCell bc3 = new DataGridViewButtonCell();
            DataGridViewButtonCell bc4 = new DataGridViewButtonCell();

            /* Set bottom cells to buttons */
            grdWordle.Rows[1].Cells[0] = bc;
            grdWordle.Rows[1].Cells[1] = bc1;
            grdWordle.Rows[1].Cells[2] = bc2;
            grdWordle.Rows[1].Cells[3] = bc3;
            grdWordle.Rows[1].Cells[4] = bc4;


            /* Set the cell to a text box */

            // DataGridViewTextBoxCell tc = new DataGridViewTextBoxCell();

            grdWordle.CellClick += new DataGridViewCellEventHandler(grdWordle_CellClick);


            //RefreshWords(); /* Refreshes Lists in Databases Tab */

    /* Configure Serilog with C# */

        /* Event Logger */

            Log.Logger = new LoggerConfiguration() //New Logger config
                .MinimumLevel.Debug()
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day) //Gives file to write errors too
                .CreateLogger();

            /* Log File Located WordHelper >> bin >> Debug >> log-.txt */


            Log.Information("I have properly initialized my logger."); //Info tag message wrote to log file

        }

        private void grdWordle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* Button Pushed */

            if (e.RowIndex == grdWordle.RowCount - 1)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();

                DataGridViewCellStyle current = grdWordle.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Style;

                /* Change the color of the above cells */
                if (current.BackColor != Color.Green && current.BackColor != Color.Yellow)
                     style.BackColor = Color.Green;

                else if (current.BackColor == Color.Green)          
                    style.BackColor = Color.Yellow;

                else if (current.BackColor == Color.Yellow)
                    style.BackColor = Color.White;

                grdWordle.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Style = style;

            }
        }

        public static class DBInfo //dont have to instantiate it to use it bc it is static
        {
            public static readonly string cnString = "Data Source=CS-GP-S; Initial Catalog = OurDictionary; Integrated Security = False; User Id = wordee; Password=Let me in, please.; MultipleActiveResultSets=True";
        }


        //        /* IN DATABASE TAB */

        //        //private void btnSerilog_Click(object sender, EventArgs e)
        //        //{
        //        //    /* Button for Testing Serilog Implementation */

        //        //       /* Configure Serilog with C# */

        //        //        Log.Logger = new LoggerConfiguration() //New Logger config
        //        //            .MinimumLevel.Debug()
        //        //            .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day) //Gives file to write errors too
        //        //            .CreateLogger();

        //        //        /* Log File Located WordHelper >> bin >> Debug >> log-.txt */


        //        //        Log.Information("I have properly initialized my logger."); //Info tag message wrote to log file


        //        //        MessageBox.Show("Serilog Initialization Message Wrote to log file\nWordHelper > bin > Debug > log-.txt"); //Temp Message for explaning Process


        //        //        Log.Information("Closing Serilog at the end of the application."); //Info tag message
        //        //        Log.CloseAndFlush();
        //        //}


        //        /* Function Called from Load Form Refreshes both Good Words and Bad Words List */
        //        private void RefreshWords()
        //        {

        //            /* For Good TextBox */


        //            /* Step one */
        //            lstGood.Items.Clear();

        //            /* Create/Initialize/Configure the connection to the server */

        //            SqlConnection cn = new SqlConnection(DBInfo.cnString);

        //            //Open the connection (we live)

        //            cn.Open();


        //            //create a command to get the data you want

        //            //string sql = "SELECT word FROM dbo.Goodwords";

        //            string sql = "SELECT word FROM dbo.jfairbanks_Goodwords";
        //            //initialize the command object
        //            SqlCommand cmd = new SqlCommand(sql, cn);

        //            //configure the command to run a text query
        //            cmd.CommandType = CommandType.Text;

        //            //run a command to capture the reader object
        //            //which is a collection of rows of the underlying table
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            //iterate through all the rows in the collection

        //            while (reader.Read())
        //            {
        //                //add the word to the list

        //                lstGood.Items.Add(reader["word"].ToString());
        //            }

        //            reader.Close();




        //            /* For Deleted TextBox */


        //            /* Step one */
        //            lstBad.Items.Clear();

        //            /* Create/Initialize/Configure the connection to the server */



        //            cn = new SqlConnection(DBInfo.cnString);

        //            //Open the connection (we live)

        //            cn.Open();


        //            //create a command to get the data you want

        //            sql = "SELECT word FROM dbo.jfairbanks_Deletedwords";
        //            //initialize the command object
        //            SqlCommand cmd2 = new SqlCommand(sql, cn);

        //            //configure the command to run a text query
        //            cmd2.CommandType = CommandType.Text;

        //            //run a command to capture the reader object
        //            //which is a collection of rows of the underlying table
        //            SqlDataReader reader2 = cmd2.ExecuteReader();

        //            //iterate through all the rows in the collection

        //            while (reader2.Read())
        //            {
        //                //add the word to the list

        //                lstGood.Items.Add(reader2["word"].ToString());
        //            }

        //            reader2.Close();

        //        }

        //        private void btnAddWord_Click(object sender, EventArgs e)
        //        {
        //            if (this.txtAddWord.Text == String.Empty) return; //If nothing is in the textbox




        //            /* Exception handler logging to file defined in form load function */

        //            try
        //            {
        //                Log.Debug("Here we add a word to my Database:"); //Debug Tag Message
        //                string sql = "INSERT INTO dbo.jfairbanks_Goodwords(Word) VALUES('" + txtAddWord.Text + "')";

        //                SqlConnection cn = new SqlConnection(DBInfo.cnString);

        //                SqlCommand cmd = new SqlCommand(sql, cn);

        //                cn.Open(); //Open the connection

        //                cmd.CommandType = CommandType.Text;

        //                cmd.ExecuteNonQuery();

        //                cn.Close();

        //                RefreshWords();

        //                MessageBox.Show(txtAddWord.Text + " added!");

        //                txtAddWord.Text = ""; //Clears the add word box after word successfully added

        //            }
        //            catch (Exception ex) //Exception handler if try statement throws an error
        //            {
        //                Log.Fatal(ex, "Word could not be added to Database"); //Error logged to console tagged as 'Fatal'
        //            }
        //        }

        //        private void btnBad_Click(object sender, EventArgs e)
        //        {
        //            /* Delete from Good List and Move to Deleted List */

        //            if (lstGood.SelectedItems.Count == 0)
        //                return;

        //            string selected = lstGood.Text;

        //            lstGood.Items.Remove(selected);

        //            lstBad.Items.Add(selected);

        //            SqlConnection cn = new SqlConnection(DBInfo.cnString);

        //            cn.Open();


        //            /* Exception handler logging to file defined in form load function */

        //            try
        //            {
        //                Log.Debug("Here we move word from good list to deleted list:"); //Debug Tag Message

        //                string sql = "dbo.jfairbanks_DeleteWord";

        //                SqlCommand cmd = new SqlCommand(sql, cn);

        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("word", selected);

        //                cmd.ExecuteNonQuery();

        //                cn.Close();

        //            }
        //            catch (Exception ex) //Exception handler if try statement throws an error
        //            {
        //                Log.Fatal(ex, "Word could not be moved..."); //Error logged to console tagged as 'Fatal'
        //            }

        //        }


        //        private void btnGood_Click(object sender, EventArgs e)
        //        {
        //            /* Delete from Deleted List and Move to Good List */

        //            if (lstBad.SelectedItems.Count == 0)
        //                return;

        //            string selected = lstBad.Text;

        //            lstBad.Items.Remove(selected);

        //            lstGood.Items.Add(selected);

        //            SqlConnection cn = new SqlConnection(DBInfo.cnString);

        //            cn.Open();


        //            /* Exception handler logging to file defined in form load function */

        //            try
        //            {
        //                Log.Debug("Here we move word from bad list to good list:"); //Debug Tag Message

        //                string sql = "dbo.jfairbanks_RestoreWord";

        //                SqlCommand cmd = new SqlCommand(sql, cn);

        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("word", selected);

        //                cmd.ExecuteNonQuery();

        //                cn.Close();

        //            }
        //            catch (Exception ex) //Exception handler if try statement throws an error
        //            {
        //                Log.Fatal(ex, "Word could not be moved..."); //Error logged to console tagged as 'Fatal'
        //            }
        //        }

        //        private void btnDelete_Click(object sender, EventArgs e)
        //        {
        //            if (this.lstBad.Text == String.Empty)
        //                return;

        //            SqlConnection cn = new SqlConnection(DBInfo.cnString);
        //            cn.Open();

        //            string sql = "DELETE dbo.jfairbanks_DeletedWords WHERE word = '" + lstBad.Text + "'";

        //            SqlCommand cmd = new SqlCommand(sql, cn);
        //            cmd.CommandType = CommandType.Text;
        //            cmd.ExecuteNonQuery();
        //            cn.Close();
        //            RefreshWords();
        //            MessageBox.Show(lstBad.Text + " deleted");
        //        }
    }
}
