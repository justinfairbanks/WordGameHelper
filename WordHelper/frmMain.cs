using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace WordHelper
{
    public partial class frmMain : Form
    {
        static List<string> output = new List<string>(); // List for basic word tab
        static List<string> wordList = new List<string>(); // List of possible wordle words

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /* Set Columns */

            grdWordle.ColumnCount = 5;

            for (int i = 0; i < 5; i++)
                grdWordle.Columns[i].Width = 50;

            /* Set Rows */

            grdWordle.RowCount = 2;

            grdWordle.ColumnHeadersVisible = false;
            grdWordle.RowHeadersVisible = false;

            /* Buttons for Grid */
            DataGridViewButtonCell bc = new DataGridViewButtonCell();
            DataGridViewButtonCell bc1 = new DataGridViewButtonCell();
            DataGridViewButtonCell bc2 = new DataGridViewButtonCell();
            DataGridViewButtonCell bc3 = new DataGridViewButtonCell();
            DataGridViewButtonCell bc4 = new DataGridViewButtonCell();

            grdWordle.Rows[1].Cells[0] = bc;
            grdWordle.Rows[1].Cells[1] = bc1;
            grdWordle.Rows[1].Cells[2] = bc2;
            grdWordle.Rows[1].Cells[3] = bc3;
            grdWordle.Rows[1].Cells[4] = bc4;


            /* Reset Top Cells BackColor to White */
            grdWordle.Rows[0].Cells[0].Style.BackColor = Color.White;
            grdWordle.Rows[0].Cells[1].Style.BackColor = Color.White;
            grdWordle.Rows[0].Cells[2].Style.BackColor = Color.White;
            grdWordle.Rows[0].Cells[3].Style.BackColor = Color.White;
            grdWordle.Rows[0].Cells[4].Style.BackColor = Color.White;


            grdWordle.CellClick += new DataGridViewCellEventHandler(grdWordle_CellClick);


            /* Load wordList with possible Wordle Words */
            string Wordle_Path = @"valid-wordle-words.txt";
            var logFile = File.ReadAllLines(Wordle_Path);
            foreach (var s in logFile) wordList.Add(s);


            RefreshWords(); /* Refreshes Lists in Databases Tab */

        /* Configure Serilog with C# */

            /* Event Logger */

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            /* Log File Located WordHelper >> bin >> Debug >> log-.txt */


            Log.Information("I have properly initialized my logger.");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (WordTabs.SelectedTab == BasicTab)
                BasicCalculate();
            else if (WordTabs.SelectedTab == WordleTab)
                WordleCalculate();
            else
                MessageBox.Show("You must be in either basic or world tab", "Calculate Error");
        }

        private void BasicCalculate()
        {
            string tempInput = txtInput.Text.ToUpper();

            char[] arr = tempInput.ToCharArray();

            output = GetArrayPerutations(arr); // All the Permuations of the given word now stored in output

            this.lblStatus.Text = "Removing specified combinations";
            this.Refresh();


        /* Remove Words Outside Specified Word Length */

                if (numLength.Value > 0)
                {
                    var length = numLength.Value;
                    int wordLength = Convert.ToInt32(length);
                    int inputSize = tempInput.Length;

                    wordLength = inputSize - wordLength;


                    for (int i = output.Count - 1; i >= 0; i--)
                    {
                        if (numLength.Value > inputSize)
                        {
                            MessageBox.Show("Please make specified word length less than input word size");
                            break;
                        }
                        else if (numLength.Value == inputSize)
                        {
                            break;
                        }
                        else
                            output[i] = output[i].Remove(output[i].Length - wordLength);
                    }
                }

                else // If length was not modified greater than 0
                    numLength.Value = tempInput.Length;


            output = output.Distinct().ToList(); // Remove Duplicate Words in List


        /* Optional Word Specifictations */


            bool delete = false;
            int position = 0;


                if (txtLetter.Text != string.Empty && numPos1.Value > 0)
                {
                    string str = txtLetter.Text.ToUpper();
                    char letter = char.Parse(str);

                    for (int i = output.Count - 1; i >= 0; i--)
                    {
                        delete = true;
                        position = 0;

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

        /* Compare Combinations from either tab to English Dictionary */

            this.lblStatus.Text = "Spell checking...";
            this.Refresh();

            NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();

            //Debug Dictionary
            string dictPath = Directory.GetCurrentDirectory() + @"\..\..\..\packages\\Netspell.2.1.7\\dic\\en-US.dic";


            oDict.DictionaryFile = dictPath;

            oDict.Initialize();

            NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();


            bool remove = true;
            string basicLower;


            for (int i = output.Count - 1; i >= 0; i--)
            {

                string basicWord = output[i];

                oSpell.Dictionary = oDict;

                remove = false;

                string tempL;

                basicLower = basicWord.ToLower();

        /* Checks Both Database and English Dictionaries */

                if (!oSpell.TestWord(basicLower))
                {
                    remove = true;

                    foreach (string word in lstGood.Items)  // If the word exists in the Database list
                    {
                        tempL = word.ToLower();

                        if (tempL == basicLower)
                            remove = false;
                    }
                }


            /* If the word is not in Either Dictionary, Checks to see if it is in the deleted word list */

                foreach (string word in lstBad.Items)  // If the word is in removed words in Database Tab
                {
                    tempL = word.ToLower();

                    if (tempL == basicLower)
                        remove = true;
                }


                /* Remove Words */
                if (!chkShow.Checked && remove == true) // If show all combinations is not checked 
                    output.Remove(basicWord);

            }

        /* Outputs all combinations to result text box */

            Sort(output);

            lstOutput.Items.Clear();
            lstOutput.Items.AddRange(output.ToArray());

            this.lblStatus.Text = "Completed";
            this.Refresh();
        }

        private void WordleCalculate()
        {
            string[] confLetters = new string[5];
            string[] Letters = new string[5];


            string notInWord = null;
            string combination = null;
            int incrementor = 0;

        /* Gather User input */

                for (int i = 0; i < 5; i++)
                {

                    if (grdWordle.Rows[0].Cells[i].Value != null)
                    {
                        if (grdWordle.Rows[0].Cells[i].Style.BackColor == Color.Green) // If letter is in confirmed spot
                        {
                            grdWordle.Rows[0].Cells[i].Style.BackColor = Color.White;

                            confLetters[incrementor] = grdWordle.Rows[0].Cells[i].Value.ToString().ToUpper();
                            combination += grdWordle.Rows[0].Cells[i].Value.ToString().ToUpper();

                            grdWordle.Rows[0].Cells[i].Style.BackColor = Color.Green;
                        }

                        else if (grdWordle.Rows[0].Cells[i].Style.BackColor == Color.Yellow) // If letter is somewhere in word
                        {
                            grdWordle.Rows[0].Cells[i].Style.BackColor = Color.White;

                            Letters[incrementor] = grdWordle.Rows[0].Cells[i].Value.ToString().ToUpper();
                            combination += Letters[incrementor];

                            grdWordle.Rows[0].Cells[i].Style.BackColor = Color.Yellow;
                        }

                        else if (grdWordle.Rows[0].Cells[i].Style.BackColor == Color.White) // If letter is not in word
                        {
                            notInWord = grdWordle.Rows[0].Cells[i].Value.ToString();

                            if (txtExcludedLetters.Text.Contains(notInWord) != true)
                                txtExcludedLetters.Text += notInWord;

                            combination += notInWord;

                            string conv = txtExcludedLetters.Text;

                            txtExcludedLetters.Clear();

                            char[] convArr = conv.ToCharArray();

                            Array.Sort(convArr);

                            foreach (char c in convArr)
                                txtExcludedLetters.Text += c;

                        }
                        incrementor++;

                    }
                }

             /* If no user input returns out of method */

                if (combination == null && notInWord == null)
                {
                    MessageBox.Show("No Words Entered in Wordle...", "Input Error");
                    lstOutput.DataSource = null;
                    lstOutput.Items.Clear();
                    btnRemoveOutput.Visible = false;
                    return;
                }

             /* If more than 5 letters were entered */

                if (combination.Length > 5)
                {
                    MessageBox.Show("Each box must have only one letter!", "Input Error");
                    lstOutput.DataSource = null;
                    lstOutput.Items.Clear();
                    btnRemoveOutput.Visible = false;
                    return;
                }


                foreach(string item in lstGood.Items) // Add the Database dictionary to the output list 
                wordList.Add(item);


                bool temDel;
                int tempPosit;
                bool nonLet;


            /* Validating Word Based on Green/Yellow/White Conditions */

                    this.lblStatus.Text = "Checking Combinations...";
                    this.Refresh();

                for (int k = 0; k < 5; k++)
                {
                    for (int i = wordList.Count - 1; i >= 0; i--)
                    {
                        temDel = false;
                        tempPosit = 0;

                        string tWord = wordList[i].ToUpper();

                        foreach (char ch in tWord)        
                        {
                            nonLet = false;

                        /* Checks Green Confirmed Letters are in correct positions */

                            if (confLetters[k] != null)
                            {
                                string grn = confLetters[k].ToUpper();
                                var charArrayG = grn.ToCharArray();

                                if (ch == charArrayG[0])
                                {
                                    if (tempPosit == k)
                                    {
                                        temDel = false;
                                        break;
                                    }
                                    else
                                    {
                                        temDel = true;
                                        break;
                                    }
                                }
                                else if (tempPosit == k && ch != charArrayG[0])
                                {
                                    temDel = true;
                                    break;
                                }
                            }


                        /* Checks if yellow Letters are somewhere in word */

                            if (Letters[k] != null)
                            {
                                string yel = Letters[k].ToUpper();
                                var charArrayY = yel.ToCharArray();


                                if (ch == charArrayY[0])
                                {
                                    if (tempPosit == k)
                                    {
                                        temDel = true;
                                        break;
                                    }
                                    else
                                    {
                                        temDel = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    temDel = true;
                                }
                            }

                            tempPosit++;


                        /* Check out if any current or previous greyed letter is in word..if so remove it */
                            for (int j = 0; j < txtExcludedLetters.Text.Length; j++)
                            {

                                char whi = txtExcludedLetters.Text[j];
                                whi = Char.ToUpper(whi);

                                if (ch == whi)
                                {
                                    temDel = true;
                                    nonLet = true; // To break out of next for loop
                                    break;
                                }
                            }

                            if (nonLet == true)
                                break;


                        }


                        if (temDel == true)
                            wordList.RemoveAt(i);
                    }
                }

        /* Compare Combinations from either tab to English Dictionary */

            wordList = wordList.Distinct().ToList();

            this.lblStatus.Text = "Spell checking...";
            this.Refresh();

            NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();

            string dictPath = Directory.GetCurrentDirectory() + @"\..\..\..\packages\\Netspell.2.1.7\\dic\\en-US.dic";


            oDict.DictionaryFile = dictPath;
            oDict.Initialize();

            NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();

            bool remove = true;
            string wordleLower;


            for (int i = wordList.Count - 1; i >= 0; i--)
            {
                string wordleWord = wordList[i];

                oSpell.Dictionary = oDict;

                remove = false;
                string tempL;

                wordleLower = wordleWord.ToLower();

        /* Checks Both Database and English Dictionaries */

                if (!oSpell.TestWord(wordleLower))
                {
                    remove = true;

                    foreach (string word in lstGood.Items)  // If the word exists in the Database list
                    {
                        tempL = word.ToLower();

                        if (tempL == wordleLower)
                            remove = false;
                    }
                }


        /* If the word is not in Either Dictionary, Checks to see if it is in the deleted word list */

                foreach (string word in lstBad.Items)  // If the word is in removed words in Database Tab
                {
                    tempL = word.ToLower();

                    if (tempL == wordleLower)
                        remove = true;
                }


                if (!chkShow.Checked && remove == true) // If show all combinations is not checked 
                    wordList.Remove(wordleWord);
            }


            Sort(wordList);

            lstOutput.Items.Clear();
            lstOutput.Items.AddRange(wordList.ToArray());

            this.lblStatus.Text = "Completed";
            this.Refresh();
        }

        private void lstOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveOutput.Visible = true;
        }
        private void btnRemoveOutput_Click(object sender, EventArgs e)
        {
            if (lstOutput.SelectedItems.Count == 0)
                return;
            
            string selected = lstOutput.Text;
            lstOutput.Items.Remove(selected);
            lstBad.Items.Add(selected);

            btnRemoveOutput.Visible = false;

            string sql = "INSERT INTO dbo.BadWord(word) VALUES('" + selected + "')";

            SqlConnection cn = new SqlConnection(DBInfo.cnString);
            SqlCommand cmd = new SqlCommand(sql, cn);

            cn.Open();

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();

        }

        public void Sort<T>(IList<T> list)
        {
            List<T> tmp = new List<T>(list);
           
            tmp.Sort();

            for (int i = 0; i < tmp.Count; i++)
                list[i] = tmp[i];
        }

        private static List<string> GetCharacterPermutations(List<string> worldList, char[] list, int start, int end)
        {

            if (start == end)
            {

                string result = string.Join("", list.ToArray());

                for (int i = start; i <= end; i++)
                {
                    if (!worldList.Contains(result.Substring(0, i + 1)))
                        worldList.Add(result.Substring(0, i + 1));
                }
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(ref list[start], ref list[i]);

                    GetCharacterPermutations(worldList, list, start + 1, end);

                    Swap(ref list[start], ref list[i]);
                }

            }
            return worldList;
        }
        public static List<string> GetArrayPerutations(char[] list)
        {
            List<string> masterList = new List<string>();

            int length = list.Length - 1;

            masterList = GetCharacterPermutations(masterList, list, 0, length);
            
            return masterList;
        }
        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        private void btnResetBasic_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtLetter.Clear();
            txtLetter2.Clear();
            txtLetter3.Clear();
            lstOutput.DataSource = null;
            lstOutput.Items.Clear();
            btnRemoveOutput.Visible = false;

            numLength.Value = 0;
            numPos1.Value = 0;
            numPos2.Value = 0;
            numPos3.Value = 0;

            chkShow.Checked = false;

            MessageBox.Show("Basic Tab Reset!", "Reset");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void grdWordle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* Changes Wordle Cell Colors */

            if (e.RowIndex == grdWordle.RowCount - 1)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                DataGridViewCellStyle current = grdWordle.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Style;

                if (current.BackColor != Color.Green && current.BackColor != Color.Yellow)
                     style.BackColor = Color.Green;
                else if (current.BackColor == Color.Green)          
                    style.BackColor = Color.Yellow;
                else if (current.BackColor == Color.Yellow)
                    style.BackColor = Color.White;

                grdWordle.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Style = style;
            }

            btnRemoveOutput.Visible = false;
            lstOutput.ClearSelected();
        }
        
        private void btnNewWordle_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < 5; i++) /* Clear Wordle Grid */
            {
                grdWordle.Rows[0].Cells[i].Style.BackColor = Color.White;
                grdWordle.Rows[0].Cells[i].Value = null;
            }

            txtExcludedLetters.Clear();
            lstOutput.DataSource = null;
            lstOutput.Items.Clear();

            btnRemoveOutput.Visible = false;

            wordList.Clear();

            /* Load wordList with possible Wordle Words */
            string Wordle_Path = @"valid-wordle-words.txt";
            var logFile = File.ReadAllLines(Wordle_Path);
            foreach (var s in logFile) wordList.Add(s);


            MessageBox.Show("Grid and Stored Letters Cleared!", "Wordle Reset");
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++) /* Clear Wordle Grid */
            {
                grdWordle.Rows[0].Cells[i].Style.BackColor = Color.White;
                grdWordle.Rows[0].Cells[i].Value = null;
            }
        }

        public static class DBInfo //Global Azure SQL Database Source
        {
            public static readonly string cnString = "Server=tcp:wordhelperdictionary.database.windows.net,1433;Initial Catalog=WordDictionary;Persist Security Info=False;User ID=sqladmin;Password=SecretPassword123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        }

        private void RefreshWords()
        {

        /* For Database Dictionary TextBox */

            lstGood.Items.Clear();

            SqlConnection cn = new SqlConnection(DBInfo.cnString);
            cn.Open();

            string sql = "SELECT word FROM dbo.GoodWord";

            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
                lstGood.Items.Add(reader["word"].ToString());

            reader.Close();

        /* For Deleted TextBox */

            lstBad.Items.Clear();

            cn = new SqlConnection(DBInfo.cnString);
            cn.Open();

            sql = "SELECT word FROM dbo.BadWord";

            SqlCommand cmd2 = new SqlCommand(sql, cn);

            cmd2.CommandType = CommandType.Text;

            SqlDataReader reader2 = cmd2.ExecuteReader();


            while (reader2.Read())
                lstBad.Items.Add(reader2["word"].ToString()); //Change to "word"

            reader2.Close();
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (this.txtAddWord.Text == String.Empty) return; //If nothing is in the input textbox

            lstGood.Items.Add(txtAddWord.Text);

        /* Exception handler logging to file defined in form load function */

            try
            {
                Log.Debug("Add word to Database Dictionary:"); //Debug Tag Message
                string sql = "INSERT INTO dbo.GoodWord(word) VALUES('" + txtAddWord.Text + "')";

                SqlConnection cn = new SqlConnection(DBInfo.cnString);
                SqlCommand cmd = new SqlCommand(sql, cn);

                cn.Open();

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cn.Close();

                txtAddWord.Text = "";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Word could not be added to Database");
            }
        }

        private void btnBad_Click(object sender, EventArgs e)
        {
        /* Delete from Good List and Move to Deleted List */

            if (lstGood.SelectedItems.Count == 0) return;

            string selected = lstGood.Text;

            lstGood.Items.Remove(selected);
            lstBad.Items.Add(selected);

            SqlConnection cn = new SqlConnection(DBInfo.cnString);
            cn.Open();


            /* Exception handler logging to file defined in form load function */

            try
            {
                Log.Debug("Move word to Deleted List");

                string sql = "INSERT INTO dbo.BadWord(word) VALUES('" + selected + "')";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();



                sql = "DELETE dbo.GoodWord WHERE word = '" + selected + "'";

                MessageBox.Show(selected + " removed");

                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();


                cn.Close();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Word could not be moved...");
            }
        }

        private void btnGood_Click(object sender, EventArgs e)
        {
        /* Delete from Deleted List and Move to Good List */

            if (lstBad.SelectedItems.Count == 0) return;

            string selected = lstBad.Text;

            lstBad.Items.Remove(selected);
            lstGood.Items.Add(selected);

            SqlConnection cn = new SqlConnection(DBInfo.cnString);
            cn.Open();


            /* Exception handler logging to file defined in form load function */

            try
            {
                Log.Debug("Move word to good list");


                string sql = "INSERT INTO dbo.GoodWord(word) VALUES('" + selected + "')";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();



                sql = "DELETE dbo.BadWord WHERE word = '" + selected + "'";

                MessageBox.Show(selected + " added to dictionary");

                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                
            
                cn.Close();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Word could not be moved...");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lstBad.Text == String.Empty) return;

            SqlConnection cn = new SqlConnection(DBInfo.cnString);
            cn.Open();

            string sql = "DELETE dbo.BadWord WHERE word = '" + lstBad.Text + "'";

            lstBad.Items.Remove(lstBad.Text);

            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
