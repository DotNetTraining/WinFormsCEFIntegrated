using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using CefSharp.WinForms;
using Newtonsoft.Json;

namespace WinFormsCEFIntegrated
{
    public class FormRenderFrom
    {
        public string FormName { get; set; }
        public RenderFrom RenderFrom { get; set; }
    }

    public enum RenderFrom
    {
        WindowsForm = 0,
        Cef = 1,
    }

    public enum RenderFormName
    {
        Form1 = 0,
        Form2 = 1,
        Form3 = 2
    }

    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ChromiumWebBrowser chromeBrowser;
        private MenuStrip menuStrip;
        private ToolStripMenuItem purchaseOrderEntryMenuItem;
        private ToolStripMenuItem smartPoImportMenuItem;
        private ToolStripMenuItem purchaseOrderReportsMenuItem;

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

        private void InitializeFormRenderValues()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));
            string jsonFilePath = Path.Combine(projectRoot, "FormRenderValues.json");
            formRenderValues = ReadFormRenderValuesFromJson(jsonFilePath);
        }
    
        private void InitializeCefSharpBrowser()
        {
            chromeBrowser = new ChromiumWebBrowser("http://localhost:5173/")
            {
                Dock = DockStyle.Fill,
            };

            //panel1.Controls.Add(chromeBrowser);
        }

        // Method to read and deserialize JSON file into a List<FormRenderFrom>
        public static List<FormRenderFrom> ReadFormRenderValuesFromJson(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            List<FormRenderFrom> formRenderValues = JsonConvert.DeserializeObject<List<FormRenderFrom>>(jsonContent);

            return formRenderValues;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.purchaseOrderEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smartPoImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseOrderReportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 350);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseOrderEntryMenuItem,
            this.smartPoImportMenuItem,
            this.purchaseOrderReportsMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(714, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // purchaseOrderEntryMenuItem
            // 
            this.purchaseOrderEntryMenuItem.Name = "purchaseOrderEntryMenuItem";
            this.purchaseOrderEntryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.purchaseOrderEntryMenuItem.Size = new System.Drawing.Size(130, 20);
            this.purchaseOrderEntryMenuItem.Text = "Purchase Order Entry";
            this.purchaseOrderEntryMenuItem.Click += new System.EventHandler(this.purchaseOrderEntryMenuItem_Click);
            // 
            // smartPoImportMenuItem
            // 
            this.smartPoImportMenuItem.Name = "smartPoImportMenuItem";
            this.smartPoImportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.smartPoImportMenuItem.Size = new System.Drawing.Size(105, 20);
            this.smartPoImportMenuItem.Text = "SmartPO Import";
            this.smartPoImportMenuItem.Click += new System.EventHandler(this.smartPoImportMenuItem_Click);
            // 
            // purchaseOrderReportsMenuItem
            // 
            this.purchaseOrderReportsMenuItem.Name = "purchaseOrderReportsMenuItem";
            this.purchaseOrderReportsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.purchaseOrderReportsMenuItem.Size = new System.Drawing.Size(143, 20);
            this.purchaseOrderReportsMenuItem.Text = "Purchase Order Reports";
            this.purchaseOrderReportsMenuItem.Click += new System.EventHandler(this.purchaseOrderReportsMenuItem_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(714, 374);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
    }
}
