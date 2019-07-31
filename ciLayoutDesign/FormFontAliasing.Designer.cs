namespace ciLayoutDesign
{
    partial class FormFontAliasing
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
            this.buttonPaintForm = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPaintForm
            // 
            this.buttonPaintForm.Location = new System.Drawing.Point(617, 275);
            this.buttonPaintForm.Name = "buttonPaintForm";
            this.buttonPaintForm.Size = new System.Drawing.Size(99, 31);
            this.buttonPaintForm.TabIndex = 10;
            this.buttonPaintForm.Text = "Paint Form";
            this.buttonPaintForm.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.Location = new System.Drawing.Point(576, 180);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(128, 16);
            this.Label3.TabIndex = 9;
            this.Label3.Text = " ClearTypeGridFit";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Location = new System.Drawing.Point(576, 112);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(128, 16);
            this.Label2.TabIndex = 8;
            this.Label2.Text = " AntiAliasGridFit";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Location = new System.Drawing.Point(576, 48);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(128, 16);
            this.Label1.TabIndex = 7;
            this.Label1.Text = " SingleBitPerPixelGridFit";
            // 
            // FormFontAliasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 353);
            this.Controls.Add(this.buttonPaintForm);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "FormFontAliasing";
            this.Text = "FormFontAliasing";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormFontAliasing_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPaintForm;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}