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
	public partial class ActiveTickets : Form
	{
		public ActiveTickets()
		{
			InitializeComponent();
		}

		private void ActiveTickets_Load(object sender, EventArgs e)
		{
			PopulateActiveTickets();
		}

		private void PopulateActiveTickets()
		{
			dgvActiveTickets.Rows.Clear();
			dgvActiveTickets.AutoGenerateColumns = false;
			using (DbEntities dbContext = new DbEntities())
			{
				var tickets = dbContext.Tickets.Where(tick => tick.CheckOut == null).ToList();
				foreach (var tick in tickets)
				{
					dgvActiveTickets.Rows.Add(tick.ID, tick.SlotNumber, tick.PlateNumber, tick.CheckIn, tick.CheckOut,
						tick.Price);
				}
			}
		}
	}
}
