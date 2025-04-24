using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinFormsCEFIntegrated
{
    public partial class LoginForm : Form
    {
        private int _refreshInterval;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MainForm mainForm;
        public LoginForm(int refreshInterval = 20000)
        {
            InitializeComponent(); 
            this.FormBorderStyle = FormBorderStyle.None; 
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeStatusBar();
            _refreshInterval = refreshInterval;
            StyleTextBoxes();
            ApplyBootstrapButtonStyles();

            // Set window width and height
            this.Width = 1600; 
            this.Height = 800; 
            this.FormBorderStyle = FormBorderStyle.None; 
            this.ControlBox = false;
            // Initialize MainForm
            //mainForm = new MainForm(_refreshInterval);
        }


        private void InitializeStatusBar()
        {
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel1.ForeColor = Color.White;
            toolStripStatusLabel1.Font = new Font("Segoe UI", 12);
            toolStripStatusLabel1.Text = "Please enter your credentials to log in.";
            statusStrip1.BackColor = Color.FromArgb(19, 17, 54);
            statusStrip1.Items.Add(toolStripStatusLabel1);
            this.Controls.Add(statusStrip1);
        }


        private async void btnSetSession_Click(object sender, EventArgs e)
        {
            //this.Hide(); 
            //mainForm.Show();
            await SetAndLoadSession();
        }

        private async Task SetAndLoadSession()
        {
            string userId = txtUserId.Text == "UserId" ? "" : txtUserId.Text;
            string ceo = txtCEO.Text == "CEO" ? "" : txtCEO.Text;
            string location = txtLocation.Text == "Location" ? "" : txtLocation.Text;
            string productionHouse = txtProductionHouse.Text == "Production House" ? "" : txtProductionHouse.Text;

            ceo = string.IsNullOrEmpty(ceo) ? "John Doe" : ceo;
            location = string.IsNullOrEmpty(location) ? "New York" : location;
            productionHouse = string.IsNullOrEmpty(productionHouse) ? "HBO" : productionHouse;

            string body = $@"
        <userId>{userId}</userId>
        <ProductionHouseName>{productionHouse}</ProductionHouseName>
        <Location>{location}</Location>
        <FoundedYear>1994</FoundedYear>
        <CEO>{ceo}</CEO>";

            try
            {
                var setResponse = await SoapHelper.CallSoapService(
                   "http://tempuri.org/CreateSessionDetailsByuser",
                   "CreateSessionDetailsByuser",
                   body
               );

                await LoadSessionData(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting session: {ex.Message}");
            }
        }

        private void ShowStatus(string message, bool isSuccess)
        {
            toolStripStatusLabel1.Text = message;

            if (isSuccess)
            {
                toolStripStatusLabel1.ForeColor = Color.White;
                toolStripStatusLabel1.BackColor = Color.Green;
            }
            else
            {
                toolStripStatusLabel1.ForeColor = Color.White;
                toolStripStatusLabel1.BackColor = Color.DarkRed;
            }
        }

        private async Task LoadSessionData(string userId)
        {
            try
            {
                var response = await SoapHelper.CallSoapService(
                    "http://tempuri.org/GetSessionIDandVariables",
                    "GetSessionIDandVariables",
                    $"<userId>{userId}</userId>"
                );

                var resultJson = SoapHelper.ExtractSoapResult(response, "GetSessionIDandVariablesResult");

                var wrapper = JsonConvert.DeserializeObject<Dictionary<string, object>>(resultJson);
                if (wrapper != null && wrapper.TryGetValue("SessionDetail", out var detailObj))
                {
                    var sessionDetail = JsonConvert.DeserializeObject<Dictionary<string, object>>(detailObj.ToString());
                    SessionData.Instance.SessionVariables = sessionDetail;
                    SessionData.Instance.Username = sessionDetail.TryGetValue("UserId", out var uid) ? uid.ToString() : "Unknown";

                    ShowStatus($"[✓] Login successful for {SessionData.Instance.Username}", true);

                    var mainForm = new MainForm(_refreshInterval);
                    mainForm.SetUserId(SessionData.Instance.Username);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    ShowStatus("[!] Session data not found.", false);
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"[×] Error loading session: {ex.Message}", false);
            }
        }
        private void StyleTextBoxes()
        {
            CreateStyledTextbox(txtUserId, "UserId");
            CreateStyledTextbox(txtCEO, "CEO");
            CreateStyledTextbox(txtLocation, "Location");
            CreateStyledTextbox(txtProductionHouse, "Production House");
        }

        private void CreateStyledTextbox(TextBox textBox, string placeholder)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 16);
            textBox.ForeColor = Color.Gray;
            textBox.Width = 300;
            textBox.Height = 50;
            textBox.Multiline = false;
            textBox.TextAlign = HorizontalAlignment.Left; 
        }

        private void ApplyBootstrapButtonStyles()
        {
            btnSetSession.BackColor = Color.FromArgb(3, 1, 41);
            btnSetSession.Text = "Login";
            btnSetSession.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            btnSetSession.ForeColor = Color.White;
            btnSetSession.FlatStyle = FlatStyle.Flat;
            btnSetSession.FlatAppearance.BorderSize = 0;
            btnSetSession.Padding = new Padding(0);
            btnSetSession.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 123, 255);
            btnSetSession.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 85, 255); 
            btnSetSession.Cursor = Cursors.Hand;
            btnSetSession.Size = new Size(150, 45);
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1360, 700);

        }


    }
}