namespace курсовая
{
    partial class Form1
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
            txtInput = new TextBox();
            dgvTable = new DataGridView();
            btnLoad = new Button();
            btnAnalyze = new Button();
            btnEncode = new Button();
            btnDecode = new Button();
            btnSort = new Button();
            lblStats = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(14, 17);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(125, 27);
            txtInput.TabIndex = 0;
            // 
            // dgvTable
            // 
            dgvTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTable.Location = new Point(12, 50);
            dgvTable.Name = "dgvTable";
            dgvTable.RowHeadersWidth = 51;
            dgvTable.Size = new Size(466, 278);
            dgvTable.TabIndex = 1;
            dgvTable.CellContentClick += dgvTable_CellContentClick;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(24, 360);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(104, 87);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "загрузка файла";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Location = new Point(134, 360);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(118, 87);
            btnAnalyze.TabIndex = 5;
            btnAnalyze.Text = "аналитика";
            btnAnalyze.UseVisualStyleBackColor = true;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // btnEncode
            // 
            btnEncode.Location = new Point(549, 17);
            btnEncode.Name = "btnEncode";
            btnEncode.Size = new Size(112, 29);
            btnEncode.TabIndex = 6;
            btnEncode.Text = "кодирование";
            btnEncode.UseVisualStyleBackColor = true;
            btnEncode.Click += btnEncode_Click;
            // 
            // btnDecode
            // 
            btnDecode.Location = new Point(549, 49);
            btnDecode.Name = "btnDecode";
            btnDecode.Size = new Size(135, 29);
            btnDecode.TabIndex = 7;
            btnDecode.Text = "декодирование";
            btnDecode.UseVisualStyleBackColor = true;
            btnDecode.Click += btnDecode_Click;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(258, 360);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(129, 87);
            btnSort.TabIndex = 8;
            btnSort.Text = "сортировка";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Location = new Point(549, 117);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(0, 20);
            lblStats.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 530);
            Controls.Add(lblStats);
            Controls.Add(btnSort);
            Controls.Add(btnDecode);
            Controls.Add(btnEncode);
            Controls.Add(btnAnalyze);
            Controls.Add(btnLoad);
            Controls.Add(dgvTable);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private DataGridView dgvTable;
        private Button btnLoad;
        private Button btnAnalyze;
        private Button btnEncode;
        private Button btnDecode;
        private Button btnSort;
        private Label lblStats;
    }
}
