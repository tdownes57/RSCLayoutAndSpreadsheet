namespace TestingRSCSpreadsheet2
{
    partial class UserOperationPartial
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
            Label2 = new Label();
            buttonSortList = new Button();
            listBoxAscendDescend = new ListBox();
            Label1 = new Label();
            LinkUndoDelete = new LinkLabel();
            checkDeleteToEndpoint = new CheckBox();
            LinkDeleteToEndpoint = new LinkLabel();
            LinkDeleteRandomize = new LinkLabel();
            buttonDelete = new Button();
            Label8 = new Label();
            Label9 = new Label();
            Label10 = new Label();
            numDeleteHowMany = new NumericUpDown();
            numDeleteRangeBenchmarkStart = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numDeleteHowMany).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDeleteRangeBenchmarkStart).BeginInit();
            SuspendLayout();
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Label2.Location = new Point(3, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(461, 37);
            Label2.TabIndex = 98;
            Label2.Text = "Let's start slowly.... we can insert later.";
            // 
            // buttonSortList
            // 
            buttonSortList.Location = new Point(167, 205);
            buttonSortList.Name = "buttonSortList";
            buttonSortList.Size = new Size(133, 39);
            buttonSortList.TabIndex = 97;
            buttonSortList.Text = "Sort Items in List";
            buttonSortList.UseVisualStyleBackColor = true;
            // 
            // listBoxAscendDescend
            // 
            listBoxAscendDescend.FormattingEnabled = true;
            listBoxAscendDescend.ItemHeight = 15;
            listBoxAscendDescend.Items.AddRange(new object[] { "Ascending", "Descending" });
            listBoxAscendDescend.Location = new Point(20, 210);
            listBoxAscendDescend.Name = "listBoxAscendDescend";
            listBoxAscendDescend.Size = new Size(141, 34);
            listBoxAscendDescend.TabIndex = 96;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Label1.Location = new Point(3, 186);
            Label1.Name = "Label1";
            Label1.Size = new Size(87, 21);
            Label1.TabIndex = 95;
            Label1.Text = "Sort Items";
            // 
            // LinkUndoDelete
            // 
            LinkUndoDelete.AutoSize = true;
            LinkUndoDelete.Location = new Point(547, 153);
            LinkUndoDelete.Name = "LinkUndoDelete";
            LinkUndoDelete.Size = new Size(72, 15);
            LinkUndoDelete.TabIndex = 94;
            LinkUndoDelete.TabStop = true;
            LinkUndoDelete.Text = "Undo Delete";
            // 
            // checkDeleteToEndpoint
            // 
            checkDeleteToEndpoint.AutoSize = true;
            checkDeleteToEndpoint.Location = new Point(258, 156);
            checkDeleteToEndpoint.Name = "checkDeleteToEndpoint";
            checkDeleteToEndpoint.Size = new Size(283, 19);
            checkDeleteToEndpoint.TabIndex = 93;
            checkDeleteToEndpoint.Text = "Bypass Count--Delete range extends to Endpoint";
            checkDeleteToEndpoint.UseVisualStyleBackColor = true;
            // 
            // LinkDeleteToEndpoint
            // 
            LinkDeleteToEndpoint.AutoSize = true;
            LinkDeleteToEndpoint.Location = new Point(254, 156);
            LinkDeleteToEndpoint.Name = "LinkDeleteToEndpoint";
            LinkDeleteToEndpoint.Size = new Size(201, 15);
            LinkDeleteToEndpoint.TabIndex = 92;
            LinkDeleteToEndpoint.TabStop = true;
            LinkDeleteToEndpoint.Text = "Bypass Count--Delete Until Endpoint";
            LinkDeleteToEndpoint.Visible = false;
            // 
            // LinkDeleteRandomize
            // 
            LinkDeleteRandomize.AutoSize = true;
            LinkDeleteRandomize.Location = new Point(349, 135);
            LinkDeleteRandomize.Name = "LinkDeleteRandomize";
            LinkDeleteRandomize.Size = new Size(134, 15);
            LinkDeleteRandomize.TabIndex = 91;
            LinkDeleteRandomize.TabStop = true;
            LinkDeleteRandomize.Text = "Perform Random Delete";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(489, 111);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(133, 39);
            buttonDelete.TabIndex = 90;
            buttonDelete.Text = "Delete Items";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Label8.Location = new Point(3, 90);
            Label8.Name = "Label8";
            Label8.Size = new Size(106, 21);
            Label8.TabIndex = 89;
            Label8.Text = "Delete Items";
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Location = new Point(3, 150);
            Label9.Name = "Label9";
            Label9.Size = new Size(164, 15);
            Label9.TabIndex = 88;
            Label9.Text = "How many list items? (Count)";
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Location = new Point(3, 121);
            Label10.Name = "Label10";
            Label10.Size = new Size(189, 15);
            Label10.TabIndex = 87;
            Label10.Text = "What benchmark position to start?";
            // 
            // numDeleteHowMany
            // 
            numDeleteHowMany.Location = new Point(198, 148);
            numDeleteHowMany.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numDeleteHowMany.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDeleteHowMany.Name = "numDeleteHowMany";
            numDeleteHowMany.Size = new Size(50, 23);
            numDeleteHowMany.TabIndex = 86;
            numDeleteHowMany.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numDeleteRangeBenchmarkStart
            // 
            numDeleteRangeBenchmarkStart.Location = new Point(198, 119);
            numDeleteRangeBenchmarkStart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDeleteRangeBenchmarkStart.Name = "numDeleteRangeBenchmarkStart";
            numDeleteRangeBenchmarkStart.Size = new Size(50, 23);
            numDeleteRangeBenchmarkStart.TabIndex = 85;
            numDeleteRangeBenchmarkStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // UserOperationPartial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Label2);
            Controls.Add(buttonSortList);
            Controls.Add(listBoxAscendDescend);
            Controls.Add(Label1);
            Controls.Add(LinkUndoDelete);
            Controls.Add(checkDeleteToEndpoint);
            Controls.Add(LinkDeleteToEndpoint);
            Controls.Add(LinkDeleteRandomize);
            Controls.Add(buttonDelete);
            Controls.Add(Label8);
            Controls.Add(Label9);
            Controls.Add(Label10);
            Controls.Add(numDeleteHowMany);
            Controls.Add(numDeleteRangeBenchmarkStart);
            Name = "UserOperationPartial";
            Size = new Size(648, 358);
            ((System.ComponentModel.ISupportInitialize)numDeleteHowMany).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDeleteRangeBenchmarkStart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label Label2;
        internal Button buttonSortList;
        internal ListBox listBoxAscendDescend;
        internal Label Label1;
        internal LinkLabel LinkUndoDelete;
        internal CheckBox checkDeleteToEndpoint;
        internal LinkLabel LinkDeleteToEndpoint;
        internal LinkLabel LinkDeleteRandomize;
        internal Button buttonDelete;
        internal Label Label8;
        internal Label Label9;
        internal Label Label10;
        internal NumericUpDown numDeleteHowMany;
        internal NumericUpDown numDeleteRangeBenchmarkStart;
    }
}
