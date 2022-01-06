using ParkingManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ParkingManagementSystem
{
	public partial class EmployeeForm : Form
	{
		private bool dropDown;

		public static int slotNumber;

		public EmployeeForm()
		{
			InitializeComponent();
		}

		private void EmployeeForm_Load(object sender, EventArgs e)
		{
			timer1.Start();
			dropDown = false;
			dropdownPanel.Height = 56;
			UpdateUI();
		}

		private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				e.Cancel = false;
				LoginForm login = new LoginForm();
				login.Show();
			}
			else
				e.Cancel = true;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			lblClock.Text = DateTime.Now.ToLongTimeString();
		}

		private void btnTickets_Click(object sender, EventArgs e)
		{
			if (dropDown == false)
			{
				dropDown = true;
				dropdownPanel.Height = 172;
			}
			else if (dropDown == true)
			{
				dropDown = false;
				dropdownPanel.Height = 56;
			}
		}

		private void UpdateUI()
		{
			flowSlots.Controls.Clear();

			lblEmployee.Text = "";
			lblEmployee.Text = LoginForm.user.FirstName + " " + LoginForm.user.LastName;

			using (DbEntities dbContext = new DbEntities())
			{
				var slots = dbContext.Slots.ToList();

				var free = slots.Where(sl => sl.isFree == true).ToList();
				lblFreeSlots.Text = free.Count.ToString();

				var busy = slots.Where(sl => sl.isFree == false).ToList();
				lblBusySlots.Text = busy.Count.ToString();
				
				foreach (var slot in slots)
				{
					Button btn = new Button();
					btn.Size = new Size(110,110);
					btn.Text = slot.Number.ToString();
					btn.Font = new Font("Arial",20,FontStyle.Bold);
					btn.Margin = new Padding(20,20,20,20);

					if (slot.isFree == true)
						btn.BackColor = Color.LightGray;
					else if (slot.isFree == false)
						btn.BackColor = Color.LimeGreen;

					btn.Click += Btn_Click;

					flowSlots.Controls.Add(btn);
				}
			}
		}

		private void Btn_Click(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			slotNumber = Convert.ToInt32(btn.Text);

			using (DbEntities dbContext = new DbEntities())
			{
				var slot = dbContext.Slots.Where(sl => sl.Number == EmployeeForm.slotNumber).FirstOrDefault();
				if (slot.isFree == true)
				{
					CheckinForm checkinForm = new CheckinForm();
					checkinForm.ShowDialog();
					UpdateUI();
				}
				else if (slot.isFree == false)
				{
					CheckoutForm checkoutForm = new CheckoutForm();
					checkoutForm.ShowDialog();
					UpdateUI();
				}
			}
		}

		private void btnClients_Click(object sender, EventArgs e)
		{
			ClientForm clForm = new ClientForm();
			clForm.ShowDialog();
		}

		private void btnAllTickets_Click(object sender, EventArgs e)
		{
			TicketsForm ticketsF = new TicketsForm();
			ticketsF.ShowDialog();
		}

		private void btnActive_Click(object sender, EventArgs e)
		{
			ActiveTickets activeTicketsF = new ActiveTickets();
			activeTicketsF.ShowDialog();
		}

		private void btnChangePw_Click(object sender, EventArgs e)
		{
			ChangePasswordForm passForm = new ChangePasswordForm();
			passForm.ShowDialog();
		}

    }
}
