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

namespace DentistToolClient
{
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '*';
            txtCPassword.PasswordChar = chkShowPass.Checked ? '\0' : '*';
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
                MessageBox.Show("You have to provide a Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if (txtPassword.Text == "" || txtCPassword.Text == "")
                MessageBox.Show("You have to provide a Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if (txtPassword.Text.Length < 8)
                MessageBox.Show("Password has to be atleast 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if (txtPassword.Text != txtCPassword.Text)
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                User reg = new User();
                reg.macadd = GetPhysicalAddress();
                reg.Username = txtUsername.Text;
                reg.Password = txtPassword.Text;
                AuthorizationController db = new AuthorizationController();
                var response = db.Register(reg);
                if (response.Success)
                {
                    MessageBox.Show(response.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAbout start = new frmAbout();
                    start.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                }
            }

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

        private void frmAddUser_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmAbout start = new frmAbout();
            start.Show();
            this.Close();

        }
    }
}
