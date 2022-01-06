namespace ParkingManagementSystem
{
	partial class TicketsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvAllTickets = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SlotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvAllTickets)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvAllTickets
			// 
			this.dgvAllTickets.AllowUserToAddRows = false;
			this.dgvAllTickets.AllowUserToDeleteRows = false;
			this.dgvAllTickets.AllowUserToOrderColumns = true;
			this.dgvAllTickets.AllowUserToResizeColumns = false;
			this.dgvAllTickets.AllowUserToResizeRows = false;
			this.dgvAllTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvAllTickets.BackgroundColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvAllTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvAllTickets.ColumnHeadersHeight = 30;
			this.dgvAllTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvAllTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SlotNumber,
            this.PlateNumber,
            this.CheckIn,
            this.CheckOut,
            this.Price});
			this.dgvAllTickets.Cursor = System.Windows.Forms.Cursors.Hand;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvAllTickets.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvAllTickets.EnableHeadersVisualStyles = false;
			this.dgvAllTickets.Location = new System.Drawing.Point(3, 2);
			this.dgvAllTickets.MultiSelect = false;
			this.dgvAllTickets.Name = "dgvAllTickets";
			this.dgvAllTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvAllTickets.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvAllTickets.RowHeadersVisible = false;
			this.dgvAllTickets.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvAllTickets.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dgvAllTickets.RowTemplate.Height = 30;
			this.dgvAllTickets.RowTemplate.ReadOnly = true;
			this.dgvAllTickets.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvAllTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAllTickets.Size = new System.Drawing.Size(668, 446);
			this.dgvAllTickets.TabIndex = 12;
			// 
			// ID
			// 
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Width = 74;
			// 
			// SlotNumber
			// 
			this.SlotNumber.HeaderText = "Slot";
			this.SlotNumber.Name = "SlotNumber";
			this.SlotNumber.ReadOnly = true;
			this.SlotNumber.Width = 80;
			// 
			// PlateNumber
			// 
			this.PlateNumber.HeaderText = "Plate Number";
			this.PlateNumber.Name = "PlateNumber";
			this.PlateNumber.ReadOnly = true;
			this.PlateNumber.Width = 127;
			// 
			// CheckIn
			// 
			this.CheckIn.HeaderText = "Check in";
			this.CheckIn.Name = "CheckIn";
			this.CheckIn.ReadOnly = true;
			this.CheckIn.Width = 104;
			// 
			// CheckOut
			// 
			this.CheckOut.HeaderText = "Check Out";
			this.CheckOut.Name = "CheckOut";
			this.CheckOut.ReadOnly = true;
			this.CheckOut.Width = 112;
			// 
			// Price
			// 
			this.Price.HeaderText = "Price";
			this.Price.Name = "Price";
			this.Price.ReadOnly = true;
			this.Price.Width = 87;
			// 
			// TicketsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(672, 450);
			this.Controls.Add(this.dgvAllTickets);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "TicketsForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "All tickets";
			this.Load += new System.EventHandler(this.TicketsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvAllTickets)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvAllTickets;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn SlotNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn CheckIn;
		private System.Windows.Forms.DataGridViewTextBoxColumn CheckOut;
		private System.Windows.Forms.DataGridViewTextBoxColumn Price;
	}
}