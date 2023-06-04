using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Events;


namespace AlorianLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initialize();
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
                State = "Başlatılıyor",
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval += 1;
            if (timer.Interval >= 150)
            {
                timer.Stop();
                LoginPage lg = new LoginPage();
                lg.Show();
                this.Hide();
                Deinitialize();

            }
        }
    }
}
