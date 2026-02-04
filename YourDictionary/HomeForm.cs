using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YourDictionary.Models;
using YourDictionary.Repositories;

namespace YourDictionary
{
    public partial class HomeForm : Form
    {
        private List<LessonInfo> _lessons = new();

        public HomeForm()
        {
            InitializeComponent();
            Icon = AppIconProvider.GetAppIcon();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            LessonRepository.TryMigrateLegacyDictionary();
            RefreshLessonList();
        }

        private void RefreshLessonList()
        {
            _lessons = LessonRepository.LoadLessons().ToList();

            lessonsListBox.DataSource = null;
            lessonsListBox.DisplayMember = nameof(LessonInfo.Name);
            lessonsListBox.ValueMember = nameof(LessonInfo.Id);
            lessonsListBox.DataSource = _lessons;

            lessonsStatusLabel.Text = _lessons.Count == 0
                ? "Henuz ders bulunmuyor. Yeni bir ders olusturun."
                : $"{_lessons.Count} ders mevcut.";

            UpdateOpenButtonState();
        }

        private void UpdateOpenButtonState()
        {
            openLessonButton.Enabled = lessonsListBox.SelectedItem is LessonInfo;
        }

        private void createLessonButton_Click(object sender, EventArgs e)
        {
            string lessonName = newLessonTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(lessonName))
            {
                MessageBox.Show("Lutfen yeni ders icin bir isim girin.", "Eksik bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LessonInfo lesson = LessonRepository.CreateLesson(lessonName);
                newLessonTextBox.Clear();
                RefreshLessonList();
                OpenLesson(lesson);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Bu isimde bir ders zaten mevcut.", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ders olusturulurken hata olustu: {ex.Message}", "Beklenmeyen hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newLessonTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                createLessonButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void openLessonButton_Click(object sender, EventArgs e)
        {
            if (lessonsListBox.SelectedItem is LessonInfo lesson)
            {
                OpenLesson(lesson);
            }
        }

        private void lessonsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (lessonsListBox.SelectedItem is LessonInfo lesson)
            {
                OpenLesson(lesson);
            }
        }

        private void lessonsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOpenButtonState();
        }

        private void OpenLesson(LessonInfo lesson)
        {
            var dictionaryForm = new DictionaryForm(lesson);
            dictionaryForm.FormClosed += (_, _) =>
            {
                Show();
                RefreshLessonList();
            };

            Hide();
            dictionaryForm.Show(this);
        }
    }
}
