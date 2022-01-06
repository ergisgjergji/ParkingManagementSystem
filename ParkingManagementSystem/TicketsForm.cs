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

namespace ParkingManagementSystem
{
	public partial class TicketsForm : Form
	{
		public TicketsForm()
		{
			InitializeComponent();
		}

		private void TicketsForm_Load(object sender, EventArgs e)
		{
			PopulateTickets();
		}

		private void PopulateTickets()
		{
			dgvAllTickets.Rows.Clear();
			dgvAllTickets.AutoGenerateColumns = false;
			using (DbEntities dbContext = new DbEntities())
			{
				var tickets = dbContext.Tickets.ToList();
				foreach (var tick in tickets)
				{
					dgvAllTickets.Rows.Add(tick.ID, tick.SlotNumber, tick.PlateNumber, tick.CheckIn, tick.CheckOut,
						tick.Price);
				}
			}
		}
	}
}
