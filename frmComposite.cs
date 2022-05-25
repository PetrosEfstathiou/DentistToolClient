using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentistToolClient
{
    
    public partial class frmComposite : Form
    {
        public frmComposite()
        {
            InitializeComponent();
        }

        private void frmComposite_Load(object sender, EventArgs e)
        {

            //https://stackoverflow.com/questions/6842750/merge-two-png-images-with-transparency-and-retain-transparency
            var composite = new Bitmap(1001, 640, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(composite);
            graphics.CompositingMode = CompositingMode.SourceOver;

            for (int i = 0; i < frmViewPatient.composite.Count; i++)
            {
                Image returnImage = Image.FromStream(frmViewPatient.composite[i]);
                graphics.DrawImage(returnImage, 0, 0);
            }
            pictureBox1.Image = composite;

        }


    }
}
