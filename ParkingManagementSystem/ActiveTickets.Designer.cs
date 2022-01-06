namespace ParkingManagementSystem
{
	partial class ActiveTickets
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
			this.dgvActiveTickets = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SlotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvActiveTickets)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvActiveTickets
			// 
			this.dgvActiveTickets.AllowUserToAddRows = false;
			this.dgvActiveTickets.AllowUserToDeleteRows = false;
			this.dgvActiveTickets.AllowUserToOrderColumns = true;
			this.dgvActiveTickets.AllowUserToResizeColumns = false;
			this.dgvActiveTickets.AllowUserToResizeRows = false;
			this.dgvActiveTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvActiveTickets.BackgroundColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvActiveTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvActiveTickets.ColumnHeadersHeight = 30;
			this.dgvActiveTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvActiveTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SlotNumber,
            this.PlateNumber,
            this.CheckIn,
            this.CheckOut,
            this.Price});
			this.dgvActiveTickets.Cursor = System.Windows.Forms.Cursors.Hand;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvActiveTickets.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvActiveTickets.EnableHeadersVisualStyles = false;
			this.dgvActiveTickets.Location = new System.Drawing.Point(1, 1);
			this.dgvActiveTickets.MultiSelect = false;
			this.dgvActiveTickets.Name = "dgvActiveTickets";
			this.dgvActiveTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvActiveTickets.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvActiveTickets.RowHeadersVisible = false;
			this.dgvActiveTickets.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvActiveTickets.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dgvActiveTickets.RowTemplate.Height = 30;
			this.dgvActiveTickets.RowTemplate.ReadOnly = true;
			this.dgvActiveTickets.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvActiveTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvActiveTickets.Size = new System.Drawing.Size(701, 446);
			this.dgvActiveTickets.TabIndex = 13;
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
			// ActiveTickets
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(703, 448);
			this.Controls.Add(this.dgvActiveTickets);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ActiveTickets";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Active Tickets";
			this.Load += new System.EventHandler(this.ActiveTickets_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvActiveTickets)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvActiveTickets;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn SlotNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn CheckIn;
		private System.Windows.Forms.DataGridViewTextBoxColumn CheckOut;
		private System.Windows.Forms.DataGridViewTextBoxColumn Price;
	}
}