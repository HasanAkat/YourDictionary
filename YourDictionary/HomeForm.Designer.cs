namespace YourDictionary
{
    partial class HomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainLayout = new TableLayoutPanel();
            existingLessonsGroup = new GroupBox();
            openLessonButton = new Button();
            lessonsListBox = new ListBox();
            lessonsStatusLabel = new Label();
            createLessonGroup = new GroupBox();
            newLessonHintLabel = new Label();
            createLessonButton = new Button();
            newLessonTextBox = new TextBox();
            newLessonLabel = new Label();
            mainLayout.SuspendLayout();
            existingLessonsGroup.SuspendLayout();
            createLessonGroup.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            mainLayout.Controls.Add(existingLessonsGroup, 0, 0);
            mainLayout.Controls.Add(createLessonGroup, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(12);
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(784, 421);
            mainLayout.TabIndex = 0;
            // 
            // existingLessonsGroup
            // 
            existingLessonsGroup.Controls.Add(lessonsListBox);
            existingLessonsGroup.Controls.Add(openLessonButton);
            existingLessonsGroup.Controls.Add(lessonsStatusLabel);
            existingLessonsGroup.Dock = DockStyle.Fill;
            existingLessonsGroup.Location = new Point(15, 15);
            existingLessonsGroup.Margin = new Padding(3, 3, 12, 3);
            existingLessonsGroup.Name = "existingLessonsGroup";
            existingLessonsGroup.Padding = new Padding(10);
            existingLessonsGroup.Size = new Size(401, 391);
            existingLessonsGroup.TabIndex = 0;
            existingLessonsGroup.TabStop = false;
            existingLessonsGroup.Text = "Dersler";
            // 
            // openLessonButton
            // 
            openLessonButton.Dock = DockStyle.Bottom;
            openLessonButton.Enabled = false;
            openLessonButton.Location = new Point(10, 348);
            openLessonButton.Name = "openLessonButton";
            openLessonButton.Size = new Size(381, 33);
            openLessonButton.TabIndex = 2;
            openLessonButton.Text = "Dersi Ac";
            openLessonButton.UseVisualStyleBackColor = true;
            openLessonButton.Click += openLessonButton_Click;
            // 
            // lessonsListBox
            // 
            lessonsListBox.Dock = DockStyle.Fill;
            lessonsListBox.FormattingEnabled = true;
            lessonsListBox.ItemHeight = 20;
            lessonsListBox.Location = new Point(10, 60);
            lessonsListBox.Name = "lessonsListBox";
            lessonsListBox.Size = new Size(381, 321);
            lessonsListBox.TabIndex = 1;
            lessonsListBox.SelectedIndexChanged += lessonsListBox_SelectedIndexChanged;
            lessonsListBox.DoubleClick += lessonsListBox_DoubleClick;
            // 
            // lessonsStatusLabel
            // 
            lessonsStatusLabel.Dock = DockStyle.Top;
            lessonsStatusLabel.Location = new Point(10, 30);
            lessonsStatusLabel.Name = "lessonsStatusLabel";
            lessonsStatusLabel.Size = new Size(381, 30);
            lessonsStatusLabel.TabIndex = 0;
            lessonsStatusLabel.Text = "Dersler yukleniyor...";
            lessonsStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // createLessonGroup
            // 
            createLessonGroup.Controls.Add(newLessonHintLabel);
            createLessonGroup.Controls.Add(createLessonButton);
            createLessonGroup.Controls.Add(newLessonTextBox);
            createLessonGroup.Controls.Add(newLessonLabel);
            createLessonGroup.Dock = DockStyle.Fill;
            createLessonGroup.Location = new Point(430, 15);
            createLessonGroup.Margin = new Padding(2, 3, 3, 3);
            createLessonGroup.Name = "createLessonGroup";
            createLessonGroup.Padding = new Padding(10);
            createLessonGroup.Size = new Size(339, 391);
            createLessonGroup.TabIndex = 1;
            createLessonGroup.TabStop = false;
            createLessonGroup.Text = "Yeni Ders Olustur";
            // 
            // newLessonHintLabel
            // 
            newLessonHintLabel.AutoSize = true;
            newLessonHintLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            newLessonHintLabel.Location = new Point(13, 83);
            newLessonHintLabel.Name = "newLessonHintLabel";
            newLessonHintLabel.Size = new Size(271, 20);
            newLessonHintLabel.TabIndex = 3;
            newLessonHintLabel.Text = "Orn: \"Unite 1\", \"Kelime Grubu A\", vb.";
            // 
            // createLessonButton
            // 
            createLessonButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            createLessonButton.Location = new Point(13, 116);
            createLessonButton.Name = "createLessonButton";
            createLessonButton.Size = new Size(313, 33);
            createLessonButton.TabIndex = 2;
            createLessonButton.Text = "Ders Olustur";
            createLessonButton.UseVisualStyleBackColor = true;
            createLessonButton.Click += createLessonButton_Click;
            // 
            // newLessonTextBox
            // 
            newLessonTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newLessonTextBox.Location = new Point(13, 53);
            newLessonTextBox.Name = "newLessonTextBox";
            newLessonTextBox.Size = new Size(313, 27);
            newLessonTextBox.TabIndex = 1;
            newLessonTextBox.KeyDown += newLessonTextBox_KeyDown;
            // 
            // newLessonLabel
            // 
            newLessonLabel.AutoSize = true;
            newLessonLabel.Location = new Point(13, 30);
            newLessonLabel.Name = "newLessonLabel";
            newLessonLabel.Size = new Size(133, 20);
            newLessonLabel.TabIndex = 0;
            newLessonLabel.Text = "Yeni Ders Adi Girin";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(784, 421);
            Controls.Add(mainLayout);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YourDictionary - Ana Sayfa";
            Load += HomeForm_Load;
            mainLayout.ResumeLayout(false);
            existingLessonsGroup.ResumeLayout(false);
            createLessonGroup.ResumeLayout(false);
            createLessonGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private GroupBox existingLessonsGroup;
        private ListBox lessonsListBox;
        private Label lessonsStatusLabel;
        private Button openLessonButton;
        private GroupBox createLessonGroup;
        private Label newLessonHintLabel;
        private Button createLessonButton;
        private TextBox newLessonTextBox;
        private Label newLessonLabel;
    }
}
