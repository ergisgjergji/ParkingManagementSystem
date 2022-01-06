using ParkingManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagementSystem
{
	public partial class ChangePasswordForm : Form
	{
		public ChangePasswordForm()
		{
			InitializeComponent();
		}

		private void ChangePasswordForm_Load(object sender, EventArgs e)
		{
			Clear();
		}

		private void Clear()
		{
			txtOldPw.Text = "";
			txtNewPw.Text = "";
			txtConfirmPw.Text = "";
		}

		private void btnSavePw_Click(object sender, EventArgs e)
		{
			if (isFormValid())
			{
				string oldPw = GenerateHashedPassword.Generate256Hash(txtOldPw.Text.Trim());
				if (LoginForm.user.Password.ToLower() != oldPw)
				{
					MessageBox.Show("The password you entered was incorrect.","Incorrect",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
				else
				{
					LoginForm.user.Password = GenerateHashedPassword.Generate256Hash(txtNewPw.Text);
					using (DbEntities dbContext = new DbEntities())
					{
						dbContext.Entry(LoginForm.user).State = EntityState.Modified;
						dbContext.SaveChanges();
						Clear();
						MessageBox.Show("Password was changed successfully.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
						this.Close();
					}
				}
			}
		}

		private bool isFormValid()
		{
			if (txtOldPw.Text == "")
			{
				MessageBox.Show("Enter the old password.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			else if (txtNewPw.Text == "" || txtNewPw.Text.Length < 6)
			{
				MessageBox.Show("Enter a correct password.\nAt least 6 digits required!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			else if (txtConfirmPw.Text == "")
			{
				MessageBox.Show("Please confirm the password.","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
			else if (txtConfirmPw.Text != txtNewPw.Text)
			{
				MessageBox.Show("Passwords do not match.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

	}
}
