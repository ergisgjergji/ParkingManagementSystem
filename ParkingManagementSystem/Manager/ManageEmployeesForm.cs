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
using ParkingManagementSystem;
using ParkingManagementSystem.Domain;

namespace ParkingManagementSystem.Manager
{
    public partial class ManageEmployeesForm : Form
    {
        User currUser = new User();

        public ManageEmployeesForm()
        {
            InitializeComponent();
        }

        private void ManageEmployeesForm_Load(object sender, EventArgs e)
        {
            PopulateEmployees();
            Reset();
        }

        private void Reset()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPw.Text = "";
            radioEmployee.Checked = false;
            radioManager.Checked = false;
            currUser.Username = "";
        }

        // Populate table
        private void PopulateEmployees()
        {
            dgvEmployees.Rows.Clear();
            dgvEmployees.AutoGenerateColumns = false;
            using (DbEntities dbContext = new DbEntities())
            {
                var employees = dbContext.Users.ToList();

                foreach (var emp in employees)
                {
                    dgvEmployees.Rows.Add(emp.FirstName, emp.LastName, emp.Username, emp.Role.Role1, emp.Password);
                }
            }
        }

        // Form reset
        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void DgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Reset();

            currUser.Username = dgvEmployees.CurrentRow.Cells["Username"].Value.ToString();
            using (DbEntities dbContext = new DbEntities())
            {
                currUser = dbContext.Users.Where(usr => usr.Username == currUser.Username).FirstOrDefault();

                txtFirstName.Text = currUser.FirstName;
                txtLastName.Text = currUser.LastName;
                txtUsername.Text = currUser.Username;
                if (currUser.Role.Role1 == "Menaxher")
                    radioManager.Checked = true;
                else if (currUser.Role.Role1 == "Punonjes")
                    radioEmployee.Checked = true;
            }
        }

        // Create
        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                User user = new User();
                user.FirstName = txtFirstName.Text.ToString();
                user.LastName = txtLastName.Text.ToString();
                user.Username = txtUsername.Text.ToString();
                user.Password = GenerateHashedPassword.Generate256Hash(txtPw.Text.ToString());
                
                using (DbEntities dbContext = new DbEntities())
                {
                    var dbUser = dbContext.Users.Where(usr => usr.Username == user.Username).FirstOrDefault();
                    if(dbUser != null)
                        MessageBox.Show("Employee with that username already exists.", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (radioEmployee.Checked == true)
                            user.Role = dbContext.Roles.Where(rl => rl.Role1 == "Punonjes").FirstOrDefault();
                        else if (radioManager.Checked == true)
                            user.Role = dbContext.Roles.Where(rl => rl.Role1 == "Menaxher").FirstOrDefault();

                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        MessageBox.Show("Employee added successfully.", "Success!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        PopulateEmployees();
                        Reset();
                    }
                }
            }
        }

        // Update
        private void BtnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (currUser.Username == "")
            {
                MessageBox.Show("Please, select a record first.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (isFormValid())
                {
                    currUser.FirstName = txtFirstName.Text.ToString();
                    currUser.LastName = txtLastName.Text.ToString();
                    currUser.Username = txtUsername.Text.ToString();
                    currUser.Password = GenerateHashedPassword.Generate256Hash(txtPw.Text.ToString());

                    using (DbEntities dbContext = new DbEntities())
                    {
                            if (radioEmployee.Checked == true)
                                currUser.Role = dbContext.Roles.Where(rl => rl.Role1 == "Punonjes").FirstOrDefault();
                            else if (radioManager.Checked == true)
                                currUser.Role = dbContext.Roles.Where(rl => rl.Role1 == "Menaxher").FirstOrDefault();

                            dbContext.Entry(currUser).State = EntityState.Modified;
                            dbContext.SaveChanges();
                            MessageBox.Show("Employee's data updated successfully.", "Success!", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            PopulateEmployees();
                    }
                }
            }
        }

        // Delete
        private void BtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (currUser.Username == "")
                MessageBox.Show("Please, select a record first.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (MessageBox.Show("Are you sure you want to permanently delete this record?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (DbEntities dbContext = new DbEntities())
                    {
                        currUser = dbContext.Users.Where(usr => usr.Username == currUser.Username).FirstOrDefault();

                        var entry = dbContext.Entry(currUser);
                        if (entry.State == EntityState.Detached)
                            dbContext.Users.Attach(currUser);

                        dbContext.Users.Remove(currUser);
                        dbContext.SaveChanges();

                        PopulateEmployees();
                        Reset();
                    }
                }
            }
        }

        // Form validation
        private bool isFormValid()
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("First name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtLastName.Text == "")
            {
                MessageBox.Show("Last name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtUsername.Text == "")
            {
                MessageBox.Show("First name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPw.Text == "" || txtPw.Text.Length < 6)
            {
                MessageBox.Show("Password name is required.\nIt must be at least 6 characters.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (radioEmployee.Checked == false && radioManager.Checked == false)
            {
                MessageBox.Show("Please select a role.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
