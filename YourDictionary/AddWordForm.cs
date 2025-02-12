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
        public AddWordForm()
        {
            InitializeComponent();
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            string term = termTB.Text.Trim();
            string definition = definitionRTB.Text.Trim();

            // 📌 Boş girişleri kontrol et
            if (string.IsNullOrEmpty(term) || string.IsNullOrEmpty(definition))
            {
                MessageBox.Show("Lütfen hem terim hem de tanım alanlarını doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 📌 Daha önce eklenmiş mi kontrol et
            var existingWords = DictionaryRepository.LoadWords();
            if (existingWords.Any(w => w.Term.Equals(term, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Bu terim zaten mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DictionaryRepository.AddWord(term, definition);
            MessageBox.Show("Kelime başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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