using DiscordRPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlorianLauncher
{
    public partial class LoginPage : Form
    {

        public LoginPage()
        {
            InitializeComponent();
            Initialize();
        }

        public static string user;

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
                State = "Giriş Yap",
                Assets = new Assets()
                {
                    LargeImageKey = "alrcraft",
                    LargeImageText = "AlorianMC",
                    SmallImageKey = "alrcraft_transparent"
                }
            });
        }

        void Deinitialize()
        {
            client.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void kullanici_adi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            user = kullanici_adi.Text;

            if (user.Length < 3 || user.Length > 16)
            {
                hata_uyari.Visible = true;
            }
            else
            {
                hata_uyari.Visible = false;

                MainPage mp = new MainPage();
                mp.Show();
                Deinitialize();
                this.Hide();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
