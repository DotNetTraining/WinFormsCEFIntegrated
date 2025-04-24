using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCEFIntegrated
{
    public class BaseCefForm : Form
    {
        protected ChromiumWebBrowser chromeBrowser;

        public BaseCefForm(string urlPath)
        {
            CefSharpSettings.WcfEnabled = true;

            chromeBrowser = new ChromiumWebBrowser("http://localhost:5173/")
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(chromeBrowser);

            // Load the correct route
            chromeBrowser.Load($"http://localhost:5173/{urlPath}");

            // Attach event
            chromeBrowser.FrameLoadEnd += ChromeBrowser_FrameLoadEnd;
        }

        private async void ChromeBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                await SendSessionDataToReact();
                // Optionally show devtools
                // chromeBrowser.ShowDevTools();
            }
        }

        private async Task SendSessionDataToReact()
        {
            string username = SessionData.Instance.Username;
            var sessionData = SessionData.Instance.SessionVariables;

            string script = $@"
            window.postMessage({{
                type: 'SESSION_DATA',
                username: '{username}',
                sessionData: {JsonConvert.SerializeObject(sessionData)}
            }}, '*');
        ";

            await chromeBrowser.GetMainFrame().EvaluateScriptAsync(script);
        }
    }
}
