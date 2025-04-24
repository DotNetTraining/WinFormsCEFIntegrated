using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsCEFIntegrated.Utility;

namespace WinFormsCEFIntegrated
{
    public partial class MainForm : Form
    {
        private string lastUserId = "user123"; // Default
        private Timer sessionRefreshTimer;
        private ToolStripStatusLabel statusLabel;
        private int refreshInterval;
        public List<FormRenderFrom> formRenderValues = new List<FormRenderFrom>();

        private ToolStripMenuItem selectedMenuItem;

        public MainForm(int intervalFromArgs = 10000)
        {
            InitializeComponent();
            refreshInterval = intervalFromArgs;
            InitializeFormRenderValues();
            InitializeCefSharpBrowser();
            InitializeStatusBar();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1600;
            this.Height = 800;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;

            StyleMenuStrip();
        }

        private void StyleMenuStrip()
        {
            menuStrip.BackColor = Color.FromArgb(0, 123, 255);
            menuStrip.ForeColor = Color.White;
            menuStrip.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            menuStrip.Renderer = new ToolStripProfessionalRenderer(new BootstrapColorTable());
        }

        public class BootstrapColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(3, 1, 41);
            public override Color MenuItemBorder => Color.Transparent;
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(3, 1, 41);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(3, 1, 41);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(0, 92, 184);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(0, 92, 184);
            public override Color ToolStripDropDownBackground => Color.White;
            public override Color ImageMarginGradientBegin => Color.White;
            public override Color ImageMarginGradientMiddle => Color.White;
            public override Color ImageMarginGradientEnd => Color.White;
        }

        private async Task RefreshSession(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) return;

            try
            {
                string response = await SoapHelper.CallSoapService("http://tempuri.org/GetSessionIDandVariables", "GetSessionIDandVariables", $"<userId>{lastUserId}</userId>");
                string resultJson = SoapHelper.ExtractSoapResult(response, "GetSessionIDandVariablesResult");

                var wrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(resultJson);
                if (wrapper != null && wrapper.ContainsKey("SessionDetail"))
                {
                    var sessionDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(wrapper["SessionDetail"].ToString());

                    SessionData.Instance.SessionVariables = sessionDetail;
                    SessionData.Instance.Username = sessionDetail.ContainsKey("UserId") ? sessionDetail["UserId"].ToString() : "Unknown";

                    this.Invoke((Action)(() =>
                    {
                        ShowStatus($"[✓] Session refreshed successfully! at {DateTime.Now} for {SessionData.Instance.Username}", StatusType.Success);
                    }));
                }
                else
                {
                    ShowStatus("[!] No session data found at {DateTime.Now}", StatusType.Warning);
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"[×] Session refresh failed: {ex.Message}", StatusType.Error);
            }
        }

        private void StartSessionRefreshTimer()
        {
            sessionRefreshTimer = new Timer();
            sessionRefreshTimer.Interval = refreshInterval;
            sessionRefreshTimer.Tick += async (s, e) =>
            {
                if (!string.IsNullOrEmpty(lastUserId))
                {
                    await RefreshSession(lastUserId);
                }
            };
            sessionRefreshTimer.Start();
        }

        public void SetUserId(string userId)
        {
            lastUserId = userId;
            ShowStatus($"✔ Logged in as {userId}. Next refresh in {refreshInterval / 1000} sec.", StatusType.Success);

            if (sessionRefreshTimer == null)
            {
                StartSessionRefreshTimer();
            }
        }

        private void HighlightMenuItem(object sender)
        {
            if (selectedMenuItem != null)
            {
                selectedMenuItem.BackColor = menuStrip.BackColor;
                selectedMenuItem.ForeColor = Color.White;
            }

            selectedMenuItem = sender as ToolStripMenuItem;
            if (selectedMenuItem != null)
            {
                selectedMenuItem.BackColor = Color.FromArgb(3, 1, 41);
                selectedMenuItem.ForeColor = Color.White;
            }
        }

        private void purchaseOrderEntryMenuItem_Click(object sender, EventArgs e)
        {
            HighlightMenuItem(sender);
            RenderForm(RenderFormName.Form1.ToString());
        }

        private void smartPoImportMenuItem_Click(object sender, EventArgs e)
        {
            HighlightMenuItem(sender);
            RenderForm(RenderFormName.Form2.ToString());
        }

        private void purchaseOrderReportsMenuItem_Click(object sender, EventArgs e)
        {
            HighlightMenuItem(sender);
            RenderForm(RenderFormName.Form3.ToString());
        }

        private void RenderForm(string formName)
        {
            var renderFrom = formRenderValues.FirstOrDefault(x => x.FormName == formName)?.RenderFrom ?? RenderFrom.WindowsForm;
            panel1.Controls.Clear();
            IFormFactory formFactory = FormFactory.GetFactoryForForm(formName);
            Form form = formFactory.GetFormInstance(renderFrom);
            SetFormProperties(form);
            panel1.Controls.Add(form);
            form.Show();
        }

        private Form SetFormProperties(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.ControlBox = false;
            return form;
        }

        private void InitializeStatusBar()
        {
            var statusStrip = new StatusStrip
            {
                Dock = DockStyle.Bottom
            };
            statusLabel = new ToolStripStatusLabel();
            statusLabel.ForeColor = Color.Black;
            statusLabel.Font = new Font("Segoe UI", 11);
            statusLabel.Text = "Waiting for session...";
            statusStrip.BackColor = Color.FromArgb(230, 230, 230);
            statusStrip.Items.Add(statusLabel);
            this.Controls.Add(statusStrip);
        }

        public void ShowStatus(string message, StatusType type = StatusType.Info)
        {
            Color backColor;
            Color foreColor = Color.White;

            switch (type)
            {
                case StatusType.Success:
                    backColor = Color.Green;
                    break;
                case StatusType.Error:
                    backColor = Color.DarkRed;
                    break;
                case StatusType.Warning:
                    backColor = Color.Orange;
                    foreColor = Color.Black;
                    break;
                default:
                    backColor = SystemColors.Control;
                    foreColor = Color.Black;
                    break;
            }

            statusLabel.Text = message;
            statusLabel.BackColor = backColor;
            statusLabel.ForeColor = foreColor;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Optional: select first tab by default
            //purchaseOrderEntryMenuItem.PerformClick();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1360, 700);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

       
    }
}
