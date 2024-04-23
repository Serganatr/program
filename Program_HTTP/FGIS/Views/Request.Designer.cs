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
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage5 = new System.Windows.Forms.TabPage();
            Loading = new System.Windows.Forms.RichTextBox();
            verification_date_end = new System.Windows.Forms.TextBox();
            verification_date_start = new System.Windows.Forms.TextBox();
            mi_modification = new System.Windows.Forms.TextBox();
            org_title = new System.Windows.Forms.TextBox();
            mit_number = new System.Windows.Forms.TextBox();
            button_HTTP = new System.Windows.Forms.Button();
            dataGridView_HTTP = new System.Windows.Forms.DataGridView();
            HTTP_LOAD = new System.Windows.Forms.Button();
            tabControl1.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HTTP).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new System.Drawing.Point(12, 13);
            tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1035, 453);
            tabControl1.TabIndex = 1;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(Loading);
            tabPage5.Controls.Add(verification_date_end);
            tabPage5.Controls.Add(verification_date_start);
            tabPage5.Controls.Add(mi_modification);
            tabPage5.Controls.Add(org_title);
            tabPage5.Controls.Add(mit_number);
            tabPage5.Controls.Add(button_HTTP);
            tabPage5.Controls.Add(dataGridView_HTTP);
            tabPage5.Controls.Add(HTTP_LOAD);
            tabPage5.Location = new System.Drawing.Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new System.Windows.Forms.Padding(3);
            tabPage5.Size = new System.Drawing.Size(1027, 420);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "HTTP";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // Loading
            // 
            Loading.Location = new System.Drawing.Point(206, 385);
            Loading.Name = "Loading";
            Loading.Size = new System.Drawing.Size(247, 29);
            Loading.TabIndex = 43;
            Loading.Text = "";
            // 
            // verification_date_end
            // 
            verification_date_end.AccessibleDescription = "";
            verification_date_end.Location = new System.Drawing.Point(794, 351);
            verification_date_end.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            verification_date_end.Name = "verification_date_end";
            verification_date_end.PlaceholderText = "15.01.2024";
            verification_date_end.Size = new System.Drawing.Size(191, 27);
            verification_date_end.TabIndex = 42;
            // 
            // verification_date_start
            // 
            verification_date_start.AccessibleDescription = "";
            verification_date_start.Location = new System.Drawing.Point(597, 351);
            verification_date_start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            verification_date_start.Name = "verification_date_start";
            verification_date_start.PlaceholderText = "13.01.2024";
            verification_date_start.Size = new System.Drawing.Size(191, 27);
            verification_date_start.TabIndex = 41;
            // 
            // mi_modification
            // 
            mi_modification.AccessibleDescription = "";
            mi_modification.Location = new System.Drawing.Point(400, 351);
            mi_modification.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            mi_modification.Name = "mi_modification";
            mi_modification.PlaceholderText = "350C04";
            mi_modification.Size = new System.Drawing.Size(191, 27);
            mi_modification.TabIndex = 40;
            // 
            // org_title
            // 
            org_title.AccessibleDescription = "";
            org_title.Location = new System.Drawing.Point(203, 351);
            org_title.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            org_title.Name = "org_title";
            org_title.PlaceholderText = "ФГУП \\\"РФЯЦ - ВНИИЭФ\\\"";
            org_title.Size = new System.Drawing.Size(191, 27);
            org_title.TabIndex = 39;
            // 
            // mit_number
            // 
            mit_number.AccessibleDescription = "";
            mit_number.Location = new System.Drawing.Point(6, 351);
            mit_number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            mit_number.Name = "mit_number";
            mit_number.PlaceholderText = "64173-16";
            mit_number.Size = new System.Drawing.Size(191, 27);
            mit_number.TabIndex = 38;
            // 
            // button_HTTP
            // 
            button_HTTP.Location = new System.Drawing.Point(106, 385);
            button_HTTP.Name = "button_HTTP";
            button_HTTP.Size = new System.Drawing.Size(94, 29);
            button_HTTP.TabIndex = 29;
            button_HTTP.Text = "Вывод";
            button_HTTP.UseVisualStyleBackColor = true;
            // 
            // dataGridView_HTTP
            // 
            dataGridView_HTTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HTTP.Location = new System.Drawing.Point(6, 4);
            dataGridView_HTTP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dataGridView_HTTP.Name = "dataGridView_HTTP";
            dataGridView_HTTP.RowHeadersWidth = 51;
            dataGridView_HTTP.RowTemplate.Height = 25;
            dataGridView_HTTP.Size = new System.Drawing.Size(1015, 339);
            dataGridView_HTTP.TabIndex = 28;
            // 
            // HTTP_LOAD
            // 
            HTTP_LOAD.Location = new System.Drawing.Point(6, 385);
            HTTP_LOAD.Name = "HTTP_LOAD";
            HTTP_LOAD.Size = new System.Drawing.Size(94, 29);
            HTTP_LOAD.TabIndex = 27;
            HTTP_LOAD.Text = "Найти";
            HTTP_LOAD.UseVisualStyleBackColor = true;
            HTTP_LOAD.Click += HTTP_LOAD_Click;
            // 
            // Request
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1056, 477);
            Controls.Add(tabControl1);
            Name = "Request";
            Text = "Request";
            Load += Request_Load;
            tabControl1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HTTP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox verification_date_end;
        private System.Windows.Forms.TextBox verification_date_start;
        private System.Windows.Forms.TextBox mi_modification;
        private System.Windows.Forms.TextBox org_title;
        private System.Windows.Forms.TextBox mit_number;
        private System.Windows.Forms.Button button_HTTP;
        private System.Windows.Forms.Button HTTP_LOAD;
        public System.Windows.Forms.RichTextBox Loading;
        public System.Windows.Forms.DataGridView dataGridView_HTTP;
    }
}