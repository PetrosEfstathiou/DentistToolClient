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
    public partial class UserControlDayView : UserControl
    {
        public UserControlDayView()
        {
            InitializeComponent();
        }

        private void userControlDays1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Addflp(Control uc)
        {
            flowLayoutPanel1.Controls.Add(uc);
        }

        public void Clearflp()
        {
            flowLayoutPanel1.Controls.Clear();
        }
    }
}
