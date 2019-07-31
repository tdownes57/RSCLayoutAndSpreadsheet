using System.Windows.Forms;

namespace ciLayoutDesign
{
    public partial class FormBetterFontDraw : Form
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
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.buttonPaintForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.Location = new System.Drawing.Point(272, 168);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(128, 16);
            this.Label3.TabIndex = 5;
            this.Label3.Text = " ClearTypeGridFit";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Location = new System.Drawing.Point(272, 100);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(128, 16);
            this.Label2.TabIndex = 4;
            this.Label2.Text = " AntiAliasGridFit";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Location = new System.Drawing.Point(272, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(128, 16);
            this.Label1.TabIndex = 3;
            this.Label1.Text = " SingleBitPerPixelGridFit";
            // 
            // buttonPaintForm
            // 
            this.buttonPaintForm.Location = new System.Drawing.Point(313, 263);
            this.buttonPaintForm.Name = "buttonPaintForm";
            this.buttonPaintForm.Size = new System.Drawing.Size(99, 31);
            this.buttonPaintForm.TabIndex = 6;
            this.buttonPaintForm.Text = "Paint Form";
            this.buttonPaintForm.UseVisualStyleBackColor = true;
            this.buttonPaintForm.Click += new System.EventHandler(this.ButtonPaintForm_Click);
            // 
            // FormBetterFontDraw
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(440, 314);
            this.Controls.Add(this.buttonPaintForm);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormBetterFontDraw";
            this.Text = "SmoothingFonts";
            this.Load += new System.EventHandler(this.FormBetterFontDraw_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormBetterFontDraw_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonPaintForm;
    }
}