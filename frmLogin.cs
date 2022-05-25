using DentistToolClient.CRUD;
using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DentistToolClient.Globals;

namespace DentistToolClient
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
                MessageBox.Show("You have to provide a Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if (txtPassword.Text == "")
                MessageBox.Show("You have to provide a Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                User reg = new User();
                reg.macadd = GetPhysicalAddress();
                reg.Username = txtUsername.Text;
                reg.Password = txtPassword.Text;
                AuthorizationController db = new AuthorizationController();
                var response = db.Login(reg);
                if (response.Success)
                {
                    JWTtoken = "bearer " + response.Data;
                    frmMainMenu mm = new frmMainMenu();
                    mm.Show();
                   this.Hide();
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                }
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '*';
        }

        public string GetPhysicalAddress()
        {
            String MacAddress = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();
            return MacAddress;
        }
    }
}
