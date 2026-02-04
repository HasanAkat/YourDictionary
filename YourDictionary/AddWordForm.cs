using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YourDictionary.Models;
using YourDictionary.Repositories;

namespace YourDictionary
{
    public partial class AddWordForm : Form
    {
        private readonly LessonInfo _lessonInfo;

        public AddWordForm(LessonInfo lessonInfo)
        {
            _lessonInfo = lessonInfo ?? throw new ArgumentNullException(nameof(lessonInfo));
            InitializeComponent();
            Icon = AppIconProvider.GetAppIcon();
            lessonNameValueLabel.Text = _lessonInfo.Name;
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            string term = termTB.Text.Trim();
            string definition = definitionRTB.Text.Trim();

            // 📌 Boş girişleri kontrol et
            if (string.IsNullOrEmpty(term) || string.IsNullOrEmpty(definition))
            {
                MessageBox.Show("Please fill in both the term and definition fields.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 📌 Daha önce eklenmiş mi kontrol et
            var existingWords = DictionaryRepository.LoadWords(_lessonInfo.Id);
            if (existingWords.Any(w => w.Term.Equals(term, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("This term already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DictionaryRepository.AddWord(_lessonInfo.Id, term, definition);
            MessageBox.Show("Word added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
