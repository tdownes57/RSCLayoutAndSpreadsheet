namespace TestingRSCSpreadsheet2
{
    partial class FormTestGrid2
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
            Label2 = new Label();
            LabelHeader1 = new Label();
            LabelHdrVerticalRows = new Label();
            LabelHdrHorizontalCols = new Label();
            labelItemsDisplay2Rows = new Label();
            labelAnchorLinkLabels = new Label();
            linkToPenultimate = new LinkLabel();
            linkToEndpoint = new LinkLabel();
            linkEndpointHeading = new LinkLabel();
            linkSingleItemOnly = new LinkLabel();
            labelNumOperations = new Label();
            buttonUndo = new Button();
            buttonReDo = new Button();
            Label3 = new Label();
            labelItemsDisplay1Cols = new Label();
            labelBenchmark = new Label();
            Label1 = new Label();
            LabelHdrRowHeaders = new Label();
            userOperationPartial1 = new UserOperationPartial();
            SuspendLayout();
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.BackColor = SystemColors.Control;
            Label2.BorderStyle = BorderStyle.FixedSingle;
            Label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label2.Location = new Point(313, 9);
            Label2.Name = "Label2";
            Label2.Size = new Size(229, 23);
            Label2.TabIndex = 99;
            Label2.Text = "TESTING TWO-LIST MANAGER ";
            // 
            // LabelHeader1
            // 
            LabelHeader1.AutoSize = true;
            LabelHeader1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelHeader1.Location = new Point(12, 9);
            LabelHeader1.Name = "LabelHeader1";
            LabelHeader1.Size = new Size(456, 21);
            LabelHeader1.TabIndex = 98;
            LabelHeader1.Text = "Testing RSC Doubly-Linked List operations--TESTING TWO LISTS";
            // 
            // LabelHdrVerticalRows
            // 
            LabelHdrVerticalRows.BackColor = Color.Plum;
            LabelHdrVerticalRows.BorderStyle = BorderStyle.FixedSingle;
            LabelHdrVerticalRows.Location = new Point(20, 122);
            LabelHdrVerticalRows.Name = "LabelHdrVerticalRows";
            LabelHdrVerticalRows.Size = new Size(104, 24);
            LabelHdrVerticalRows.TabIndex = 115;
            LabelHdrVerticalRows.Tag = "Vertical";
            LabelHdrVerticalRows.Text = "Vertical (rows)";
            // 
            // LabelHdrHorizontalCols
            // 
            LabelHdrHorizontalCols.BackColor = Color.PaleGreen;
            LabelHdrHorizontalCols.BorderStyle = BorderStyle.FixedSingle;
            LabelHdrHorizontalCols.Location = new Point(20, 98);
            LabelHdrHorizontalCols.Name = "LabelHdrHorizontalCols";
            LabelHdrHorizontalCols.Size = new Size(104, 24);
            LabelHdrHorizontalCols.TabIndex = 114;
            LabelHdrHorizontalCols.Tag = " Horizontal";
            LabelHdrHorizontalCols.Text = " Horizontal (cols)";
            // 
            // labelItemsDisplay2Rows
            // 
            labelItemsDisplay2Rows.BackColor = Color.Plum;
            labelItemsDisplay2Rows.BorderStyle = BorderStyle.FixedSingle;
            labelItemsDisplay2Rows.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelItemsDisplay2Rows.Location = new Point(130, 122);
            labelItemsDisplay2Rows.Name = "labelItemsDisplay2Rows";
            labelItemsDisplay2Rows.Size = new Size(595, 24);
            labelItemsDisplay2Rows.TabIndex = 113;
            labelItemsDisplay2Rows.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 ";
            labelItemsDisplay2Rows.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30";
            // 
            // labelAnchorLinkLabels
            // 
            labelAnchorLinkLabels.BorderStyle = BorderStyle.FixedSingle;
            labelAnchorLinkLabels.Location = new Point(746, 122);
            labelAnchorLinkLabels.Name = "labelAnchorLinkLabels";
            labelAnchorLinkLabels.Size = new Size(60, 24);
            labelAnchorLinkLabels.TabIndex = 112;
            labelAnchorLinkLabels.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 ";
            labelAnchorLinkLabels.Text = "  List of subclassed LinkLabel controls, representing linked items.  Newly-operated items will be designated as Visited.";
            // 
            // linkToPenultimate
            // 
            linkToPenultimate.AutoSize = true;
            linkToPenultimate.Location = new Point(611, 44);
            linkToPenultimate.Name = "linkToPenultimate";
            linkToPenultimate.Size = new Size(19, 15);
            linkToPenultimate.TabIndex = 111;
            linkToPenultimate.TabStop = true;
            linkToPenultimate.Text = "29";
            // 
            // linkToEndpoint
            // 
            linkToEndpoint.AutoSize = true;
            linkToEndpoint.Location = new Point(636, 44);
            linkToEndpoint.Name = "linkToEndpoint";
            linkToEndpoint.Size = new Size(19, 15);
            linkToEndpoint.TabIndex = 110;
            linkToEndpoint.TabStop = true;
            linkToEndpoint.Tag = "Link to ";
            linkToEndpoint.Text = "30";
            // 
            // linkEndpointHeading
            // 
            linkEndpointHeading.AutoSize = true;
            linkEndpointHeading.Location = new Point(479, 44);
            linkEndpointHeading.Name = "linkEndpointHeading";
            linkEndpointHeading.Size = new Size(126, 15);
            linkEndpointHeading.TabIndex = 109;
            linkEndpointHeading.TabStop = true;
            linkEndpointHeading.Text = "Use Final Endpoint.......";
            // 
            // linkSingleItemOnly
            // 
            linkSingleItemOnly.AutoSize = true;
            linkSingleItemOnly.Location = new Point(746, 75);
            linkSingleItemOnly.Name = "linkSingleItemOnly";
            linkSingleItemOnly.Size = new Size(140, 15);
            linkSingleItemOnly.TabIndex = 108;
            linkSingleItemOnly.TabStop = true;
            linkSingleItemOnly.Text = "Toggle Single-Item Mode";
            // 
            // labelNumOperations
            // 
            labelNumOperations.AutoSize = true;
            labelNumOperations.Location = new Point(695, 16);
            labelNumOperations.Name = "labelNumOperations";
            labelNumOperations.Size = new Size(99, 15);
            labelNumOperations.TabIndex = 107;
            labelNumOperations.Tag = "Number of ops: {0}";
            labelNumOperations.Text = "Number of ops: 0";
            // 
            // buttonUndo
            // 
            buttonUndo.Enabled = false;
            buttonUndo.Location = new Point(680, 32);
            buttonUndo.Name = "buttonUndo";
            buttonUndo.Size = new Size(114, 27);
            buttonUndo.TabIndex = 106;
            buttonUndo.Text = "<<< Undo";
            buttonUndo.UseVisualStyleBackColor = true;
            // 
            // buttonReDo
            // 
            buttonReDo.Enabled = false;
            buttonReDo.Location = new Point(800, 32);
            buttonReDo.Name = "buttonReDo";
            buttonReDo.Size = new Size(86, 27);
            buttonReDo.TabIndex = 105;
            buttonReDo.Text = "Re-do >>>";
            buttonReDo.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(55, 59);
            Label3.Name = "Label3";
            Label3.Size = new Size(178, 15);
            Label3.TabIndex = 104;
            Label3.Text = "List of current column positions:";
            // 
            // labelItemsDisplay1Cols
            // 
            labelItemsDisplay1Cols.BackColor = Color.PaleGreen;
            labelItemsDisplay1Cols.BorderStyle = BorderStyle.FixedSingle;
            labelItemsDisplay1Cols.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelItemsDisplay1Cols.Location = new Point(130, 98);
            labelItemsDisplay1Cols.Name = "labelItemsDisplay1Cols";
            labelItemsDisplay1Cols.Size = new Size(595, 24);
            labelItemsDisplay1Cols.TabIndex = 103;
            labelItemsDisplay1Cols.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 ";
            labelItemsDisplay1Cols.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30";
            // 
            // labelBenchmark
            // 
            labelBenchmark.BorderStyle = BorderStyle.FixedSingle;
            labelBenchmark.Location = new Point(75, 74);
            labelBenchmark.Name = "labelBenchmark";
            labelBenchmark.Size = new Size(598, 24);
            labelBenchmark.TabIndex = 102;
            labelBenchmark.Tag = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 ";
            labelBenchmark.Text = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 ";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(32, 44);
            Label1.Name = "Label1";
            Label1.Size = new Size(226, 15);
            Label1.TabIndex = 101;
            Label1.Text = "List of column positions, as a benchmark:";
            // 
            // LabelHdrRowHeaders
            // 
            LabelHdrRowHeaders.BackColor = Color.Plum;
            LabelHdrRowHeaders.BorderStyle = BorderStyle.FixedSingle;
            LabelHdrRowHeaders.Location = new Point(20, 149);
            LabelHdrRowHeaders.Name = "LabelHdrRowHeaders";
            LabelHdrRowHeaders.Size = new Size(104, 419);
            LabelHdrRowHeaders.TabIndex = 117;
            LabelHdrRowHeaders.Tag = "Vertical";
            // 
            // userOperationPartial1
            // 
            userOperationPartial1.BackColor = Color.Tan;
            userOperationPartial1.Location = new Point(130, 149);
            userOperationPartial1.Name = "userOperationPartial1";
            userOperationPartial1.Size = new Size(664, 419);
            userOperationPartial1.TabIndex = 118;
            userOperationPartial1.Load += userOperationPartial1_Load;
            // 
            // FormTestGrid2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 622);
            Controls.Add(userOperationPartial1);
            Controls.Add(LabelHdrRowHeaders);
            Controls.Add(LabelHdrVerticalRows);
            Controls.Add(LabelHdrHorizontalCols);
            Controls.Add(labelItemsDisplay2Rows);
            Controls.Add(labelAnchorLinkLabels);
            Controls.Add(linkToPenultimate);
            Controls.Add(linkToEndpoint);
            Controls.Add(linkEndpointHeading);
            Controls.Add(linkSingleItemOnly);
            Controls.Add(labelNumOperations);
            Controls.Add(buttonUndo);
            Controls.Add(buttonReDo);
            Controls.Add(Label3);
            Controls.Add(labelItemsDisplay1Cols);
            Controls.Add(labelBenchmark);
            Controls.Add(Label1);
            Controls.Add(Label2);
            Controls.Add(LabelHeader1);
            Name = "FormTestGrid2";
            Text = "FormTestGrid";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label Label2;
        internal Label LabelHeader1;
        internal Label LabelHdrVerticalRows;
        internal Label LabelHdrHorizontalCols;
        internal Label labelItemsDisplay2Rows;
        internal Label labelAnchorLinkLabels;
        internal LinkLabel linkToPenultimate;
        internal LinkLabel linkToEndpoint;
        internal LinkLabel linkEndpointHeading;
        internal LinkLabel linkSingleItemOnly;
        internal Label labelNumOperations;
        internal Button buttonUndo;
        internal Button buttonReDo;
        internal Label Label3;
        internal Label labelItemsDisplay1Cols;
        internal Label labelBenchmark;
        internal Label Label1;
        internal Label LabelHdrRowHeaders;
        private UserOperationPartial userOperationPartial1;
    }
}