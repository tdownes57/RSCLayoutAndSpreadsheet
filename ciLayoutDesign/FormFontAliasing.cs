using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;  //  http://www.java2s.com/Code/CSharp/2D-Graphics/SmoothingFonts.htm

namespace ciLayoutDesign
{
    public partial class FormFontAliasing : Form
    {
        public FormFontAliasing()
        {
            InitializeComponent();
        }

        private void FormFontAliasing_Paint(object sender, PaintEventArgs e)
        {
            Font TextFont = new Font("Times New Roman", 25, FontStyle.Italic);
            e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 20);
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 85);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 150);
        }
    }
}
