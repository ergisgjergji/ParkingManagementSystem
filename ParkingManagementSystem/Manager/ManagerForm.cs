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
    public partial class ManagerForm : Form
    {
        private bool dropDown;

        public ManagerForm()
        {
            InitializeComponent();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            dropDown = false;
            dropdownPanel.Height = 41;
            UpdateUI();
        }

        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToLongTimeString();
        }

        private void BtnTickets_Click(object sender, EventArgs e)
        {
            if (dropDown == false)
            {
                dropDown = true;
                dropdownPanel.Height = 137;
            }
            else if (dropDown == true)
            {
                dropDown = false;
                dropdownPanel.Height = 41;
            }
        }

        private void UpdateUI()
        {
            lblManager.Text = "";
            lblManager.Text = LoginForm.user.FirstName + " " + LoginForm.user.LastName;
            flowSlots_manager.Controls.Clear();

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
                    btn.Size = new Size(80, 80);
                    btn.Text = slot.Number.ToString();
                    btn.Font = new Font("Arial", 16, FontStyle.Bold);
                    btn.Margin = new Padding(15, 15, 15, 15);

                    if (slot.isFree == true)
                        btn.BackColor = Color.LightGray;
                    else if (slot.isFree == false)
                        btn.BackColor = Color.LimeGreen;

                    flowSlots_manager.Controls.Add(btn);
                }

                Button btn_addSlot = new Button();
                btn_addSlot.Size = new Size(80, 80);
                btn_addSlot.Text = "+";
                btn_addSlot.Font = new Font("Arial", 22, FontStyle.Bold);
                btn_addSlot.Margin = new Padding(15, 15, 15, 15);
                btn_addSlot.Click += Btn_addSlot_Click;

                flowSlots_manager.Controls.Add(btn_addSlot);
            }
        }

        private void Btn_addSlot_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Adding a new slot.\nConfirm?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (DbEntities dbContext = new DbEntities())
                    {
                        var slots = dbContext.Slots.ToList();

                        Slot newSlot = new Slot()
                        {
                            Number = slots.Count + 1,
                            isFree = true
                        };

                        dbContext.Slots.Add(newSlot);
                        dbContext.SaveChanges();
                        UpdateUI();
                        MessageBox.Show("Slot added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("An error occurred somewhere.","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAllTickets_Click(object sender, EventArgs e)
        {
            TicketsForm ticketsF = new TicketsForm();
            ticketsF.ShowDialog();
        }

        private void BtnActive_Click(object sender, EventArgs e)
        {
            ActiveTickets activeTicketsF = new ActiveTickets();
            activeTicketsF.ShowDialog();
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            ClientForm clForm = new ClientForm();
            clForm.ShowDialog();
        }

        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            ManageEmployeesForm empForm = new ManageEmployeesForm();
            empForm.ShowDialog();
        }

        private void BtnPrices_Click(object sender, EventArgs e)
        {
            PricesForm prForm = new PricesForm();
            prForm.ShowDialog();
        }

        private void BtnChangePw_Click(object sender, EventArgs e)
        {
            ChangePasswordForm passForm = new ChangePasswordForm();
            passForm.ShowDialog();
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            ReportForm frm = new ReportForm();
            frm.ShowDialog();
        }
    }
}
