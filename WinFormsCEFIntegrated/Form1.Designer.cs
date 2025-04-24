using System.Drawing;
using System.Windows.Forms;

namespace WinFormsCEFIntegrated
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();

            int columnWidth = 125;
            int padding = 10;
            int groupBoxHeight = 325;

            // Helper function to create centered panel
            TableLayoutPanel CreateCenterPanel(string labelText)
            {
                var panel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 1,
                    BackColor = Color.Transparent
                };
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                var label = new Label
                {
                    Text = labelText,
                    AutoSize = true,
                    Anchor = AnchorStyles.None,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                panel.Controls.Add(label, 0, 0);
                return panel;
            }

            // groupBox1 - spans 3 columns (col-md-3)
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(padding, padding);
            this.groupBox1.Size = new System.Drawing.Size(columnWidth * 3 - padding, groupBoxHeight);
            this.groupBox1.Controls.Add(CreateCenterPanel("Batch Control Content"));

            // groupBox2 - spans 3 columns
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(columnWidth * 3 + padding * 2, padding);
            this.groupBox2.Size = new System.Drawing.Size(columnWidth * 3 - padding, groupBoxHeight);
            this.groupBox2.Controls.Add(CreateCenterPanel("Vendor Info Content"));

            // groupBox3 - spans 3 columns
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(columnWidth * 6 + padding * 3, padding);
            this.groupBox3.Size = new System.Drawing.Size(columnWidth * 3 - padding, groupBoxHeight);
            this.groupBox3.Controls.Add(CreateCenterPanel("PO Info Content"));

            // groupBox4 - spans 3 columns
            this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(columnWidth * 9 + padding * 4, padding);
            this.groupBox4.Size = new System.Drawing.Size(columnWidth * 3 - padding, groupBoxHeight);
            this.groupBox4.Controls.Add(CreateCenterPanel("Ledger Info Content"));

            // Form1
            this.ClientSize = new System.Drawing.Size(1580, 620);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Text = "Form1";
            this.ResumeLayout(false);
        }


        #endregion


        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
    }
}
