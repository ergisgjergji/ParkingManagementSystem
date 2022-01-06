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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            PopulateClients();
            lblFrequentHour.Text = MostFrequentHour().ToString() + ":00";
            lblMinimalParkingTime.Text = MinimalParkingTime().ToString() + "m";
            lblMaximalDuration.Text = (MaximalParkingTime() / 60).ToString() + "h:"
                                    + (MaximalParkingTime() % 60).ToString() + "m";
            lblAverageTime.Text = (AverageParkingTime() / 60).ToString() + "h:"
                                    + (AverageParkingTime() % 60).ToString() + "m";
        }

        private void PopulateClients()
        {
            dgvClients.Rows.Clear();
            dgvClients.AutoGenerateColumns = false;

            List<Client> clients = new List<Client>();
            using(DbEntities dbContext = new DbEntities())
            {
                clients = dbContext.Clients.ToList();
;           }

            int totalHours, totalPrice ;
            int hours, days, months;

            try
            {
                foreach (var client in clients)
                {
                    totalHours = 0;
                    totalPrice = 0;
                    hours = 0; days = 0; months = 0;

                    using (DbEntities dbContext = new DbEntities())
                    {
                        var tickets = dbContext.Tickets.Where(tc => tc.ClientID == client.ID && tc.CheckOut != null).ToList();
                        // If client has no ticket
                        if (tickets.Count < 1)
                        {
                            dgvClients.Rows.Add(client.FirstName + " " + client.LastName, totalHours.ToString(), totalPrice.ToString());
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

                            dgvClients.Rows.Add(client.FirstName + " " + client.LastName, totalHours.ToString(), totalPrice.ToString());
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error occurred somewhere.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int MostFrequentHour()
        {
            int count = 0;
            int hour=1;
            for(int currHour = 1; currHour <= 24; currHour++)
            {
                using(DbEntities dbContext = new DbEntities())
                {
                    int currCount = dbContext.Tickets.Where(tc => tc.CheckIn.Hour == currHour).ToList().Count();
                    if(currCount > count)
                    {
                        count = currCount;
                        hour = currHour;
                    }
                }
            }

            return hour;
        }

        private int MinimalParkingTime()
        {
            using(DbEntities dbContext = new DbEntities())
            {
                var tickets = dbContext.Tickets.Where(tc => tc.CheckOut != null).ToList();

                int minimalMinutesDuration = 1000;
                int minutes, hours, days, months, totalMinutes;
                foreach (var ticket in tickets)
                {
                    minutes = 0; hours = 0; days = 0; months = 0; totalMinutes = 0;

                    // Counting minutes
                    if (ticket.CheckOut.Value.Minute < ticket.CheckIn.Minute)
                    {
                        minutes = ticket.CheckOut.Value.Minute + 60 - ticket.CheckIn.Minute;
                        hours--;
                    }
                    else
                        minutes = ticket.CheckOut.Value.Minute - ticket.CheckIn.Minute;

                    // Counting hours
                    if (ticket.CheckOut.Value.Hour < ticket.CheckIn.Hour)
                    {
                        hours += ticket.CheckOut.Value.Hour + 24 - ticket.CheckIn.Hour;
                        days--;
                    }
                    else
                        hours += ticket.CheckOut.Value.Hour - ticket.CheckIn.Hour;

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

                    // Total minutes
                    totalMinutes += minutes;
                    if (hours > 0)
                        totalMinutes += hours * 60;
                    if (days > 0)
                        totalMinutes += days * 24 * 60;
                    if (months > 0)
                        totalMinutes += months * 30 * 24 * 60;

                    if (totalMinutes < minimalMinutesDuration)
                        minimalMinutesDuration = totalMinutes;
                }

                return minimalMinutesDuration;
            }
        }

        private int MaximalParkingTime()
        {
            using (DbEntities dbContext = new DbEntities())
            {
                var tickets = dbContext.Tickets.Where(tc => tc.CheckOut != null).ToList();

                int maximalMinutesDuration = 0;
                int minutes, hours, days, months, totalMinutes;
                foreach (var ticket in tickets)
                {
                    minutes = 0; hours = 0; days = 0; months = 0; totalMinutes = 0;

                    // Counting minutes
                    if (ticket.CheckOut.Value.Minute < ticket.CheckIn.Minute)
                    {
                        minutes = ticket.CheckOut.Value.Minute + 60 - ticket.CheckIn.Minute;
                        hours--;
                    }
                    else
                        minutes = ticket.CheckOut.Value.Minute - ticket.CheckIn.Minute;

                    // Counting hours
                    if (ticket.CheckOut.Value.Hour < ticket.CheckIn.Hour)
                    {
                        hours += ticket.CheckOut.Value.Hour + 24 - ticket.CheckIn.Hour;
                        days--;
                    }
                    else
                        hours += ticket.CheckOut.Value.Hour - ticket.CheckIn.Hour;

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

                    // Total minutes
                    totalMinutes += minutes;
                    if (hours > 0)
                        totalMinutes += hours * 60;
                    if (days > 0)
                        totalMinutes += days * 24 * 60;
                    if (months > 0)
                        totalMinutes += months * 30 * 24 * 60;

                    if (totalMinutes > maximalMinutesDuration)
                        maximalMinutesDuration = totalMinutes;
                }

                return maximalMinutesDuration;
            }
        }

        private int AverageParkingTime()
        {
            using (DbEntities dbContext = new DbEntities())
            {
                var tickets = dbContext.Tickets.Where(tc => tc.CheckOut != null).ToList();

                int minutes, hours, days, months, totalMinutes = 0;
                foreach (var ticket in tickets)
                {
                    minutes = 0; hours = 0; days = 0; months = 0;

                    // Counting minutes
                    if (ticket.CheckOut.Value.Minute < ticket.CheckIn.Minute)
                    {
                        minutes = ticket.CheckOut.Value.Minute + 60 - ticket.CheckIn.Minute;
                        hours--;
                    }
                    else
                        minutes = ticket.CheckOut.Value.Minute - ticket.CheckIn.Minute;

                    // Counting hours
                    if (ticket.CheckOut.Value.Hour < ticket.CheckIn.Hour)
                    {
                        hours += ticket.CheckOut.Value.Hour + 24 - ticket.CheckIn.Hour;
                        days--;
                    }
                    else
                        hours += ticket.CheckOut.Value.Hour - ticket.CheckIn.Hour;

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

                    // Total minutes
                    totalMinutes += minutes;
                    if (hours > 0)
                        totalMinutes += hours * 60;
                    if (days > 0)
                        totalMinutes += days * 24 * 60;
                    if (months > 0)
                        totalMinutes += months * 30 * 24 * 60;
                }

                return totalMinutes/tickets.Count;
            }
        }

        private void BtnShowMonthlyData_Click(object sender, EventArgs e)
        {
            MonthlyDataForm frm = new MonthlyDataForm();
            frm.ShowDialog();
        }
    }
}
