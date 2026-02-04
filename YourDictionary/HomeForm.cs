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
                ? "No lessons yet. Create a new one to get started."
                : $"{_lessons.Count} lessons available.";

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
                MessageBox.Show("Please enter a name for the new lesson.", "Missing information",
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
                MessageBox.Show("A lesson with this name already exists.", "Duplicate lesson",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the lesson: {ex.Message}", "Unexpected error",
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
