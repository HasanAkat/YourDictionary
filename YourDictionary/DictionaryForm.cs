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
        private readonly LessonInfo _lessonInfo;

        public DictionaryForm(LessonInfo lessonInfo)
        {
            _lessonInfo = lessonInfo ?? throw new ArgumentNullException(nameof(lessonInfo));
            InitializeComponent();
            Icon = AppIconProvider.GetAppIcon();
            lessonNameLabel.Text = $"Lesson: {_lessonInfo.Name}";
            DisplayDictionaryData();
        }

        private void DisplayDictionaryData()
        {
            dictionaryGridView.Rows.Clear(); // Onceki verileri temizle

            // Olay isleyicisini temizle
            dictionaryGridView.CellClick -= DictionaryGridView_CellClick;

            List<Word> words = DictionaryRepository.LoadWords(_lessonInfo.Id);
            foreach (var word in words)
            {
                dictionaryGridView.Rows.Add(word.Term, word.Definition, "Delete");
            }

            // Olay isleyicisini tekrar ekle
            dictionaryGridView.CellClick += DictionaryGridView_CellClick;
        }

        private void DictionaryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Sil butonuna basildiysa
            {
                Debug.WriteLine("Rows count: " + dictionaryGridView.Rows.Count);
                string termToDelete = dictionaryGridView.Rows[e.RowIndex].Cells[0].Value as string; // Term degeri

                if (!string.IsNullOrEmpty(termToDelete))
                {
                    DictionaryRepository.DeleteWord(_lessonInfo.Id, termToDelete);
                    DisplayDictionaryData(); // Listeyi guncelle
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
                PerformSearch();  // Enter'a basinca arama yap
            }
        }

        private void SearchTB_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTB.Text))
            {
                DisplayDictionaryData(); // Arama kutusu bossa tum verileri goster
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

            List<Word> filteredWords = DictionaryRepository.LoadWords(_lessonInfo.Id)
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
            AddWordForm addWordForm = new AddWordForm(_lessonInfo);
            addWordForm.ShowDialog(this);
            if (addWordForm.DialogResult == DialogResult.OK) // Eger kelime basariyla eklendiyse
            {
                DisplayDictionaryData(); // Listeyi guncelle
            }
        }

        private void testBTN_Click(object sender, EventArgs e)
        {
            List<Word> words = DictionaryRepository.LoadWords(_lessonInfo.Id);
            if (words.Count < 3)
            {
                MessageBox.Show("Please add at least 3 words to start a test.", "Not enough words",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using TestForm testForm = new(words);
            testForm.ShowDialog(this);
        }
    }
}

