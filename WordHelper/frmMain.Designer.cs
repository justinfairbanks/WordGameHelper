namespace WordHelper
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtLetter = new System.Windows.Forms.TextBox();
            this.txtLetter2 = new System.Windows.Forms.TextBox();
            this.txtLetter3 = new System.Windows.Forms.TextBox();
            this.lblChars = new System.Windows.Forms.Label();
            this.lblLetter = new System.Windows.Forms.Label();
            this.lblLetter2 = new System.Windows.Forms.Label();
            this.lblLetter3 = new System.Windows.Forms.Label();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.numPos1 = new System.Windows.Forms.NumericUpDown();
            this.numPos2 = new System.Windows.Forms.NumericUpDown();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.lblPos2 = new System.Windows.Forms.Label();
            this.lblPos3 = new System.Windows.Forms.Label();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.numPos3 = new System.Windows.Forms.NumericUpDown();
            this.WordTabs = new System.Windows.Forms.TabControl();
            this.BasicTab = new System.Windows.Forms.TabPage();
            this.lblOptional = new System.Windows.Forms.Label();
            this.WordleTab = new System.Windows.Forms.TabPage();
            this.grdWordle = new System.Windows.Forms.DataGridView();
            this.DatabaseTab = new System.Windows.Forms.TabPage();
            this.lblDeleted = new System.Windows.Forms.Label();
            this.lblDataDict = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.txtAddWord = new System.Windows.Forms.TextBox();
            this.btnGood = new System.Windows.Forms.Button();
            this.btnBad = new System.Windows.Forms.Button();
            this.lstBad = new System.Windows.Forms.ListBox();
            this.lstGood = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.spelling1 = new NetSpell.SpellChecker.Spelling(this.components);
            this.spelling2 = new NetSpell.SpellChecker.Spelling(this.components);
            this.lblOutput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPos3)).BeginInit();
            this.WordTabs.SuspendLayout();
            this.BasicTab.SuspendLayout();
            this.WordleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWordle)).BeginInit();
            this.DatabaseTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.lblStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(82, 89);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 0;
            // 
            // txtLetter
            // 
            this.txtLetter.Location = new System.Drawing.Point(82, 187);
            this.txtLetter.Name = "txtLetter";
            this.txtLetter.Size = new System.Drawing.Size(100, 20);
            this.txtLetter.TabIndex = 1;
            // 
            // txtLetter2
            // 
            this.txtLetter2.Location = new System.Drawing.Point(82, 227);
            this.txtLetter2.Name = "txtLetter2";
            this.txtLetter2.Size = new System.Drawing.Size(100, 20);
            this.txtLetter2.TabIndex = 2;
            // 
            // txtLetter3
            // 
            this.txtLetter3.Location = new System.Drawing.Point(82, 262);
            this.txtLetter3.Name = "txtLetter3";
            this.txtLetter3.Size = new System.Drawing.Size(100, 20);
            this.txtLetter3.TabIndex = 3;
            // 
            // lblChars
            // 
            this.lblChars.AutoSize = true;
            this.lblChars.Location = new System.Drawing.Point(79, 73);
            this.lblChars.Name = "lblChars";
            this.lblChars.Size = new System.Drawing.Size(81, 13);
            this.lblChars.TabIndex = 4;
            this.lblChars.Text = "Possible Letters";
            // 
            // lblLetter
            // 
            this.lblLetter.AutoSize = true;
            this.lblLetter.Location = new System.Drawing.Point(79, 172);
            this.lblLetter.Name = "lblLetter";
            this.lblLetter.Size = new System.Drawing.Size(34, 13);
            this.lblLetter.TabIndex = 5;
            this.lblLetter.Text = "Letter";
            // 
            // lblLetter2
            // 
            this.lblLetter2.AutoSize = true;
            this.lblLetter2.Location = new System.Drawing.Point(79, 211);
            this.lblLetter2.Name = "lblLetter2";
            this.lblLetter2.Size = new System.Drawing.Size(50, 13);
            this.lblLetter2.TabIndex = 6;
            this.lblLetter2.Text = "Letter #2";
            // 
            // lblLetter3
            // 
            this.lblLetter3.AutoSize = true;
            this.lblLetter3.Location = new System.Drawing.Point(79, 250);
            this.lblLetter3.Name = "lblLetter3";
            this.lblLetter3.Size = new System.Drawing.Size(50, 13);
            this.lblLetter3.TabIndex = 7;
            this.lblLetter3.Text = "Letter #3";
            // 
            // numLength
            // 
            this.numLength.Location = new System.Drawing.Point(254, 89);
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(120, 20);
            this.numLength.TabIndex = 8;
            // 
            // numPos1
            // 
            this.numPos1.Location = new System.Drawing.Point(254, 188);
            this.numPos1.Name = "numPos1";
            this.numPos1.Size = new System.Drawing.Size(120, 20);
            this.numPos1.TabIndex = 9;
            // 
            // numPos2
            // 
            this.numPos2.Location = new System.Drawing.Point(254, 227);
            this.numPos2.Name = "numPos2";
            this.numPos2.Size = new System.Drawing.Size(120, 20);
            this.numPos2.TabIndex = 10;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(256, 73);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 12;
            this.lblLength.Text = "Length";
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Location = new System.Drawing.Point(251, 172);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(57, 13);
            this.lblPos.TabIndex = 13;
            this.lblPos.Text = "At Position";
            // 
            // lblPos2
            // 
            this.lblPos2.AutoSize = true;
            this.lblPos2.Location = new System.Drawing.Point(251, 211);
            this.lblPos2.Name = "lblPos2";
            this.lblPos2.Size = new System.Drawing.Size(57, 13);
            this.lblPos2.TabIndex = 14;
            this.lblPos2.Text = "At Position";
            // 
            // lblPos3
            // 
            this.lblPos3.AutoSize = true;
            this.lblPos3.Location = new System.Drawing.Point(251, 250);
            this.lblPos3.Name = "lblPos3";
            this.lblPos3.Size = new System.Drawing.Size(57, 13);
            this.lblPos3.TabIndex = 15;
            this.lblPos3.Text = "At Position";
            // 
            // chkShow
            // 
            this.chkShow.AutoSize = true;
            this.chkShow.Location = new System.Drawing.Point(20, 467);
            this.chkShow.Name = "chkShow";
            this.chkShow.Size = new System.Drawing.Size(133, 17);
            this.chkShow.TabIndex = 17;
            this.chkShow.Text = "Show All Combinations";
            this.chkShow.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(20, 490);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 19;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(536, 50);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(186, 407);
            this.txtResult.TabIndex = 20;
            this.txtResult.Text = "";
            // 
            // numPos3
            // 
            this.numPos3.Location = new System.Drawing.Point(254, 265);
            this.numPos3.Name = "numPos3";
            this.numPos3.Size = new System.Drawing.Size(120, 20);
            this.numPos3.TabIndex = 11;
            // 
            // WordTabs
            // 
            this.WordTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WordTabs.Controls.Add(this.BasicTab);
            this.WordTabs.Controls.Add(this.WordleTab);
            this.WordTabs.Controls.Add(this.DatabaseTab);
            this.WordTabs.Location = new System.Drawing.Point(12, 28);
            this.WordTabs.Name = "WordTabs";
            this.WordTabs.SelectedIndex = 0;
            this.WordTabs.Size = new System.Drawing.Size(518, 433);
            this.WordTabs.TabIndex = 21;
            // 
            // BasicTab
            // 
            this.BasicTab.Controls.Add(this.lblOptional);
            this.BasicTab.Controls.Add(this.txtInput);
            this.BasicTab.Controls.Add(this.txtLetter);
            this.BasicTab.Controls.Add(this.txtLetter2);
            this.BasicTab.Controls.Add(this.txtLetter3);
            this.BasicTab.Controls.Add(this.lblChars);
            this.BasicTab.Controls.Add(this.lblPos3);
            this.BasicTab.Controls.Add(this.lblLetter);
            this.BasicTab.Controls.Add(this.lblPos2);
            this.BasicTab.Controls.Add(this.lblLetter2);
            this.BasicTab.Controls.Add(this.lblPos);
            this.BasicTab.Controls.Add(this.lblLetter3);
            this.BasicTab.Controls.Add(this.lblLength);
            this.BasicTab.Controls.Add(this.numLength);
            this.BasicTab.Controls.Add(this.numPos3);
            this.BasicTab.Controls.Add(this.numPos1);
            this.BasicTab.Controls.Add(this.numPos2);
            this.BasicTab.Location = new System.Drawing.Point(4, 22);
            this.BasicTab.Name = "BasicTab";
            this.BasicTab.Padding = new System.Windows.Forms.Padding(3);
            this.BasicTab.Size = new System.Drawing.Size(510, 407);
            this.BasicTab.TabIndex = 0;
            this.BasicTab.Text = "Basic";
            this.BasicTab.UseVisualStyleBackColor = true;
            // 
            // lblOptional
            // 
            this.lblOptional.AutoSize = true;
            this.lblOptional.Location = new System.Drawing.Point(155, 146);
            this.lblOptional.Name = "lblOptional";
            this.lblOptional.Size = new System.Drawing.Size(141, 13);
            this.lblOptional.TabIndex = 16;
            this.lblOptional.Text = "Optional Word Combinations";
            // 
            // WordleTab
            // 
            this.WordleTab.Controls.Add(this.grdWordle);
            this.WordleTab.Location = new System.Drawing.Point(4, 22);
            this.WordleTab.Name = "WordleTab";
            this.WordleTab.Padding = new System.Windows.Forms.Padding(3);
            this.WordleTab.Size = new System.Drawing.Size(510, 407);
            this.WordleTab.TabIndex = 1;
            this.WordleTab.Text = "Wordle";
            this.WordleTab.UseVisualStyleBackColor = true;
            // 
            // grdWordle
            // 
            this.grdWordle.AllowUserToAddRows = false;
            this.grdWordle.AllowUserToDeleteRows = false;
            this.grdWordle.AllowUserToResizeColumns = false;
            this.grdWordle.AllowUserToResizeRows = false;
            this.grdWordle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWordle.Location = new System.Drawing.Point(118, 95);
            this.grdWordle.Name = "grdWordle";
            this.grdWordle.Size = new System.Drawing.Size(253, 47);
            this.grdWordle.TabIndex = 0;
            // 
            // DatabaseTab
            // 
            this.DatabaseTab.Controls.Add(this.lblDeleted);
            this.DatabaseTab.Controls.Add(this.lblDataDict);
            this.DatabaseTab.Controls.Add(this.btnDelete);
            this.DatabaseTab.Controls.Add(this.btnAddWord);
            this.DatabaseTab.Controls.Add(this.txtAddWord);
            this.DatabaseTab.Controls.Add(this.btnGood);
            this.DatabaseTab.Controls.Add(this.btnBad);
            this.DatabaseTab.Controls.Add(this.lstBad);
            this.DatabaseTab.Controls.Add(this.lstGood);
            this.DatabaseTab.Location = new System.Drawing.Point(4, 22);
            this.DatabaseTab.Name = "DatabaseTab";
            this.DatabaseTab.Padding = new System.Windows.Forms.Padding(3);
            this.DatabaseTab.Size = new System.Drawing.Size(510, 407);
            this.DatabaseTab.TabIndex = 2;
            this.DatabaseTab.Text = "Database";
            this.DatabaseTab.UseVisualStyleBackColor = true;
            // 
            // lblDeleted
            // 
            this.lblDeleted.AutoSize = true;
            this.lblDeleted.Location = new System.Drawing.Point(294, 43);
            this.lblDeleted.Name = "lblDeleted";
            this.lblDeleted.Size = new System.Drawing.Size(189, 13);
            this.lblDeleted.TabIndex = 11;
            this.lblDeleted.Text = "Words Removed From Possible Words";
            // 
            // lblDataDict
            // 
            this.lblDataDict.AutoSize = true;
            this.lblDataDict.Location = new System.Drawing.Point(64, 43);
            this.lblDataDict.Name = "lblDataDict";
            this.lblDataDict.Size = new System.Drawing.Size(103, 13);
            this.lblDataDict.TabIndex = 10;
            this.lblDataDict.Text = "Database Dictionary";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(307, 303);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(159, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete Selected Word";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(37, 369);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(75, 23);
            this.btnAddWord.TabIndex = 8;
            this.btnAddWord.Text = "Add Word";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // txtAddWord
            // 
            this.txtAddWord.Location = new System.Drawing.Point(37, 338);
            this.txtAddWord.Name = "txtAddWord";
            this.txtAddWord.Size = new System.Drawing.Size(100, 20);
            this.txtAddWord.TabIndex = 7;
            // 
            // btnGood
            // 
            this.btnGood.Location = new System.Drawing.Point(213, 180);
            this.btnGood.Name = "btnGood";
            this.btnGood.Size = new System.Drawing.Size(75, 23);
            this.btnGood.TabIndex = 6;
            this.btnGood.Text = "<<<";
            this.btnGood.UseVisualStyleBackColor = true;
            this.btnGood.Click += new System.EventHandler(this.btnGood_Click);
            // 
            // btnBad
            // 
            this.btnBad.Location = new System.Drawing.Point(213, 127);
            this.btnBad.Name = "btnBad";
            this.btnBad.Size = new System.Drawing.Size(75, 23);
            this.btnBad.TabIndex = 5;
            this.btnBad.Text = ">>>";
            this.btnBad.UseVisualStyleBackColor = true;
            this.btnBad.Click += new System.EventHandler(this.btnBad_Click);
            // 
            // lstBad
            // 
            this.lstBad.FormattingEnabled = true;
            this.lstBad.Location = new System.Drawing.Point(307, 59);
            this.lstBad.Name = "lstBad";
            this.lstBad.Size = new System.Drawing.Size(159, 238);
            this.lstBad.TabIndex = 4;
            // 
            // lstGood
            // 
            this.lstGood.FormattingEnabled = true;
            this.lstGood.Location = new System.Drawing.Point(34, 59);
            this.lstGood.Name = "lstGood";
            this.lstGood.Size = new System.Drawing.Size(159, 238);
            this.lstGood.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lblStrip
            // 
            this.lblStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.lblStrip.Location = new System.Drawing.Point(0, 537);
            this.lblStrip.Name = "lblStrip";
            this.lblStrip.Size = new System.Drawing.Size(751, 22);
            this.lblStrip.TabIndex = 23;
            this.lblStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 17);
            this.lblStatus.Text = " No Words Selected";
            // 
            // spelling1
            // 
            this.spelling1.Dictionary = null;
            // 
            // spelling2
            // 
            this.spelling2.Dictionary = null;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(590, 34);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(80, 13);
            this.lblOutput.TabIndex = 24;
            this.lblOutput.Text = "Possible Words";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 559);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblStrip);
            this.Controls.Add(this.WordTabs);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.chkShow);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPos3)).EndInit();
            this.WordTabs.ResumeLayout(false);
            this.BasicTab.ResumeLayout(false);
            this.BasicTab.PerformLayout();
            this.WordleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWordle)).EndInit();
            this.DatabaseTab.ResumeLayout(false);
            this.DatabaseTab.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.lblStrip.ResumeLayout(false);
            this.lblStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtLetter;
        private System.Windows.Forms.TextBox txtLetter2;
        private System.Windows.Forms.TextBox txtLetter3;
        private System.Windows.Forms.Label lblChars;
        private System.Windows.Forms.Label lblLetter;
        private System.Windows.Forms.Label lblLetter2;
        private System.Windows.Forms.Label lblLetter3;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.NumericUpDown numPos1;
        private System.Windows.Forms.NumericUpDown numPos2;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblPos2;
        private System.Windows.Forms.Label lblPos3;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.NumericUpDown numPos3;
        private System.Windows.Forms.TabControl WordTabs;
        private System.Windows.Forms.TabPage BasicTab;
        private System.Windows.Forms.TabPage WordleTab;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip lblStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.DataGridView grdWordle;
        private System.Windows.Forms.TabPage DatabaseTab;
        private NetSpell.SpellChecker.Spelling spelling1;
        private NetSpell.SpellChecker.Spelling spelling2;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.TextBox txtAddWord;
        private System.Windows.Forms.Button btnGood;
        private System.Windows.Forms.Button btnBad;
        private System.Windows.Forms.ListBox lstBad;
        private System.Windows.Forms.ListBox lstGood;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblDataDict;
        private System.Windows.Forms.Label lblDeleted;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblOptional;
    }
}

