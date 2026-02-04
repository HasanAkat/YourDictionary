namespace YourDictionary
{
    partial class AddWordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lessonNameValueLabel = new Label();
            lessonNameTitleLabel = new Label();
            label3 = new Label();
            cancelBTN = new Button();
            okBTN = new Button();
            definitionRTB = new RichTextBox();
            termTB = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lessonNameValueLabel);
            panel1.Controls.Add(lessonNameTitleLabel);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cancelBTN);
            panel1.Controls.Add(okBTN);
            panel1.Controls.Add(definitionRTB);
            panel1.Controls.Add(termTB);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(682, 303);
            panel1.TabIndex = 0;
            // 
            // lessonNameValueLabel
            // 
            lessonNameValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lessonNameValueLabel.Location = new Point(474, 66);
            lessonNameValueLabel.Name = "lessonNameValueLabel";
            lessonNameValueLabel.Size = new Size(196, 23);
            lessonNameValueLabel.TabIndex = 8;
            lessonNameValueLabel.Text = "-";
            lessonNameValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lessonNameTitleLabel
            // 
            lessonNameTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lessonNameTitleLabel.AutoSize = true;
            lessonNameTitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lessonNameTitleLabel.Location = new Point(382, 66);
            lessonNameTitleLabel.Name = "lessonNameTitleLabel";
            lessonNameTitleLabel.Size = new Size(86, 20);
            lessonNameTitleLabel.TabIndex = 7;
            lessonNameTitleLabel.Text = "Active lesson:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(175, 20);
            label3.Name = "label3";
            label3.Size = new Size(350, 41);
            label3.TabIndex = 6;
            label3.Text = "Add a new Term";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // cancelBTN
            // 
            cancelBTN.Anchor = AnchorStyles.None;
            cancelBTN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            cancelBTN.Location = new Point(382, 237);
            cancelBTN.Name = "cancelBTN";
            cancelBTN.Size = new Size(288, 54);
            cancelBTN.TabIndex = 5;
            cancelBTN.Text = "CANCEL";
            cancelBTN.UseVisualStyleBackColor = true;
            cancelBTN.Click += cancelBTN_Click;
            // 
            // okBTN
            // 
            okBTN.Anchor = AnchorStyles.None;
            okBTN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            okBTN.Location = new Point(7, 237);
            okBTN.Name = "okBTN";
            okBTN.Size = new Size(288, 54);
            okBTN.TabIndex = 4;
            okBTN.Text = "OK";
            okBTN.UseVisualStyleBackColor = true;
            okBTN.Click += okBTN_Click;
            // 
            // definitionRTB
            // 
            definitionRTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            definitionRTB.Location = new Point(5, 157);
            definitionRTB.Name = "definitionRTB";
            definitionRTB.Size = new Size(665, 54);
            definitionRTB.TabIndex = 3;
            definitionRTB.Text = "";
            // 
            // termTB
            // 
            termTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            termTB.Location = new Point(5, 89);
            termTB.Name = "termTB";
            termTB.Size = new Size(665, 27);
            termTB.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(5, 126);
            label2.Name = "label2";
            label2.Size = new Size(113, 28);
            label2.TabIndex = 1;
            label2.Text = "Definition:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(7, 58);
            label1.Name = "label1";
            label1.Size = new Size(64, 28);
            label1.TabIndex = 0;
            label1.Text = "Term:";
            // 
            // AddWordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(682, 303);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddWordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Word";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox termTB;
        private Label label2;
        private Label label1;
        private RichTextBox definitionRTB;
        private Button okBTN;
        private Button cancelBTN;
        private Label label3;
        private Label lessonNameValueLabel;
        private Label lessonNameTitleLabel;
    }
}
