using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Threading;
using System.IO;
using System.Net;

namespace AlorianLauncher
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            var session = MSession.GetOfflineSession(LoginPage.user);
            Control.CheckForIllegalCrossThreadCalls = false;

            userlabel.Text = LoginPage.user;
            var request = WebRequest.Create("https://minotar.net/avatar/" + LoginPage.user + "/70.png");

            using var response = request.GetResponse();
            using var stream = response.GetResponseStream();
            pictureBox3.Image = Bitmap.FromStream(stream);
        }

        MSession session;

        private void path()
        {
            // increase connection limit to fast download
            System.Net.ServicePointManager.DefaultConnectionLimit = 256;

            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);

            // show launch progress to console
            launcher.FileChanged += (e) =>
            {
                Console.WriteLine("[{0}] {1} - {2}/{3}", e.FileKind.ToString(), e.FileName, e.ProgressedFileCount, e.TotalFileCount);
            };
            launcher.ProgressChanged += (s, e) =>
            {
                Console.WriteLine("{0}%", e.ProgressPercentage);
            };
        }

        private void launch()
        {
            // increase connection limit to fast download
            System.Net.ServicePointManager.DefaultConnectionLimit = 256;

            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.GetOfflineSession("hello"),

                //ScreenWidth = 1600,
                //ScreenHeight = 900,
                ServerIp = "play.alorianmc.net"
            };

            var process = launcher.CreateProcess("1.16.5", launchOption, checkAndDownload: true);

            process.Start();
            this.Hide();
            Application.Exit();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            oyna_buton.Enabled = false;
            oyna_buton.Text = "Başlatılıyor";
            Thread thread = new Thread(() => launch());
            thread.IsBackground = true;
            thread.Start();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            LoginPage lg = new LoginPage();
            lg.Show();
            Hide();
        }
    }
}
