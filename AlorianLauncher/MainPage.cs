using CmlLib.Core;
using CmlLib.Core.Auth;
using DiscordRPC;
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

            var haberRequest = WebRequest.Create("https://raw.githubusercontent.com/efxndyben/AlorianLauncher/master/images/haberkapagi.png");
            using var haberResponse = haberRequest.GetResponse();
            using var haberStream = haberResponse.GetResponseStream();
            guna2PictureBox1.Image = Bitmap.FromStream(haberStream);
        }

        public DiscordRpcClient client { get; private set; }

        //Called when your application first starts.
        //For example, just before your main loop, on OnEnable for unity.
        void Initialize()
        {
            client = new DiscordRpcClient("1114618806275416198");
            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "play.alorianmc.net",
                State = "Ana Menü",
                Assets = new Assets()
                {
                    LargeImageKey = "alrcraft",
                    LargeImageText = "AlorianMC",
                    SmallImageKey = "alrcraft_transparent",
                    SmallImageText = "play.alorianmc.net"
                }
            });
        }

        void InitializeLaunch()
        {
            client = new DiscordRpcClient("1114618806275416198");
            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "play.alorianmc.net",
                State = "Minecraft 1.16.5",
                Assets = new Assets()
                {
                    LargeImageKey = "alrcraft",
                    LargeImageText = "AlorianMC",
                    SmallImageKey = "alrcraft_transparent",
                    SmallImageText = "play.alorianmc.net"
                }
            });
        }

        void Deinitialize()
        {
            client.Dispose();
        }

        MSession session;

        private void path()
        {

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

            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                ServerIp = "play.alorianmc.net",
                Session = MSession.GetOfflineSession(LoginPage.user),
            };

            var process = launcher.CreateProcess("1.16.5", launchOption, checkAndDownload: true);

            process.Start();
            this.Hide();
            Deinitialize();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            Initialize();
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
