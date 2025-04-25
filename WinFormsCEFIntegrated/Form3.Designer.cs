using System.Drawing;
using System.Windows.Forms;

namespace WinFormsCEFIntegrated
{
    partial class Form3 : Form
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ReportId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductionHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Episode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pincode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblCompany);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.textBox9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1360, 650);
            this.panel3.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportId,
            this.ReportName,
            this.ProductionHouse,
            this.ShowID,
            this.ShowName,
            this.Episode,
            this.Country,
            this.State,
            this.City,
            this.Pincode});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1361, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // ReportId
            // 
            this.ReportId.HeaderText = "ReportId";
            this.ReportId.Name = "ReportId";
            this.ReportId.ReadOnly = true;
            this.ReportId.Width = 131;
            // 
            // ReportName
            // 
            this.ReportName.HeaderText = "ReportName";
            this.ReportName.Name = "ReportName";
            this.ReportName.ReadOnly = true;
            this.ReportName.Width = 131;
            // 
            // ProductionHouse
            // 
            this.ProductionHouse.HeaderText = "ProductionHouse";
            this.ProductionHouse.Name = "ProductionHouse";
            this.ProductionHouse.ReadOnly = true;
            this.ProductionHouse.Width = 131;
            // 
            // ShowID
            // 
            this.ShowID.HeaderText = "ShowID";
            this.ShowID.Name = "ShowID";
            this.ShowID.ReadOnly = true;
            this.ShowID.Width = 131;
            // 
            // ShowName
            // 
            this.ShowName.HeaderText = "Show Name";
            this.ShowName.Name = "ShowName";
            this.ShowName.ReadOnly = true;
            this.ShowName.Width = 131;
            // 
            // Episode
            // 
            this.Episode.HeaderText = "Episode";
            this.Episode.Name = "Episode";
            this.Episode.ReadOnly = true;
            this.Episode.Width = 131;
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Width = 131;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 135;
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Width = 132;
            // 
            // Pincode
            // 
            this.Pincode.HeaderText = "Pincode";
            this.Pincode.Name = "Pincode";
            this.Pincode.ReadOnly = true;
            this.Pincode.Width = 132;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(9, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Select a Report";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(53, 32);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(97, 15);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Report Group:";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(152, 31);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(261, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Report:";
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(315, 30);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(108, 21);
            this.textBox9.TabIndex = 6;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 700);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3";
            this.Text = "Form3";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel3;
        private Label lblCompany;
        private TextBox textBox7;
        private Label label8;
        private TextBox textBox9;
        private Label label4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ReportId;
        private DataGridViewTextBoxColumn ReportName;
        private DataGridViewTextBoxColumn ProductionHouse;
        private DataGridViewTextBoxColumn ShowID;
        private DataGridViewTextBoxColumn ShowName;
        private DataGridViewTextBoxColumn Episode;
        private DataGridViewTextBoxColumn Country;
        private DataGridViewTextBoxColumn State;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn Pincode;
    }
}