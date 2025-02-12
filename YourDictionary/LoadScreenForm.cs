namespace YourDictionary
{
    public partial class LoadScreenForm : Form
    {
        int i = 0;

        public LoadScreenForm()
        {
            InitializeComponent();
        }

        private void LoadScreenForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (i != 100)
            {
                i++;
            }
            DictionaryForm dictionaryForm = new DictionaryForm();
            dictionaryForm.Show();
            this.Hide();
            timer1.Stop();
        }
    }
}
