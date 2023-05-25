namespace AlorianLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            }
        }
    }
}