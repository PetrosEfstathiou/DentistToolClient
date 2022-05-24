using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentistToolClient
{
    public partial class frmViewFormula : Form
    {
        Image returnImage = Image.FromStream(frmViewPatient.STreatment);
        public frmViewFormula()
        {
            InitializeComponent();
        }

        private void frmViewFormula_Load(object sender, EventArgs e)
        {

            pictureBox1.Width = returnImage.Width;
            pictureBox1.Height = returnImage.Height;
            pictureBox1.Image = returnImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
