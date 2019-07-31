//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace ciLayoutDesign
//{
//    public partial class FormBetterFontDraw : Form
//    {
//        public FormBetterFontDraw()
//        {
//            InitializeComponent();
//        }


/*
 * http://www.java2s.com/Code/CSharp/2D-Graphics/SmoothingFonts.htm
User Interfaces in C#: Windows Forms and Custom Controls
by Matthew MacDonald

Publisher: Apress
ISBN: 1590590457
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace ciLayoutDesign  // GDI_Basics    http://www.java2s.com/Code/CSharp/2D-Graphics/SmoothingFonts.htm
{
    /// <summary>
    /// Summary description for SmoothingFonts.
    /// </summary>
    public partial class FormBetterFontDraw  //  SmoothingFonts()
    {
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;

         /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent_NotUsed()
        {
            //this.Label3 = new System.Windows.Forms.Label();
            //this.Label2 = new System.Windows.Forms.Label();
            //this.Label1 = new System.Windows.Forms.Label();
            //this.SuspendLayout();
            //// 
            //// Label3
            //// 
            //this.Label3.BackColor = System.Drawing.Color.White;
            //this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.Label3.Location = new System.Drawing.Point(272, 168);
            //this.Label3.Name = "Label3";
            //this.Label3.Size = new System.Drawing.Size(128, 16);
            //this.Label3.TabIndex = 5;
            //this.Label3.Text = " ClearTypeGridFit";
            //// 
            //// Label2
            //// 
            //this.Label2.BackColor = System.Drawing.Color.White;
            //this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.Label2.Location = new System.Drawing.Point(272, 100);
            //this.Label2.Name = "Label2";
            //this.Label2.Size = new System.Drawing.Size(128, 16);
            //this.Label2.TabIndex = 4;
            //this.Label2.Text = " AntiAliasGridFit";
            //// 
            //// Label1
            //// 
            //this.Label1.BackColor = System.Drawing.Color.White;
            //this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.Label1.Location = new System.Drawing.Point(272, 36);
            //this.Label1.Name = "Label1";
            //this.Label1.Size = new System.Drawing.Size(128, 16);
            //this.Label1.TabIndex = 3;
            //this.Label1.Text = " SingleBitPerPixelGridFit";
            //// 
            //// SmoothingFonts
            //// 
            //this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            //this.ClientSize = new System.Drawing.Size(440, 314);
            //this.Controls.AddRange(new System.Windows.Forms.Control[] {
            //                                                              this.Label3,
            //                                                              this.Label2,
            //                                                              this.Label1});
            //this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            //this.Name = "SmoothingFonts";
            //this.Text = "SmoothingFonts";
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.SmoothingFonts_Paint);
            //this.ResumeLayout(false);

        }

        [STAThread]
        static void Main_NotUsed()
        {
            //Application.Run(new SmoothingFonts());
            //Application.Run(new FormBetterFontDraw());
        }

        private void FormBetterFontDraw_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Font TextFont = new Font("Times New Roman", 25, FontStyle.Italic);
            e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 20);
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 85);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 150);
        }

        private void FormBetterFontDraw_Load(object sender, EventArgs e)
        {

        }

        private void ButtonPaintForm_Click(object sender, EventArgs e)
        {
            //Added 7/30/2019
            //
            this.Refresh();

        }
    }
}
