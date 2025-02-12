namespace YourDictionary
{
    partial class DictionaryForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            searchTB = new TextBox();
            logoIMG = new PictureBox();
            searchPanel = new TableLayoutPanel();
            searchBTN = new Button();
            addBTN = new Button();
            panel1 = new Panel();
            dictionaryGridView = new DataGridView();
            termColumn = new DataGridViewTextBoxColumn();
            definitionColumn = new DataGridViewTextBoxColumn();
            deleteColumn = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)logoIMG).BeginInit();
            searchPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dictionaryGridView).BeginInit();
            SuspendLayout();
            // 
            // searchTB
            // 
            searchTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTB.Location = new Point(316, 21);
            searchTB.Margin = new Padding(3, 3, 0, 3);
            searchTB.Name = "searchTB";
            searchTB.PlaceholderText = "Search in table...";
            searchTB.Size = new Size(401, 27);
            searchTB.TabIndex = 1;
            searchTB.TextChanged += SearchTB_TextChanged;
            searchTB.KeyDown += searchTB_KeyDown;
            // 
            // logoIMG
            // 
            logoIMG.Anchor = AnchorStyles.Left;
            logoIMG.Image = Resource.App_Logo;
            logoIMG.Location = new Point(13, 13);
            logoIMG.MinimumSize = new Size(64, 64);
            logoIMG.Name = "logoIMG";
            logoIMG.Size = new Size(64, 64);
            logoIMG.SizeMode = PictureBoxSizeMode.Zoom;
            logoIMG.TabIndex = 0;
            logoIMG.TabStop = false;
            // 
            // searchPanel
            // 
            searchPanel.ColumnCount = 4;
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            searchPanel.Controls.Add(searchBTN, 2, 0);
            searchPanel.Controls.Add(logoIMG, 0, 0);
            searchPanel.Controls.Add(searchTB, 1, 0);
            searchPanel.Controls.Add(addBTN, 3, 0);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(0, 0);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(10);
            searchPanel.RowCount = 1;
            searchPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            searchPanel.Size = new Size(1030, 70);
            searchPanel.TabIndex = 1;
            // 
            // searchBTN
            // 
            searchBTN.Anchor = AnchorStyles.Left;
            searchBTN.Location = new Point(717, 21);
            searchBTN.Margin = new Padding(0, 3, 3, 3);
            searchBTN.MinimumSize = new Size(50, 0);
            searchBTN.Name = "searchBTN";
            searchBTN.Size = new Size(59, 27);
            searchBTN.TabIndex = 4;
            searchBTN.Text = "search";
            searchBTN.UseVisualStyleBackColor = true;
            searchBTN.Click += searchBTN_Click;
            // 
            // addBTN
            // 
            addBTN.Anchor = AnchorStyles.Right;
            addBTN.Location = new Point(937, 13);
            addBTN.MinimumSize = new Size(50, 0);
            addBTN.Name = "addBTN";
            addBTN.Size = new Size(80, 44);
            addBTN.TabIndex = 3;
            addBTN.Text = "Add New";
            addBTN.UseVisualStyleBackColor = true;
            addBTN.Click += addBTN_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dictionaryGridView);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 70);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(1030, 407);
            panel1.TabIndex = 2;
            // 
            // dictionaryGridView
            // 
            dictionaryGridView.AllowUserToAddRows = false;
            dictionaryGridView.AllowUserToDeleteRows = false;
            dictionaryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dictionaryGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dictionaryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dictionaryGridView.Columns.AddRange(new DataGridViewColumn[] { termColumn, definitionColumn, deleteColumn });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dictionaryGridView.DefaultCellStyle = dataGridViewCellStyle1;
            dictionaryGridView.Dock = DockStyle.Fill;
            dictionaryGridView.Location = new Point(10, 10);
            dictionaryGridView.Margin = new Padding(10);
            dictionaryGridView.Name = "dictionaryGridView";
            dictionaryGridView.ReadOnly = true;
            dictionaryGridView.RowHeadersWidth = 51;
            dictionaryGridView.Size = new Size(1010, 387);
            dictionaryGridView.TabIndex = 3;
            // 
            // termColumn
            // 
            termColumn.FillWeight = 20F;
            termColumn.HeaderText = "Term";
            termColumn.MinimumWidth = 6;
            termColumn.Name = "termColumn";
            termColumn.ReadOnly = true;
            // 
            // definitionColumn
            // 
            definitionColumn.FillWeight = 70F;
            definitionColumn.HeaderText = "Definition";
            definitionColumn.MinimumWidth = 6;
            definitionColumn.Name = "definitionColumn";
            definitionColumn.ReadOnly = true;
            // 
            // deleteColumn
            // 
            deleteColumn.FillWeight = 10F;
            deleteColumn.HeaderText = "Delete";
            deleteColumn.MinimumWidth = 6;
            deleteColumn.Name = "deleteColumn";
            deleteColumn.ReadOnly = true;
            deleteColumn.Text = "Delete";
            deleteColumn.UseColumnTextForButtonValue = true;
            // 
            // DictionaryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(1030, 477);
            Controls.Add(panel1);
            Controls.Add(searchPanel);
            Name = "DictionaryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DictionaryForm";
            ((System.ComponentModel.ISupportInitialize)logoIMG).EndInit();
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dictionaryGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox logoIMG;
        private TextBox searchTB;
        private TableLayoutPanel searchPanel;
        private Button searchBTN;
        private Button addBTN;
        private Panel panel1;
        private DataGridView dictionaryGridView;
        private DataGridViewTextBoxColumn termColumn;
        private DataGridViewTextBoxColumn definitionColumn;
        private DataGridViewButtonColumn deleteColumn;
    }
}