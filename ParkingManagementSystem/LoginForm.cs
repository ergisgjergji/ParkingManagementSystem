using ParkingManagementSystem.Domain;
using ParkingManagementSystem.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagementSystem
{
	public partial class LoginForm : Form
	{
		public static User user;

		public LoginForm()
		{
			InitializeComponent();
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			user = null;
			Clear();
		}

		private void Clear()
		{
			txtUsername.Text = "";
			txtPassword.Text = "";
		}

        // Login
		private void button1_Click(object sender, EventArgs e)
		{
            Login();
		}

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        // Form validation
        private void Login()
        {
            if (isFormValid())
            {
                var username = txtUsername.Text.Trim();
                var pw = GenerateHashedPassword.Generate256Hash(txtPassword.Text.Trim());

                using (DbEntities dbContext = new DbEntities())
                {
                    user = dbContext.Users.Where(usr => usr.Username == username && usr.Password == pw)
                        .FirstOrDefault();
                    if (user != null)
                    {
                        if (user.Role.Role1 == "Punonjes")
                        {
                            EmployeeForm empForm = new EmployeeForm();
                            Clear();
                            this.Hide();
                            empForm.Show();
                        }
                        else if (user.Role.Role1 == "Menaxher")
                        {
                            ManagerForm mngForm = new ManagerForm();
                            Clear();
                            this.Hide();
                            mngForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong username/password.", "Data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool isFormValid()
		{
			if (txtUsername.Text == "")
			{
				MessageBox.Show("Username is required.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			else if (txtPassword.Text == "")
			{
				MessageBox.Show("Password is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}
    }
}
