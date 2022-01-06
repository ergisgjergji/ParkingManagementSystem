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

namespace ParkingManagementSystem.Manager
{
    public partial class PricesForm : Form
    {
        Price currPrice = new Price();

        public PricesForm()
        {
            InitializeComponent();
        }

        private void PricesForm_Load(object sender, EventArgs e)
        {
            PopulatePrices();
            Reset();
        }

        private void Reset()
        {
            txtPrice.Text = "";
            currPrice.Hours = -1;
        }

        private void PopulatePrices()
        {
            dgvPrices.Rows.Clear();
            dgvPrices.AutoGenerateColumns = false;
            using (DbEntities dbContext = new DbEntities())
            {
                var prices = dbContext.Prices.ToList();

                foreach (var pr in prices)
                {
                    dgvPrices.Rows.Add(pr.Hours, pr.Price1);
                }
            }
        }

        private void DgvPrices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Reset();

            currPrice.Hours = Convert.ToInt32(dgvPrices.CurrentRow.Cells["Hour"].Value.ToString());
            currPrice.Price1 = Convert.ToInt32(dgvPrices.CurrentRow.Cells["Price"].Value.ToString());

            txtPrice.Text = currPrice.Price1.ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void BtnUpdatePrice_Click(object sender, EventArgs e)
        {
            if (currPrice.Hours == -1)
            {
                MessageBox.Show("Please, select a record first.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (DbEntities dbContext = new DbEntities())
                {
                    currPrice = dbContext.Prices.Where(pr => pr.Hours == currPrice.Hours).FirstOrDefault();
                    currPrice.Price1 = Convert.ToInt32(txtPrice.Text.ToString());
                    if(currPrice.Price1 < 0)
                        MessageBox.Show("Invalid value.", "Success!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    else
                    {
                        dbContext.Entry(currPrice).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        MessageBox.Show("Price updated successfully.", "Success!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        PopulatePrices();
                        Reset();
                    }
                }
            }
        }
    }
}
