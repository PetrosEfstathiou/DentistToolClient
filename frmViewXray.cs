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
    
    public partial class frmViewXray : Form
    {
        Image returnImage = Image.FromStream(frmViewPatient.SXray);
        public frmViewXray()
        {
            


            InitializeComponent();
        }

        private void frmViewXray_Load(object sender, EventArgs e)
        {
            this.Height = returnImage.Height + 21;
            this.Width = returnImage.Width + 16;
            this.StartPosition = FormStartPosition.CenterScreen;

            pictureBox1.Width = returnImage.Width;
            pictureBox1.Height = returnImage.Height;
            pictureBox1.Image = returnImage;
        }
    }
}
