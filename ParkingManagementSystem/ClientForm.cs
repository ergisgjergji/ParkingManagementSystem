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
	public partial class ClientForm : Form
	{
		Client currClient = new Client();
		Car currCar = new Car();

		public ClientForm()
		{
			InitializeComponent();
		}

		private void ClientForm_Load(object sender, EventArgs e)
		{
			PopulateClients();
			ClearClient();
			ClearCar();
		}

		private void ClearClient()
		{
			txtFirstName.Text = "";
			txtLastName.Text = "";
			rdbFemale.Checked = false;
			rdbMale.Checked = false;
			txtID.Text = "";
			txtCardNumber.Text = "";
			txtDiscount.Text = "";
			currClient.ID = "";
		}
		private void ClearCar()
		{
			txtBrand.Text = "";
			txtModel.Text = "";
			txtPlate.Text = "";
			currCar.PlateNumber = "";
		}

        // Reset
		private void btnReset1_Click(object sender, EventArgs e)
		{
			ClearClient();
		}
        private void btnReset2_Click(object sender, EventArgs e)
        {
            ClearCar();
        }

        // Populate tables
        private void PopulateClients()
		{
			dgvClients.Rows.Clear();
			dgvClients.AutoGenerateColumns = false;
			using (DbEntities dbContext = new DbEntities())
			{
				var clients = dbContext.Clients.ToList();
				foreach (var cl in clients)
				{
					dgvClients.Rows.Add(cl.FirstName, cl.LastName, cl.Gender, cl.DateOfBirth, cl.ID, cl.CardNumber,
						cl.Discount);
				}
			}
		}
		private void PopulateCars()
		{
			dgvCars.Rows.Clear();
			dgvCars.AutoGenerateColumns = false;
			using (DbEntities dbContext = new DbEntities())
			{
				var cars = dbContext.Cars.Where(cr => cr.ClientID == currClient.ID);
				foreach (var cr in cars)
				{
					dgvCars.Rows.Add(cr.PlateNumber,cr.Brand,cr.Model);
				}
			}
		}

        // Add 
		private void btnSaveClient_Click(object sender, EventArgs e)
		{
			if (isClientFormValid())
			{
				Client client = new Client();
				client.FirstName = txtFirstName.Text;
				client.LastName = txtLastName.Text;
				if (rdbMale.Checked == true)
					client.Gender = "Male";
				else
					client.Gender = "Female";
				client.DateOfBirth = dateTimePicker2.Value;
				client.ID = txtID.Text.Trim();
				client.CardNumber = Convert.ToInt32(txtCardNumber.Text.Trim());
				client.Discount = Convert.ToInt32(txtDiscount.Text);
				using (DbEntities dbContext = new DbEntities())
				{
					var dbClient = dbContext.Clients.Where(cl => cl.ID == client.ID).FirstOrDefault();
					if (dbClient != null)
						MessageBox.Show("Client already exists.", "", 
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
					else
					{
						dbContext.Clients.Add(client);
						dbContext.SaveChanges();
                        MessageBox.Show("Client added successfully.", "Success!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
						ClearClient();
						PopulateClients();
					}
				}
			}
		}
        private void btnSaveCar_Click(object sender, EventArgs e)
        {
            if (currClient.ID != null)
            {
                if (isCarFormValid())
                {
                    Car car = new Car();
                    car.Brand = txtBrand.Text;
                    car.Model = txtModel.Text;
                    car.PlateNumber = txtPlate.Text.Trim();
                    car.ClientID = currClient.ID;
                    using (DbEntities dbContext = new DbEntities())
                    {
                        var dbCar = dbContext.Cars.Where(cr => cr.PlateNumber == car.PlateNumber).FirstOrDefault();
                        if (dbCar != null)
                        {
                            MessageBox.Show("This car already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            dbContext.Cars.Add(car);
                            dbContext.SaveChanges();
                            MessageBox.Show("Car registered successfully.", "Success!", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            ClearCar();
                            PopulateCars();
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("No client selected.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Update
		private void btnUpdate1_Click(object sender, EventArgs e)
		{
			if (currClient.ID == "")
			{
				MessageBox.Show("Please, select a record first.","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
			else
			{
				if (isClientFormValid())
				{
					currClient.FirstName = txtFirstName.Text;
					currClient.LastName = txtLastName.Text;
					if (rdbMale.Checked == true)
						currClient.Gender = "Male";
					else
						currClient.Gender = "Female";
					currClient.DateOfBirth = dateTimePicker2.Value;
					currClient.ID = txtID.Text.Trim();
					currClient.CardNumber = Convert.ToInt32(txtCardNumber.Text.Trim());
					currClient.Discount = Convert.ToInt32(txtDiscount.Text);
					using (DbEntities dbContext = new DbEntities())
					{
						dbContext.Entry(currClient).State = EntityState.Modified;
						dbContext.SaveChanges();
						MessageBox.Show("Updated successfully.", "Success!", MessageBoxButtons.OK,
							MessageBoxIcon.Information);
						PopulateClients();
						
					}
				}
			}
		}
		private void btnUpdate2_Click(object sender, EventArgs e)
		{
			if (currCar.PlateNumber == "")
			{
				MessageBox.Show("Please, select a record first.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				if (isCarFormValid())
				{
					currCar.Brand = txtBrand.Text;
					currCar.Model = txtModel.Text;
					currCar.PlateNumber = txtPlate.Text.Trim();

					using (DbEntities dbContext = new DbEntities())
					{
						dbContext.Entry(currCar).State = EntityState.Modified;
						dbContext.SaveChanges();
						MessageBox.Show("Updated successfully.", "Success!", MessageBoxButtons.OK,
							MessageBoxIcon.Information);
						PopulateCars();
					}
				}
			}
		}

        // Detele
		private void btnDelete1_Click(object sender, EventArgs e)
		{
			if(currClient.ID == "")
				MessageBox.Show("Please, select a record first.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
			{
				if (MessageBox.Show("Are you sure you want to permanently delete this record?", "Confirm",
						MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					using (DbEntities dbContext = new DbEntities())
					{
						var entry = dbContext.Entry(currClient);
						if (entry.State == EntityState.Detached)
							dbContext.Clients.Attach(currClient);

						dbContext.Clients.Remove(currClient);
						dbContext.SaveChanges();

						ClearClient();
						PopulateClients();
					}
				}
			}
		}
		private void btnDelete2_Click(object sender, EventArgs e)
		{
			if (currCar.PlateNumber == "")
				MessageBox.Show("Please, select a record first.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
			{
				if (MessageBox.Show("Are you sure you want to permanently delete this record?", "Confirm",
						MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					using (DbEntities dbContext = new DbEntities())
					{
						var entry = dbContext.Entry(currCar);
						if (entry.State == EntityState.Detached)
							dbContext.Cars.Attach(currCar);

						dbContext.Cars.Remove(currCar);
						dbContext.SaveChanges();

						ClearCar();
						PopulateCars();
					}
				}
			}
		}

        // Table cells click
        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearCar();

            currClient.ID = dgvClients.CurrentRow.Cells["ID"].Value.ToString();
            using (DbEntities dbContext = new DbEntities())
            {
                currClient = dbContext.Clients.Where(cl => cl.ID == currClient.ID).FirstOrDefault();

                txtFirstName.Text = currClient.FirstName;
                txtLastName.Text = currClient.LastName;
                if (currClient.Gender == "Male")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                dateTimePicker2.Value = currClient.DateOfBirth;
                txtID.Text = currClient.ID;
                txtCardNumber.Text = currClient.CardNumber.ToString();
                txtDiscount.Text = currClient.Discount.ToString();

                PopulateCars();
            }
        }
        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currCar.PlateNumber = dgvCars.CurrentRow.Cells["PlateNumber"].Value.ToString();
            using (DbEntities dbContext = new DbEntities())
            {
                currCar = dbContext.Cars.Where(cr => cr.PlateNumber == currCar.PlateNumber).FirstOrDefault();
            }

            txtBrand.Text = currCar.Brand;
            txtModel.Text = currCar.Model;
            txtPlate.Text = currCar.PlateNumber;
        }

        // Form validation
        private bool isClientFormValid()
        {
            int x;

            if (txtFirstName.Text == "")
            {
                MessageBox.Show("First name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Last name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (rdbMale.Checked == false && rdbFemale.Checked == false)
            {
                MessageBox.Show("Gender is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (dateTimePicker2.Value >= DateTime.Now)
            {
                MessageBox.Show("Please choose a correct date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtID.Text == "" || txtID.Text.Length > 10)
            {
                MessageBox.Show("Enter a correct ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtCardNumber.Text == "" || !int.TryParse(txtCardNumber.Text, out x))
            {
                MessageBox.Show("Enter a correct card number.\nOnly digits!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtDiscount.Text == "" || !int.TryParse(txtDiscount.Text, out x) || Convert.ToInt32(txtDiscount.Text) > 100)
            {
                MessageBox.Show("Enter a correct value for discount.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool isCarFormValid()
        {
            if (txtBrand.Text == "")
            {
                MessageBox.Show("Brand is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtModel.Text == "")
            {
                MessageBox.Show("Model is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtPlate.Text == "" || txtPlate.Text.Length > 10)
            {
                MessageBox.Show("Please enter a correct plate number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}
