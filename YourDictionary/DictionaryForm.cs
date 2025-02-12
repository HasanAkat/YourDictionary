using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YourDictionary.Repositories;
using YourDictionary.Models;
using System.Diagnostics;

namespace YourDictionary
{
    public partial class DictionaryForm : Form
    {
        public DictionaryForm()
        {
            InitializeComponent();
            DisplayDictionaryData();  // Form açılınca verileri göster
        }

        private void DisplayDictionaryData()
        {
            dictionaryGridView.Rows.Clear(); // Önceki verileri temizle

            // Olay işleyicisini temizle
            dictionaryGridView.CellClick -= DictionaryGridView_CellClick;

            List<Word> words = DictionaryRepository.LoadWords();
            foreach (var word in words)
            {
                dictionaryGridView.Rows.Add(word.Term, word.Definition, "Delete");
            }

            // Olay işleyicisini tekrar ekle
            dictionaryGridView.CellClick += DictionaryGridView_CellClick;
        }

        private void DictionaryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Sil butonuna basıldıysa
            {
                Debug.WriteLine("Rows count: " + dictionaryGridView.Rows.Count);
                string termToDelete = dictionaryGridView.Rows[e.RowIndex].Cells[0].Value as string; // Term değeri

                if (!string.IsNullOrEmpty(termToDelete))
                {
                    DictionaryRepository.DeleteWord(termToDelete);
                    DisplayDictionaryData(); // Listeyi güncelle
                }
                else
                {
                    MessageBox.Show("Error: Could not determine the word to delete.");
                }
            }
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void searchTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();  // Enter’a basınca arama yap
            }
        }

        private void SearchTB_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTB.Text))
            {
                DisplayDictionaryData(); // 📌 Arama kutusu boşsa tüm verileri göster
            }
        }

        private void PerformSearch()
        {
            string searchText = searchTB.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a word.");
                return;
            }

            List<Word> filteredWords = DictionaryRepository.LoadWords()
                .Where(word => word.Term.ToLower().Contains(searchText) || word.Definition.ToLower().Contains(searchText))
                .ToList();

            dictionaryGridView.Rows.Clear();

            foreach (var word in filteredWords)
            {
                dictionaryGridView.Rows.Add(word.Term, word.Definition, "Delete");
            }
        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            AddWordForm addWordForm = new AddWordForm();
            addWordForm.ShowDialog();
            if (addWordForm.DialogResult == DialogResult.OK) // Eğer kelime başarıyla eklendiyse
            {
                DisplayDictionaryData(); // Listeyi güncelle
            }
        }
    }
}
