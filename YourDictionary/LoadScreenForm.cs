namespace YourDictionary
{
    public partial class LoadScreenForm : Form
    {
        int i = 0;

        public LoadScreenForm()
        {
            InitializeComponent();
            Icon = AppIconProvider.GetAppIcon();
        }

        private void LoadScreenForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            while (i != 100)
            {
                i++;
            }

            HomeForm homeForm = new HomeForm();
            homeForm.FormClosed += (_, _) => Close();
            Hide();
            homeForm.Show();
        }
    }
}
