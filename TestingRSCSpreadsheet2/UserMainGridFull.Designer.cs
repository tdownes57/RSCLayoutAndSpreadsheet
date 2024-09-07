namespace TestingRSCSpreadsheet2
{
    partial class UserMainGridFull
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonSortList = new Button();
            LinkUndoInsert = new LinkLabel();
            LinkUndoMove = new LinkLabel();
            LinkUndoDelete = new LinkLabel();
            checkMoveRangeExpandsToEndpoint = new CheckBox();
            checkDeleteToEndpoint = new CheckBox();
            LinkMovRangrToEndpoint = new LinkLabel();
            LinkDeleteToEndpoint = new LinkLabel();
            listBoxAscendDescend = new ListBox();
            Label1 = new Label();
            LabelBenchmarkVsIndex = new Label();
            LinkMoveRandomize = new LinkLabel();
            LinkDeleteRandomize = new LinkLabel();
            LinkInsertRandomize = new LinkLabel();
            listMoveAfterOr = new ListBox();
            listInsertAfterOr = new ListBox();
            buttonMoveItems = new Button();
            buttonDelete = new Button();
            buttonInsert = new Button();
            Label15 = new Label();
            Label14 = new Label();
            numMoveAnchorBenchmark = new NumericUpDown();
            Label11 = new Label();
            Label12 = new Label();
            Label13 = new Label();
            numMoveRangeHowMany = new NumericUpDown();
            numMoveRangeStartBenchmark = new NumericUpDown();
            Label7 = new Label();
            Label8 = new Label();
            Label9 = new Label();
            Label10 = new Label();
            numDeleteHowMany = new NumericUpDown();
            numDeleteRangeBenchmarkStart = new NumericUpDown();
            Label6 = new Label();
            textInsertListOfValuesCSV = new TextBox();
            LabelInsertHeader = new Label();
            LabelInsertHowMany = new Label();
            LabelInsertAnchorHeader = new Label();
            numInsertHowMany = new NumericUpDown();
            numInsertAnchorBenchmark = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numMoveAnchorBenchmark).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMoveRangeHowMany).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMoveRangeStartBenchmark).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDeleteHowMany).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDeleteRangeBenchmarkStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numInsertHowMany).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numInsertAnchorBenchmark).BeginInit();
            SuspendLayout();
            // 
            // buttonSortList
            // 
            buttonSortList.Location = new Point(184, 393);
            buttonSortList.Name = "buttonSortList";
            buttonSortList.Size = new Size(133, 39);
            buttonSortList.TabIndex = 113;
            buttonSortList.Text = "Sort Items in List";
            buttonSortList.UseVisualStyleBackColor = true;
            // 
            // LinkUndoInsert
            // 
            LinkUndoInsert.AutoSize = true;
            LinkUndoInsert.Location = new Point(498, 19);
            LinkUndoInsert.Name = "LinkUndoInsert";
            LinkUndoInsert.Size = new Size(68, 15);
            LinkUndoInsert.TabIndex = 112;
            LinkUndoInsert.TabStop = true;
            LinkUndoInsert.Text = "Undo Insert";
            // 
            // LinkUndoMove
            // 
            LinkUndoMove.AutoSize = true;
            LinkUndoMove.Location = new Point(547, 390);
            LinkUndoMove.Name = "LinkUndoMove";
            LinkUndoMove.Size = new Size(69, 15);
            LinkUndoMove.TabIndex = 111;
            LinkUndoMove.TabStop = true;
            LinkUndoMove.Text = "Undo Move";
            // 
            // LinkUndoDelete
            // 
            LinkUndoDelete.AutoSize = true;
            LinkUndoDelete.Location = new Point(558, 196);
            LinkUndoDelete.Name = "LinkUndoDelete";
            LinkUndoDelete.Size = new Size(72, 15);
            LinkUndoDelete.TabIndex = 110;
            LinkUndoDelete.TabStop = true;
            LinkUndoDelete.Text = "Undo Delete";
            // 
            // checkMoveRangeExpandsToEndpoint
            // 
            checkMoveRangeExpandsToEndpoint.AutoSize = true;
            checkMoveRangeExpandsToEndpoint.Location = new Point(317, 288);
            checkMoveRangeExpandsToEndpoint.Name = "checkMoveRangeExpandsToEndpoint";
            checkMoveRangeExpandsToEndpoint.Size = new Size(280, 19);
            checkMoveRangeExpandsToEndpoint.TabIndex = 109;
            checkMoveRangeExpandsToEndpoint.Text = "Bypass Count--Move range extends to Endpoint";
            checkMoveRangeExpandsToEndpoint.UseVisualStyleBackColor = true;
            // 
            // checkDeleteToEndpoint
            // 
            checkDeleteToEndpoint.AutoSize = true;
            checkDeleteToEndpoint.Location = new Point(269, 199);
            checkDeleteToEndpoint.Name = "checkDeleteToEndpoint";
            checkDeleteToEndpoint.Size = new Size(283, 19);
            checkDeleteToEndpoint.TabIndex = 108;
            checkDeleteToEndpoint.Text = "Bypass Count--Delete range extends to Endpoint";
            checkDeleteToEndpoint.UseVisualStyleBackColor = true;
            // 
            // LinkMovRangrToEndpoint
            // 
            LinkMovRangrToEndpoint.AutoSize = true;
            LinkMovRangrToEndpoint.Location = new Point(314, 289);
            LinkMovRangrToEndpoint.Name = "LinkMovRangrToEndpoint";
            LinkMovRangrToEndpoint.Size = new Size(253, 15);
            LinkMovRangrToEndpoint.TabIndex = 107;
            LinkMovRangrToEndpoint.TabStop = true;
            LinkMovRangrToEndpoint.Text = "Bypass Count--Move Range Includes Endpoint";
            LinkMovRangrToEndpoint.Visible = false;
            // 
            // LinkDeleteToEndpoint
            // 
            LinkDeleteToEndpoint.AutoSize = true;
            LinkDeleteToEndpoint.Location = new Point(265, 199);
            LinkDeleteToEndpoint.Name = "LinkDeleteToEndpoint";
            LinkDeleteToEndpoint.Size = new Size(201, 15);
            LinkDeleteToEndpoint.TabIndex = 106;
            LinkDeleteToEndpoint.TabStop = true;
            LinkDeleteToEndpoint.Text = "Bypass Count--Delete Until Endpoint";
            LinkDeleteToEndpoint.Visible = false;
            // 
            // listBoxAscendDescend
            // 
            listBoxAscendDescend.FormattingEnabled = true;
            listBoxAscendDescend.ItemHeight = 15;
            listBoxAscendDescend.Items.AddRange(new object[] { "Ascending", "Descending" });
            listBoxAscendDescend.Location = new Point(37, 398);
            listBoxAscendDescend.Name = "listBoxAscendDescend";
            listBoxAscendDescend.Size = new Size(141, 34);
            listBoxAscendDescend.TabIndex = 105;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Label1.Location = new Point(20, 374);
            Label1.Name = "Label1";
            Label1.Size = new Size(87, 21);
            Label1.TabIndex = 104;
            Label1.Text = "Sort Items";
            // 
            // LabelBenchmarkVsIndex
            // 
            LabelBenchmarkVsIndex.AutoSize = true;
            LabelBenchmarkVsIndex.Location = new Point(26, 348);
            LabelBenchmarkVsIndex.Name = "LabelBenchmarkVsIndex";
            LabelBenchmarkVsIndex.Size = new Size(210, 15);
            LabelBenchmarkVsIndex.TabIndex = 103;
            LabelBenchmarkVsIndex.Text = "(Benchmark equals Index Plus(+) One)";
            // 
            // LinkMoveRandomize
            // 
            LinkMoveRandomize.AutoSize = true;
            LinkMoveRandomize.Location = new Point(360, 372);
            LinkMoveRandomize.Name = "LinkMoveRandomize";
            LinkMoveRandomize.Size = new Size(131, 15);
            LinkMoveRandomize.TabIndex = 102;
            LinkMoveRandomize.TabStop = true;
            LinkMoveRandomize.Text = "Perform Random Move";
            // 
            // LinkDeleteRandomize
            // 
            LinkDeleteRandomize.AutoSize = true;
            LinkDeleteRandomize.Location = new Point(360, 178);
            LinkDeleteRandomize.Name = "LinkDeleteRandomize";
            LinkDeleteRandomize.Size = new Size(134, 15);
            LinkDeleteRandomize.TabIndex = 101;
            LinkDeleteRandomize.TabStop = true;
            LinkDeleteRandomize.Text = "Perform Random Delete";
            // 
            // LinkInsertRandomize
            // 
            LinkInsertRandomize.AutoSize = true;
            LinkInsertRandomize.Location = new Point(489, 82);
            LinkInsertRandomize.Name = "LinkInsertRandomize";
            LinkInsertRandomize.Size = new Size(130, 15);
            LinkInsertRandomize.TabIndex = 100;
            LinkInsertRandomize.TabStop = true;
            LinkInsertRandomize.Text = "Perform Random Insert";
            // 
            // listMoveAfterOr
            // 
            listMoveAfterOr.FormattingEnabled = true;
            listMoveAfterOr.ItemHeight = 15;
            listMoveAfterOr.Items.AddRange(new object[] { "Paste After Anchor", "\"      \" Before Anchor" });
            listMoveAfterOr.Location = new Point(396, 311);
            listMoveAfterOr.Name = "listMoveAfterOr";
            listMoveAfterOr.Size = new Size(121, 34);
            listMoveAfterOr.TabIndex = 99;
            // 
            // listInsertAfterOr
            // 
            listInsertAfterOr.FormattingEnabled = true;
            listInsertAfterOr.ItemHeight = 15;
            listInsertAfterOr.Items.AddRange(new object[] { "Insert After Anchor", "\"      \" Before Anchor" });
            listInsertAfterOr.Location = new Point(379, 47);
            listInsertAfterOr.Name = "listInsertAfterOr";
            listInsertAfterOr.Size = new Size(115, 34);
            listInsertAfterOr.TabIndex = 98;
            // 
            // buttonMoveItems
            // 
            buttonMoveItems.Location = new Point(500, 348);
            buttonMoveItems.Name = "buttonMoveItems";
            buttonMoveItems.Size = new Size(133, 39);
            buttonMoveItems.TabIndex = 97;
            buttonMoveItems.Text = "Move Items";
            buttonMoveItems.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(500, 154);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(133, 39);
            buttonDelete.TabIndex = 96;
            buttonDelete.Text = "Delete Items";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(500, 40);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(133, 39);
            buttonInsert.TabIndex = 95;
            buttonInsert.Text = "Insert New Items";
            buttonInsert.UseVisualStyleBackColor = true;
            // 
            // Label15
            // 
            Label15.AutoSize = true;
            Label15.Location = new Point(20, 339);
            Label15.Name = "Label15";
            Label15.Size = new Size(0, 15);
            Label15.TabIndex = 94;
            // 
            // Label14
            // 
            Label14.AutoSize = true;
            Label14.Location = new Point(20, 313);
            Label14.Name = "Label14";
            Label14.Size = new Size(314, 15);
            Label14.TabIndex = 93;
            Label14.Text = "What benchmark position to anchor (paste moved items)?";
            // 
            // numMoveAnchorBenchmark
            // 
            numMoveAnchorBenchmark.Location = new Point(340, 311);
            numMoveAnchorBenchmark.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMoveAnchorBenchmark.Name = "numMoveAnchorBenchmark";
            numMoveAnchorBenchmark.Size = new Size(50, 23);
            numMoveAnchorBenchmark.TabIndex = 92;
            numMoveAnchorBenchmark.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Label11
            // 
            Label11.AutoSize = true;
            Label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Label11.Location = new Point(20, 223);
            Label11.Name = "Label11";
            Label11.Size = new Size(99, 21);
            Label11.TabIndex = 91;
            Label11.Text = "Move Items";
            // 
            // Label12
            // 
            Label12.AutoSize = true;
            Label12.Location = new Point(20, 283);
            Label12.Name = "Label12";
            Label12.Size = new Size(120, 15);
            Label12.TabIndex = 90;
            Label12.Text = "How many list items?";
            // 
            // Label13
            // 
            Label13.AutoSize = true;
            Label13.Location = new Point(20, 254);
            Label13.Name = "Label13";
            Label13.Size = new Size(399, 15);
            Label13.TabIndex = 89;
            Label13.Text = "What benchmark position to begin select (start of cut; inclusive; leftmost)?";
            // 
            // numMoveRangeHowMany
            // 
            numMoveRangeHowMany.Location = new Point(258, 281);
            numMoveRangeHowMany.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numMoveRangeHowMany.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMoveRangeHowMany.Name = "numMoveRangeHowMany";
            numMoveRangeHowMany.Size = new Size(50, 23);
            numMoveRangeHowMany.TabIndex = 88;
            numMoveRangeHowMany.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numMoveRangeStartBenchmark
            // 
            numMoveRangeStartBenchmark.Location = new Point(425, 252);
            numMoveRangeStartBenchmark.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMoveRangeStartBenchmark.Name = "numMoveRangeStartBenchmark";
            numMoveRangeStartBenchmark.Size = new Size(50, 23);
            numMoveRangeStartBenchmark.TabIndex = 87;
            numMoveRangeStartBenchmark.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(14, 223);
            Label7.Name = "Label7";
            Label7.Size = new Size(0, 15);
            Label7.TabIndex = 86;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Label8.Location = new Point(14, 133);
            Label8.Name = "Label8";
            Label8.Size = new Size(106, 21);
            Label8.TabIndex = 85;
            Label8.Text = "Delete Items";
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Location = new Point(14, 193);
            Label9.Name = "Label9";
            Label9.Size = new Size(164, 15);
            Label9.TabIndex = 84;
            Label9.Text = "How many list items? (Count)";
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Location = new Point(14, 164);
            Label10.Name = "Label10";
            Label10.Size = new Size(189, 15);
            Label10.TabIndex = 83;
            Label10.Text = "What benchmark position to start?";
            // 
            // numDeleteHowMany
            // 
            numDeleteHowMany.Location = new Point(209, 191);
            numDeleteHowMany.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numDeleteHowMany.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDeleteHowMany.Name = "numDeleteHowMany";
            numDeleteHowMany.Size = new Size(50, 23);
            numDeleteHowMany.TabIndex = 82;
            numDeleteHowMany.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numDeleteRangeBenchmarkStart
            // 
            numDeleteRangeBenchmarkStart.Location = new Point(209, 162);
            numDeleteRangeBenchmarkStart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDeleteRangeBenchmarkStart.Name = "numDeleteRangeBenchmarkStart";
            numDeleteRangeBenchmarkStart.Size = new Size(50, 23);
            numDeleteRangeBenchmarkStart.TabIndex = 81;
            numDeleteRangeBenchmarkStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(14, 103);
            Label6.Name = "Label6";
            Label6.Size = new Size(324, 15);
            Label6.TabIndex = 80;
            Label6.Text = "List of two-character values, separated by spaces:  (optional)";
            // 
            // textInsertListOfValuesCSV
            // 
            textInsertListOfValuesCSV.BorderStyle = BorderStyle.FixedSingle;
            textInsertListOfValuesCSV.Location = new Point(355, 100);
            textInsertListOfValuesCSV.Name = "textInsertListOfValuesCSV";
            textInsertListOfValuesCSV.Size = new Size(267, 23);
            textInsertListOfValuesCSV.TabIndex = 79;
            textInsertListOfValuesCSV.Tag = "00";
            textInsertListOfValuesCSV.Text = "++";
            // 
            // LabelInsertHeader
            // 
            LabelInsertHeader.AutoSize = true;
            LabelInsertHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LabelInsertHeader.Location = new Point(14, 13);
            LabelInsertHeader.Name = "LabelInsertHeader";
            LabelInsertHeader.Size = new Size(138, 21);
            LabelInsertHeader.TabIndex = 78;
            LabelInsertHeader.Text = "Insert New Items";
            // 
            // LabelInsertHowMany
            // 
            LabelInsertHowMany.AutoSize = true;
            LabelInsertHowMany.Location = new Point(14, 73);
            LabelInsertHowMany.Name = "LabelInsertHowMany";
            LabelInsertHowMany.Size = new Size(120, 15);
            LabelInsertHowMany.TabIndex = 77;
            LabelInsertHowMany.Text = "How many list items?";
            // 
            // LabelInsertAnchorHeader
            // 
            LabelInsertAnchorHeader.AutoSize = true;
            LabelInsertAnchorHeader.Location = new Point(14, 49);
            LabelInsertAnchorHeader.Name = "LabelInsertAnchorHeader";
            LabelInsertAnchorHeader.Size = new Size(304, 15);
            LabelInsertAnchorHeader.TabIndex = 76;
            LabelInsertAnchorHeader.Text = "What benchmark position to anchor (attach new items)?";
            // 
            // numInsertHowMany
            // 
            numInsertHowMany.Location = new Point(140, 71);
            numInsertHowMany.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numInsertHowMany.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numInsertHowMany.Name = "numInsertHowMany";
            numInsertHowMany.Size = new Size(50, 23);
            numInsertHowMany.TabIndex = 75;
            numInsertHowMany.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numInsertAnchorBenchmark
            // 
            numInsertAnchorBenchmark.Location = new Point(323, 47);
            numInsertAnchorBenchmark.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numInsertAnchorBenchmark.Name = "numInsertAnchorBenchmark";
            numInsertAnchorBenchmark.Size = new Size(50, 23);
            numInsertAnchorBenchmark.TabIndex = 74;
            numInsertAnchorBenchmark.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MainGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonSortList);
            Controls.Add(LinkUndoInsert);
            Controls.Add(LinkUndoMove);
            Controls.Add(LinkUndoDelete);
            Controls.Add(checkMoveRangeExpandsToEndpoint);
            Controls.Add(checkDeleteToEndpoint);
            Controls.Add(LinkMovRangrToEndpoint);
            Controls.Add(LinkDeleteToEndpoint);
            Controls.Add(listBoxAscendDescend);
            Controls.Add(Label1);
            Controls.Add(LabelBenchmarkVsIndex);
            Controls.Add(LinkMoveRandomize);
            Controls.Add(LinkDeleteRandomize);
            Controls.Add(LinkInsertRandomize);
            Controls.Add(listMoveAfterOr);
            Controls.Add(listInsertAfterOr);
            Controls.Add(buttonMoveItems);
            Controls.Add(buttonDelete);
            Controls.Add(buttonInsert);
            Controls.Add(Label15);
            Controls.Add(Label14);
            Controls.Add(numMoveAnchorBenchmark);
            Controls.Add(Label11);
            Controls.Add(Label12);
            Controls.Add(Label13);
            Controls.Add(numMoveRangeHowMany);
            Controls.Add(numMoveRangeStartBenchmark);
            Controls.Add(Label7);
            Controls.Add(Label8);
            Controls.Add(Label9);
            Controls.Add(Label10);
            Controls.Add(numDeleteHowMany);
            Controls.Add(numDeleteRangeBenchmarkStart);
            Controls.Add(Label6);
            Controls.Add(textInsertListOfValuesCSV);
            Controls.Add(LabelInsertHeader);
            Controls.Add(LabelInsertHowMany);
            Controls.Add(LabelInsertAnchorHeader);
            Controls.Add(numInsertHowMany);
            Controls.Add(numInsertAnchorBenchmark);
            Name = "MainGrid";
            Size = new Size(657, 446);
            Load += MainGrid_Load;
            ((System.ComponentModel.ISupportInitialize)numMoveAnchorBenchmark).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMoveRangeHowMany).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMoveRangeStartBenchmark).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDeleteHowMany).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDeleteRangeBenchmarkStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numInsertHowMany).EndInit();
            ((System.ComponentModel.ISupportInitialize)numInsertAnchorBenchmark).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Button buttonSortList;
        internal LinkLabel LinkUndoInsert;
        internal LinkLabel LinkUndoMove;
        internal LinkLabel LinkUndoDelete;
        internal CheckBox checkMoveRangeExpandsToEndpoint;
        internal CheckBox checkDeleteToEndpoint;
        internal LinkLabel LinkMovRangrToEndpoint;
        internal LinkLabel LinkDeleteToEndpoint;
        internal ListBox listBoxAscendDescend;
        internal Label Label1;
        internal Label LabelBenchmarkVsIndex;
        internal LinkLabel LinkMoveRandomize;
        internal LinkLabel LinkDeleteRandomize;
        internal LinkLabel LinkInsertRandomize;
        internal ListBox listMoveAfterOr;
        internal ListBox listInsertAfterOr;
        internal Button buttonMoveItems;
        internal Button buttonDelete;
        internal Button buttonInsert;
        internal Label Label15;
        internal Label Label14;
        internal NumericUpDown numMoveAnchorBenchmark;
        internal Label Label11;
        internal Label Label12;
        internal Label Label13;
        internal NumericUpDown numMoveRangeHowMany;
        internal NumericUpDown numMoveRangeStartBenchmark;
        internal Label Label7;
        internal Label Label8;
        internal Label Label9;
        internal Label Label10;
        internal NumericUpDown numDeleteHowMany;
        internal NumericUpDown numDeleteRangeBenchmarkStart;
        internal Label Label6;
        internal TextBox textInsertListOfValuesCSV;
        internal Label LabelInsertHeader;
        internal Label LabelInsertHowMany;
        internal Label LabelInsertAnchorHeader;
        internal NumericUpDown numInsertHowMany;
        internal NumericUpDown numInsertAnchorBenchmark;
    }
}
