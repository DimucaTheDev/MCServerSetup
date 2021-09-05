using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace MCServerSetup
{
    public partial class ServerDownload : Form
    {
        public ServerDownload(string url, string path)
        {
            InitializeComponent();

            
            Form1.web.OpenRead(url);
            string size = Form1.web.ResponseHeaders["Content-Length"];

            Form1.web.DownloadProgressChanged += (s, a) =>
            {
                progressBar1.Value = a.ProgressPercentage;
                this.size.Text = $"{((double)a.BytesReceived / 1048576).ToString("#.#")}/{((double)Convert.ToDouble(size) / 1048576).ToString("#.#")} MB downloaded.";
            };


            Form1.web.DownloadFileAsync(new Uri(url), path);
        }
        private void ServerDownload_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
