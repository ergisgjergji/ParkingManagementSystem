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

namespace ParkingManagementSystem.Manager
{
    public partial class MonthlyDataForm : Form
    {
        public MonthlyDataForm()
        {
            InitializeComponent();
        }

        private void MonthlyDataForm_Load(object sender, EventArgs e)
        {
            PopulateMonthlyData();
        }

        private void PopulateMonthlyData()
        {
            dgvMonthlyData.Rows.Clear();
            dgvMonthlyData.AutoGenerateColumns = false;

            List<Client> clients = new List<Client>();

            int day = 0;
            for(day = 1; day <= 30; day++)
            {
                using(DbEntities dbContext = new DbEntities())
                {
                    clients = dbContext.Clients.ToList();

                    int totalHours, totalPrice;
                    int hours, days, months;

                    foreach(var client in clients)
                    {
                        totalHours = 0;
                        totalPrice = 0;
                        hours = 0; days = 0; months = 0;

                        var tickets = dbContext.Tickets.Where(tc => 
                        tc.ClientID == client.ID && 
                        tc.CheckOut.Value.Month == DateTime.Now.Month &&
                        tc.CheckOut.Value.Day == day)
                            .ToList();

                        // If client has no ticket for current day
                        if (tickets.Count < 1)
                        {
                            dgvMonthlyData.Rows.Add(day.ToString(), client.FirstName + " " + client.LastName, totalHours.ToString(), totalPrice.ToString());
                        }
                        else
                        {
                            foreach (var ticket in tickets)
                            {
                                // Counting hours
                                if (ticket.CheckOut.Value.Hour < ticket.CheckIn.Hour)
                                {
                                    hours = ticket.CheckOut.Value.Hour + 24 - ticket.CheckIn.Hour;
                                    days--;
                                }
                                else
                                    hours = ticket.CheckOut.Value.Hour - ticket.CheckIn.Hour;

                                // Counting days
                                if (ticket.CheckOut.Value.Day < ticket.CheckIn.Day)
                                {
                                    days += ticket.CheckOut.Value.Day + 30 - ticket.CheckIn.Day;
                                    months--;
                                }
                                else
                                    days += ticket.CheckOut.Value.Day - ticket.CheckIn.Day;

                                // Counting months
                                if (ticket.CheckOut.Value.Month < ticket.CheckIn.Month)
                                {
                                    months += ticket.CheckOut.Value.Month + 12 - ticket.CheckIn.Month;
                                }
                                else
                                    months += ticket.CheckOut.Value.Month - ticket.CheckIn.Month;

                                // Total Hours
                                totalHours += hours;
                                if (days > 0)
                                    totalHours += days * 24;
                                if (months > 0)
                                    totalHours += months * 30 * 24;

                                // Total price
                                totalPrice += (int)ticket.Price;
                            }

                            dgvMonthlyData.Rows.Add(day.ToString(),client.FirstName + " " + client.LastName, totalHours.ToString(), totalPrice.ToString());
                        }
                    }
                }
            }
        }
    }
}
