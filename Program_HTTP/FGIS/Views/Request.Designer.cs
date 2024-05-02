namespace FGIS.Views
{
    partial class Request
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
            tabPage3 = new System.Windows.Forms.TabPage();
            SELECT_ALL = new System.Windows.Forms.Button();
            dataGridView_SQL = new System.Windows.Forms.DataGridView();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            Date_end_SQL = new System.Windows.Forms.TextBox();
            Date_start_SQL = new System.Windows.Forms.TextBox();
            mi_modification_SQL = new System.Windows.Forms.TextBox();
            mit_number_SQL = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            Select_SQL = new System.Windows.Forms.Button();
            tabPage5 = new System.Windows.Forms.TabPage();
            Loading = new System.Windows.Forms.RichTextBox();
            verification_date_end = new System.Windows.Forms.TextBox();
            verification_date_start = new System.Windows.Forms.TextBox();
            mi_modification = new System.Windows.Forms.TextBox();
            mit_number = new System.Windows.Forms.TextBox();
            dataGridView_HTTP = new System.Windows.Forms.DataGridView();
            HTTP_LOAD = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_SQL).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HTTP).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(SELECT_ALL);
            tabPage3.Controls.Add(dataGridView_SQL);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(Date_end_SQL);
            tabPage3.Controls.Add(Date_start_SQL);
            tabPage3.Controls.Add(mi_modification_SQL);
            tabPage3.Controls.Add(mit_number_SQL);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(Select_SQL);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(3);
            tabPage3.Size = new System.Drawing.Size(898, 312);
            tabPage3.TabIndex = 6;
            tabPage3.Text = "SQL";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // SELECT_ALL
            // 
            SELECT_ALL.Location = new System.Drawing.Point(9, 283);
            SELECT_ALL.Name = "SELECT_ALL";
            SELECT_ALL.Size = new System.Drawing.Size(156, 23);
            SELECT_ALL.TabIndex = 46;
            SELECT_ALL.Text = "Вывести всё";
            SELECT_ALL.UseVisualStyleBackColor = true;
            SELECT_ALL.Click += SELECT_ALL_Click;
            // 
            // dataGridView_SQL
            // 
            dataGridView_SQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_SQL.Location = new System.Drawing.Point(168, 3);
            dataGridView_SQL.Name = "dataGridView_SQL";
            dataGridView_SQL.RowHeadersWidth = 51;
            dataGridView_SQL.RowTemplate.Height = 25;
            dataGridView_SQL.Size = new System.Drawing.Size(727, 306);
            dataGridView_SQL.TabIndex = 45;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(90, 116);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(22, 15);
            label4.TabIndex = 44;
            label4.Text = "До";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 116);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(21, 15);
            label5.TabIndex = 43;
            label5.Text = "От";
            // 
            // Date_end_SQL
            // 
            Date_end_SQL.Location = new System.Drawing.Point(115, 110);
            Date_end_SQL.Name = "Date_end_SQL";
            Date_end_SQL.PlaceholderText = "2024";
            Date_end_SQL.Size = new System.Drawing.Size(47, 23);
            Date_end_SQL.TabIndex = 42;
            // 
            // Date_start_SQL
            // 
            Date_start_SQL.Location = new System.Drawing.Point(33, 110);
            Date_start_SQL.Name = "Date_start_SQL";
            Date_start_SQL.PlaceholderText = "2023";
            Date_start_SQL.Size = new System.Drawing.Size(48, 23);
            Date_start_SQL.TabIndex = 41;
            // 
            // mi_modification_SQL
            // 
            mi_modification_SQL.Location = new System.Drawing.Point(6, 66);
            mi_modification_SQL.Name = "mi_modification_SQL";
            mi_modification_SQL.PlaceholderText = "350С04";
            mi_modification_SQL.Size = new System.Drawing.Size(156, 23);
            mi_modification_SQL.TabIndex = 39;
            // 
            // mit_number_SQL
            // 
            mit_number_SQL.AccessibleDescription = "";
            mit_number_SQL.Location = new System.Drawing.Point(6, 21);
            mit_number_SQL.Name = "mit_number_SQL";
            mit_number_SQL.PlaceholderText = "64173-16";
            mit_number_SQL.Size = new System.Drawing.Size(156, 23);
            mit_number_SQL.TabIndex = 37;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(9, 95);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(48, 15);
            label6.TabIndex = 40;
            label6.Text = "Периуд";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(9, 51);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(126, 15);
            label8.TabIndex = 38;
            label8.Text = "Номер модификации";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(9, 6);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(146, 15);
            label10.TabIndex = 36;
            label10.Text = "Регистрационный номер";
            // 
            // Select_SQL
            // 
            Select_SQL.Location = new System.Drawing.Point(6, 139);
            Select_SQL.Name = "Select_SQL";
            Select_SQL.Size = new System.Drawing.Size(156, 23);
            Select_SQL.TabIndex = 35;
            Select_SQL.Text = "Найти";
            Select_SQL.UseVisualStyleBackColor = true;
            Select_SQL.Click += Select_SQL_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(Loading);
            tabPage5.Controls.Add(verification_date_end);
            tabPage5.Controls.Add(verification_date_start);
            tabPage5.Controls.Add(mi_modification);
            tabPage5.Controls.Add(mit_number);
            tabPage5.Controls.Add(dataGridView_HTTP);
            tabPage5.Controls.Add(HTTP_LOAD);
            tabPage5.Location = new System.Drawing.Point(4, 24);
            tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage5.Size = new System.Drawing.Size(898, 312);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "HTTP";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // Loading
            // 
            Loading.Location = new System.Drawing.Point(5, 289);
            Loading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Loading.Name = "Loading";
            Loading.Size = new System.Drawing.Size(75, 21);
            Loading.TabIndex = 43;
            Loading.Text = "";
            // 
            // verification_date_end
            // 
            verification_date_end.AccessibleDescription = "";
            verification_date_end.Location = new System.Drawing.Point(525, 263);
            verification_date_end.Name = "verification_date_end";
            verification_date_end.PlaceholderText = "15.01.2024";
            verification_date_end.Size = new System.Drawing.Size(168, 23);
            verification_date_end.TabIndex = 42;
            // 
            // verification_date_start
            // 
            verification_date_start.AccessibleDescription = "";
            verification_date_start.Location = new System.Drawing.Point(353, 263);
            verification_date_start.Name = "verification_date_start";
            verification_date_start.PlaceholderText = "13.01.2024";
            verification_date_start.Size = new System.Drawing.Size(168, 23);
            verification_date_start.TabIndex = 41;
            // 
            // mi_modification
            // 
            mi_modification.AccessibleDescription = "";
            mi_modification.Location = new System.Drawing.Point(180, 263);
            mi_modification.Name = "mi_modification";
            mi_modification.PlaceholderText = "350C04";
            mi_modification.Size = new System.Drawing.Size(168, 23);
            mi_modification.TabIndex = 40;
            // 
            // mit_number
            // 
            mit_number.AccessibleDescription = "";
            mit_number.Location = new System.Drawing.Point(5, 263);
            mit_number.Name = "mit_number";
            mit_number.PlaceholderText = "64173-16";
            mit_number.Size = new System.Drawing.Size(168, 23);
            mit_number.TabIndex = 38;
            // 
            // dataGridView_HTTP
            // 
            dataGridView_HTTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HTTP.Location = new System.Drawing.Point(5, 3);
            dataGridView_HTTP.Name = "dataGridView_HTTP";
            dataGridView_HTTP.RowHeadersWidth = 51;
            dataGridView_HTTP.RowTemplate.Height = 25;
            dataGridView_HTTP.Size = new System.Drawing.Size(888, 254);
            dataGridView_HTTP.TabIndex = 28;
            // 
            // HTTP_LOAD
            // 
            HTTP_LOAD.Location = new System.Drawing.Point(697, 263);
            HTTP_LOAD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            HTTP_LOAD.Name = "HTTP_LOAD";
            HTTP_LOAD.Size = new System.Drawing.Size(82, 22);
            HTTP_LOAD.TabIndex = 27;
            HTTP_LOAD.Text = "Найти";
            HTTP_LOAD.UseVisualStyleBackColor = true;
            HTTP_LOAD.Click += HTTP_LOAD_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new System.Drawing.Point(10, 10);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(906, 340);
            tabControl1.TabIndex = 1;
            // 
            // Request
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(924, 358);
            Controls.Add(tabControl1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Request";
            Text = "Request";
            Load += Request_Load;
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_SQL).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HTTP).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView_SQL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Date_end_SQL;
        private System.Windows.Forms.TextBox Date_start_SQL;
        private System.Windows.Forms.TextBox mi_modification_SQL;
        private System.Windows.Forms.TextBox mit_number_SQL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Select_SQL;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.RichTextBox Loading;
        private System.Windows.Forms.TextBox verification_date_end;
        private System.Windows.Forms.TextBox verification_date_start;
        private System.Windows.Forms.TextBox mi_modification;
        private System.Windows.Forms.TextBox mit_number;
        public System.Windows.Forms.DataGridView dataGridView_HTTP;
        private System.Windows.Forms.Button HTTP_LOAD;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button SELECT_ALL;
    }
}