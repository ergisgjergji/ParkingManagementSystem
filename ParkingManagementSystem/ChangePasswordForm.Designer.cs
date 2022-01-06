namespace ParkingManagementSystem
{
	partial class ChangePasswordForm
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
			this.btnSavePw = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOldPw = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNewPw = new System.Windows.Forms.TextBox();
			this.txtConfirmPw = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSavePw
			// 
			this.btnSavePw.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnSavePw.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSavePw.Location = new System.Drawing.Point(300, 227);
			this.btnSavePw.Name = "btnSavePw";
			this.btnSavePw.Size = new System.Drawing.Size(92, 37);
			this.btnSavePw.TabIndex = 3;
			this.btnSavePw.Text = "Save";
			this.btnSavePw.UseVisualStyleBackColor = false;
			this.btnSavePw.Click += new System.EventHandler(this.btnSavePw_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(24, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Old password:";
			// 
			// txtOldPw
			// 
			this.txtOldPw.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOldPw.Location = new System.Drawing.Point(165, 49);
			this.txtOldPw.Name = "txtOldPw";
			this.txtOldPw.PasswordChar = '*';
			this.txtOldPw.Size = new System.Drawing.Size(227, 29);
			this.txtOldPw.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(24, 109);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 25);
			this.label2.TabIndex = 3;
			this.label2.Text = "New password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(71, 169);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 25);
			this.label3.TabIndex = 4;
			this.label3.Text = "Confirm:";
			// 
			// txtNewPw
			// 
			this.txtNewPw.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNewPw.Location = new System.Drawing.Point(165, 109);
			this.txtNewPw.Name = "txtNewPw";
			this.txtNewPw.PasswordChar = '*';
			this.txtNewPw.Size = new System.Drawing.Size(227, 29);
			this.txtNewPw.TabIndex = 1;
			// 
			// txtConfirmPw
			// 
			this.txtConfirmPw.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConfirmPw.Location = new System.Drawing.Point(165, 169);
			this.txtConfirmPw.Name = "txtConfirmPw";
			this.txtConfirmPw.PasswordChar = '*';
			this.txtConfirmPw.Size = new System.Drawing.Size(227, 29);
			this.txtConfirmPw.TabIndex = 2;
			// 
			// ChangePasswordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MidnightBlue;
			this.ClientSize = new System.Drawing.Size(431, 296);
			this.Controls.Add(this.txtConfirmPw);
			this.Controls.Add(this.txtNewPw);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtOldPw);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSavePw);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "ChangePasswordForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Password";
			this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSavePw;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOldPw;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNewPw;
		private System.Windows.Forms.TextBox txtConfirmPw;
	}
}