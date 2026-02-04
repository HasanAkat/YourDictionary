using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YourDictionary.Models;

namespace YourDictionary
{
    public partial class TestForm : Form
    {
        private readonly List<Word> _words;
        private readonly Random _random = new();
        private readonly List<Button> _termButtons;
        private Word? _currentWord;

        public TestForm(List<Word> words)
        {
            InitializeComponent();
            Icon = AppIconProvider.GetAppIcon();
            if (words == null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            _words = words;
            _termButtons = new List<Button> { termButton1, termButton2, termButton3 };

            if (_words.Count < 3)
            {
                throw new ArgumentException("At least three words are required to start the test.", nameof(words));
            }

            LoadNewQuestion();
        }

        private void LoadNewQuestion()
        {
            _currentWord = null;
            foreach (var button in _termButtons)
            {
                button.Enabled = true;
                button.BackColor = SystemColors.Control;
                button.UseVisualStyleBackColor = true;
                button.Tag = null;
            }

            _currentWord = _words[_random.Next(_words.Count)];
            definitionLabel.Text = _currentWord.Definition;

            List<Word> options = _words
                .Where(word => word.Term != _currentWord.Term)
                .OrderBy(_ => _random.Next())
                .Take(2)
                .Append(_currentWord)
                .OrderBy(_ => _random.Next())
                .ToList();

            for (int i = 0; i < options.Count; i++)
            {
                _termButtons[i].Text = options[i].Term;
                _termButtons[i].Tag = options[i];
            }
        }

        private void TermButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button || button.Tag is not Word selectedWord || _currentWord is null)
            {
                return;
            }

            bool isCorrect = selectedWord.Term == _currentWord.Term;
            button.UseVisualStyleBackColor = false;
            button.BackColor = isCorrect ? Color.LightGreen : Color.LightCoral;
            foreach (var btn in _termButtons)
            {
                btn.Enabled = false;
            }

            if (!isCorrect)
            {
                var correctButton = _termButtons.FirstOrDefault(
                    btn => btn.Tag is Word w && w.Term == _currentWord.Term);
                if (correctButton != null)
                {
                    correctButton.UseVisualStyleBackColor = false;
                    correctButton.BackColor = Color.LightGreen;
                }
            }
        }

        private void nextQuestionBTN_Click(object sender, EventArgs e)
        {
            LoadNewQuestion();
        }
    }

    public partial class TestForm
    {
        private TableLayoutPanel mainLayout;
        private Label definitionTitleLabel;
        private Label definitionLabel;
        private Button termButton1;
        private Button termButton2;
        private Button termButton3;
        private Button nextQuestionBTN;

        private void InitializeComponent()
        {
            mainLayout = new TableLayoutPanel();
            definitionTitleLabel = new Label();
            definitionLabel = new Label();
            termButton1 = new Button();
            termButton2 = new Button();
            termButton3 = new Button();
            nextQuestionBTN = new Button();
            mainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(definitionTitleLabel, 0, 0);
            mainLayout.Controls.Add(definitionLabel, 0, 1);
            mainLayout.Controls.Add(termButton1, 0, 2);
            mainLayout.Controls.Add(termButton2, 0, 3);
            mainLayout.Controls.Add(termButton3, 0, 4);
            mainLayout.Controls.Add(nextQuestionBTN, 0, 5);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(10, 10);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 6;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 23.3333321F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 23.3333321F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 23.3333321F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.Size = new Size(480, 340);
            mainLayout.TabIndex = 0;
            // 
            // definitionTitleLabel
            // 
            definitionTitleLabel.AutoSize = true;
            definitionTitleLabel.Dock = DockStyle.Fill;
            definitionTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            definitionTitleLabel.Location = new Point(3, 0);
            definitionTitleLabel.Name = "definitionTitleLabel";
            definitionTitleLabel.Size = new Size(474, 25);
            definitionTitleLabel.TabIndex = 0;
            definitionTitleLabel.Text = "Definition";
            // 
            // definitionLabel
            // 
            definitionLabel.BorderStyle = BorderStyle.FixedSingle;
            definitionLabel.Dock = DockStyle.Fill;
            definitionLabel.Font = new Font("Segoe UI", 10F);
            definitionLabel.Location = new Point(3, 25);
            definitionLabel.Name = "definitionLabel";
            definitionLabel.Padding = new Padding(6);
            definitionLabel.Size = new Size(474, 91);
            definitionLabel.TabIndex = 1;
            definitionLabel.Text = "Definition text";
            // 
            // termButton1
            // 
            termButton1.Dock = DockStyle.Fill;
            termButton1.Font = new Font("Segoe UI", 10F);
            termButton1.Location = new Point(3, 119);
            termButton1.Name = "termButton1";
            termButton1.Size = new Size(474, 68);
            termButton1.TabIndex = 2;
            termButton1.Text = "Term 1";
            termButton1.UseVisualStyleBackColor = true;
            termButton1.Click += TermButton_Click;
            // 
            // termButton2
            // 
            termButton2.Dock = DockStyle.Fill;
            termButton2.Font = new Font("Segoe UI", 10F);
            termButton2.Location = new Point(3, 193);
            termButton2.Name = "termButton2";
            termButton2.Size = new Size(474, 68);
            termButton2.TabIndex = 3;
            termButton2.Text = "Term 2";
            termButton2.UseVisualStyleBackColor = true;
            termButton2.Click += TermButton_Click;
            // 
            // termButton3
            // 
            termButton3.Dock = DockStyle.Fill;
            termButton3.Font = new Font("Segoe UI", 10F);
            termButton3.Location = new Point(3, 267);
            termButton3.Name = "termButton3";
            termButton3.Size = new Size(474, 68);
            termButton3.TabIndex = 4;
            termButton3.Text = "Term 3";
            termButton3.UseVisualStyleBackColor = true;
            termButton3.Click += TermButton_Click;
            // 
            // nextQuestionBTN
            // 
            nextQuestionBTN.Dock = DockStyle.Fill;
            nextQuestionBTN.Location = new Point(3, 338);
            nextQuestionBTN.Name = "nextQuestionBTN";
            nextQuestionBTN.Size = new Size(474, 34);
            nextQuestionBTN.TabIndex = 5;
            nextQuestionBTN.Text = "Yeni Soru";
            nextQuestionBTN.UseVisualStyleBackColor = true;
            nextQuestionBTN.Click += nextQuestionBTN_Click;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 360);
            Controls.Add(mainLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TestForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Definition Test";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ResumeLayout(false);
        }
    }
}
