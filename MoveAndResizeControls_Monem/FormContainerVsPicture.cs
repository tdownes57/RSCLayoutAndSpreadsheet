using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveAndResizeControls_Monem
{

    //public bool LetsPassToMouseUp_PictureControl = false;
    //public bool LetsPassToMouseUp_ElementContainer = false;  


    public partial class FormContainerVsPicture : Form
    {

        public static bool LetsPassElementContainerToMouseControl()
        {
            // Added 12/2/2021 thomas downes
            //
            var objFormToShow = new FormContainerVsPicture();

            objFormToShow.ShowDialog();
            return objFormToShow.LetsPassToMouseUp_ElementContainer;

        }

        public bool LetsPassToMouseUp_PictureControl = false;
        public bool LetsPassToMouseUp_ElementContainer = false;


        public FormContainerVsPicture()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormContainerVsPicture_Load(object sender, EventArgs e)
        {

        }

        private void buttonContainer_Click(object sender, EventArgs e)
        {
            //Added 12/2/2021 thomas downes
            this.LetsPassToMouseUp_ElementContainer = true;
            this.LetsPassToMouseUp_PictureControl = false;
            this.Close();  
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            //Added 12/2/2021 thomas downes
            this.LetsPassToMouseUp_ElementContainer = false;
            this.LetsPassToMouseUp_PictureControl = true;
            this.Close();
        }
    }
}
