using ParkingManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDAutomation.NetAssembly;

namespace ParkingManagementSystem
{
	public partial class CheckinForm : Form
	{
        Ticket ticket = new Ticket();
        public CheckinForm()
		{
			InitializeComponent();
		}

		private void CheckinForm_Load(object sender, EventArgs e)
		{
			lblSlotNumber.Text = EmployeeForm.slotNumber.ToString();
			txtPlateNumber.Clear();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPlateNumber.Text == "")
            {
                MessageBox.Show("Plate number is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlateNumber.Focus();
            }
            else if (txtPlateNumber.Text.Length > 10)
            {
                MessageBox.Show("Incorrect plate number.\nMax length: 10", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlateNumber.Focus();
            }
            else
            {
                ticket.SlotNumber = Convert.ToInt32(lblSlotNumber.Text);
                ticket.PlateNumber = txtPlateNumber.Text;
                ticket.CheckIn = DateTime.Now;
                using (DbEntities dbContext = new DbEntities())
                {
                    var car = dbContext.Cars.Where(cr => cr.PlateNumber == txtPlateNumber.Text).FirstOrDefault();
                    if (car != null)
                        ticket.Client = car.Client;
                    dbContext.Tickets.Add(ticket);
                    dbContext.spUpdateSlotStatus(ticket.SlotNumber, false);
                    dbContext.SaveChanges();
                    this.Close();
                }
            }

            PrintDocument printDocument = new PrintDocument();

            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = printDocument;     

            //add an event handler that will do the printing
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt);

            printPreview.ShowDialog();
            this.Close();
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            string plateNumber = ticket.PlateNumber;
            string slotNumber = ticket.SlotNumber.ToString();
            string checkin = ticket.CheckIn.ToString();

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

            if(ticket.ClientID != null || Convert.ToInt32(ticket.ClientID) != 0)
            {
                string clientName = ticket.Client.FirstName + " " + ticket.Client.LastName;

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
            graphic.DrawString("-------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 50; 
            graphic.DrawString("         Thank you for your custom.", font, new SolidBrush(Color.Black), startX, startY + offset);

            #region Barcode
            FontEncoder encoder = new FontEncoder();
            string encodedData = encoder.Code128(ticket.ID.ToString(), 0, false);
            Font barcodeFont = new Font("IDAutomationSC128S DEMO Symbol", 18, FontStyle.Regular);

            offset = offset + 30;
            graphic.DrawString("          " + encodedData, barcodeFont,new SolidBrush(Color.Black), startX, startY + offset);
            #endregion

            offset = offset + (int)fontHeight + 35;
            graphic.DrawString("-------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
        }
    }
}
