using IDAutomation.NetAssembly;
using ParkingManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagementSystem
{
	public partial class CheckoutForm : Form
	{

        Ticket ticket = new Ticket();

        public CheckoutForm()
		{
			InitializeComponent();
		}

		private void CheckoutForm_Load(object sender, EventArgs e)
		{
			lblClient.Visible = false;
			lblClientName.Visible = false;

			int slot = EmployeeForm.slotNumber;
			lblSlotNumber.Text = slot.ToString();
			using (DbEntities dbContext = new DbEntities())
			{
				ticket = dbContext.Tickets.Where(tick => tick.SlotNumber == slot && tick.CheckOut == null)
					.FirstOrDefault();

				lblPlateNumber.Text = ticket.PlateNumber;
				lblCheckIn.Text = ticket.CheckIn.ToShortDateString();
				if (ticket.ClientID != null)
				{
					lblClient.Visible = true;
					lblClientName.Text = ticket.Client.FirstName + " " + ticket.Client.LastName;
					lblClientName.Visible = true;
				}
			}
		}

		private void btnCheckout_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Proceed to checkout?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				int total = 0;
                ticket.CheckOut = DateTime.Now;
                int hours = 0, days = 0, months = 0;

                if (DateTime.Now.Hour < ticket.CheckIn.Hour)
                {
                    hours = DateTime.Now.Hour + 24 - ticket.CheckIn.Hour;
                    days--;
                }
                else
                    hours = DateTime.Now.Hour - ticket.CheckIn.Hour;

                if (DateTime.Now.Day < ticket.CheckIn.Day)
                {
                    days += DateTime.Now.Day + 30 - ticket.CheckIn.Day;
                    months--;
                }
                else
                    days += DateTime.Now.Day - ticket.CheckIn.Day;

                months += DateTime.Now.Month - ticket.CheckIn.Month;

                if (DateTime.Now.Minute  > ticket.CheckIn.Minute)
					hours += 1;

				using (DbEntities dbContext = new DbEntities())
				{
					var hourPrice = dbContext.Prices.Where(pr => pr.Hours == hours).FirstOrDefault();
					total += hours * hourPrice.Price1;

					var dayPrice = dbContext.Prices.Where(pr => pr.Hours == 24).FirstOrDefault();
                    if(days > 0)
					    total += days * dayPrice.Price1;

                    int monthPrice = dayPrice.Price1 * 30;
                    if(months > 0)
                        total += months * monthPrice;

                    var dbTicket = dbContext.Tickets.Where(tc => tc.ID == ticket.ID).FirstOrDefault();
                    dbTicket.CheckOut = DateTime.Now;

                    if (dbTicket.Client != null)
                    {
                        DateTime today = DateTime.Now;
                        var todaysTickets = dbContext.Tickets.Where(tc =>
                            tc.ClientID == ticket.ClientID &&
                            tc.CheckIn.Year == today.Year &&
                            tc.CheckIn.Month == today.Month && 
                            tc.CheckIn.Day == today.Day &&
                            tc.Price > 0)
                            .ToList();

                        MessageBox.Show("Today's tickets count: " + todaysTickets.Count.ToString());
                        if (todaysTickets.Count % 5 == 0)
                            dbTicket.Price = 0;
                        else
                        {
                            int discount = ticket.Client.Discount / 100;
                            dbTicket.Price = total - total * discount;
                        }
                    }
                    else
                        dbTicket.Price = total;

                    ticket.Price = dbTicket.Price;
                    dbContext.Entry(dbTicket).State = EntityState.Modified;
					dbContext.spUpdateSlotStatus(dbTicket.SlotNumber, true);
					dbContext.SaveChanges();
                    MessageBox.Show("Price: " + dbTicket.Price.ToString());

                    PrintDocument printDocument = new PrintDocument();
                    PrintPreviewDialog printPreview = new PrintPreviewDialog();
                    printPreview.Document = printDocument;

                    //add an event handler that will do the printing
                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt);
                    printPreview.ShowDialog();
                    this.Close();
				}
			}
		}

        private void CreateReceipt(object sender, PrintPageEventArgs e)
        {
            string plateNumber = ticket.PlateNumber;
            string slotNumber = ticket.SlotNumber.ToString();
            string checkin = ticket.CheckIn.ToString();
            string checkout = ticket.CheckOut.Value.ToString();
            string total = ticket.Price.ToString();
            string discount = "";

            //this prints the reciept

            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 40;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("       Parking ticket", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);

            offset = offset + (int)fontHeight;
            graphic.DrawString("-------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

            if (ticket.ClientID != null || Convert.ToInt32(ticket.ClientID) != 0)
            {
                string clientName = ticket.Client.FirstName + " " + ticket.Client.LastName;
                discount = ticket.Client.Discount.ToString() + "%";

                offset = offset + (int)fontHeight + 5;
                string line = "Client:".PadRight(30) + clientName;
                graphic.DrawString(line, font, new SolidBrush(Color.Black), startX, startY + offset);
            }

            offset = offset + (int)fontHeight + 5;
            string line1 = "Plate number:".PadRight(30) + plateNumber;
            graphic.DrawString(line1, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight + 5;
            string line2 = "Slot:".PadRight(30) + slotNumber;
            graphic.DrawString(line2, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight + 5;
            string line3 = "Checkin:".PadRight(20) + checkin;
            graphic.DrawString(line3, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight + 5;
            string line4 = "Checkout:".PadRight(20) + checkout;
            graphic.DrawString(line4, font, new SolidBrush(Color.Black), startX, startY + offset);

            if(discount != "")
            {
                offset = offset + (int)fontHeight + 5;
                string lineDiscount = "Discount:".PadRight(30) + discount;
                graphic.DrawString(lineDiscount, font, new SolidBrush(Color.Black), startX, startY + offset);
            }

            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("-------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight + 8;
            string line5 = "Total:".PadRight(30) + total;
            graphic.DrawString(line5, new Font("Courier New",14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight + 10;
            graphic.DrawString("-------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30;
            graphic.DrawString("         Thank you for your custom.", font, new SolidBrush(Color.Black), startX, startY + offset);

            #region Barcode
            FontEncoder encoder = new FontEncoder();
            string encodedData = encoder.Code128(ticket.ID.ToString(), 0, false);
            Font barcodeFont = new Font("IDAutomationSC128S DEMO Symbol", 18, FontStyle.Regular);

            offset = offset + 30;
            graphic.DrawString("          " + encodedData, barcodeFont, new SolidBrush(Color.Black), startX, startY + offset);
            #endregion

            offset = offset + (int)fontHeight + 35;
            graphic.DrawString("-------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
        }
    }
}
