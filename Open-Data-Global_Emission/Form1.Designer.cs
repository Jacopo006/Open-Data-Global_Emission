namespace Open_Data_Global_Emission
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVisualizzaCsv = new System.Windows.Forms.Button();
            this.BtnFilterRegion = new System.Windows.Forms.Button();
            this.txtRegionFilter = new System.Windows.Forms.TextBox();
            this.txtCountryFilter = new System.Windows.Forms.TextBox();
            this.BtnFilterCountry = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnFilterYear = new System.Windows.Forms.Button();
            this.txtYearFilter = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnAlert = new System.Windows.Forms.Button();
            this.BtnResetFiltri = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(12, 181);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(549, 168);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnVisualizzaCsv
            // 
            this.btnVisualizzaCsv.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnVisualizzaCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizzaCsv.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnVisualizzaCsv.Location = new System.Drawing.Point(10, 12);
            this.btnVisualizzaCsv.Name = "btnVisualizzaCsv";
            this.btnVisualizzaCsv.Size = new System.Drawing.Size(109, 67);
            this.btnVisualizzaCsv.TabIndex = 1;
            this.btnVisualizzaCsv.Text = "Apri File";
            this.btnVisualizzaCsv.UseVisualStyleBackColor = false;
            this.btnVisualizzaCsv.Click += new System.EventHandler(this.btnVisualizzaCsv_Click);
            // 
            // BtnFilterRegion
            // 
            this.BtnFilterRegion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnFilterRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFilterRegion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnFilterRegion.Location = new System.Drawing.Point(119, 112);
            this.BtnFilterRegion.Name = "BtnFilterRegion";
            this.BtnFilterRegion.Size = new System.Drawing.Size(113, 63);
            this.BtnFilterRegion.TabIndex = 2;
            this.BtnFilterRegion.Text = "Filtra Per Regione";
            this.BtnFilterRegion.UseVisualStyleBackColor = false;
            this.BtnFilterRegion.Click += new System.EventHandler(this.BtnFilterRegion_Click);
            // 
            // txtRegionFilter
            // 
            this.txtRegionFilter.Location = new System.Drawing.Point(12, 112);
            this.txtRegionFilter.Multiline = true;
            this.txtRegionFilter.Name = "txtRegionFilter";
            this.txtRegionFilter.Size = new System.Drawing.Size(107, 63);
            this.txtRegionFilter.TabIndex = 3;
            this.txtRegionFilter.TextChanged += new System.EventHandler(this.txtRegionFilter_TextChanged);
            // 
            // txtCountryFilter
            // 
            this.txtCountryFilter.Location = new System.Drawing.Point(238, 112);
            this.txtCountryFilter.Multiline = true;
            this.txtCountryFilter.Name = "txtCountryFilter";
            this.txtCountryFilter.Size = new System.Drawing.Size(111, 63);
            this.txtCountryFilter.TabIndex = 6;
            this.txtCountryFilter.TextChanged += new System.EventHandler(this.txtCountryFilter_TextChanged);
            // 
            // BtnFilterCountry
            // 
            this.BtnFilterCountry.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnFilterCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFilterCountry.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnFilterCountry.Location = new System.Drawing.Point(348, 112);
            this.BtnFilterCountry.Name = "BtnFilterCountry";
            this.BtnFilterCountry.Size = new System.Drawing.Size(104, 63);
            this.BtnFilterCountry.TabIndex = 5;
            this.BtnFilterCountry.Text = "Filtra Per Paese";
            this.BtnFilterCountry.UseVisualStyleBackColor = false;
            this.BtnFilterCountry.Click += new System.EventHandler(this.BtnFilterCountry_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(125, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 67);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ordinamento Emissioni Decrescente";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(238, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 67);
            this.button2.TabIndex = 9;
            this.button2.Text = "Ordinamento Emissioni Crescente";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnFilterYear
            // 
            this.BtnFilterYear.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnFilterYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFilterYear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnFilterYear.Location = new System.Drawing.Point(567, 112);
            this.BtnFilterYear.Name = "BtnFilterYear";
            this.BtnFilterYear.Size = new System.Drawing.Size(104, 63);
            this.BtnFilterYear.TabIndex = 10;
            this.BtnFilterYear.Text = "Filtra per Anno";
            this.BtnFilterYear.UseVisualStyleBackColor = false;
            this.BtnFilterYear.Click += new System.EventHandler(this.BtnFilterYear_Click);
            // 
            // txtYearFilter
            // 
            this.txtYearFilter.Location = new System.Drawing.Point(461, 112);
            this.txtYearFilter.Multiline = true;
            this.txtYearFilter.Name = "txtYearFilter";
            this.txtYearFilter.Size = new System.Drawing.Size(100, 63);
            this.txtYearFilter.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(680, 112);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 63);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnAlert
            // 
            this.BtnAlert.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlert.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAlert.Location = new System.Drawing.Point(786, 112);
            this.BtnAlert.Name = "BtnAlert";
            this.BtnAlert.Size = new System.Drawing.Size(104, 63);
            this.BtnAlert.TabIndex = 16;
            this.BtnAlert.Text = "Inserisci la soglia d\'allerta";
            this.BtnAlert.UseVisualStyleBackColor = false;
            this.BtnAlert.Click += new System.EventHandler(this.BtnAlert_Click);
            // 
            // BtnResetFiltri
            // 
            this.BtnResetFiltri.BackColor = System.Drawing.Color.Red;
            this.BtnResetFiltri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetFiltri.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnResetFiltri.Location = new System.Drawing.Point(784, 12);
            this.BtnResetFiltri.Name = "BtnResetFiltri";
            this.BtnResetFiltri.Size = new System.Drawing.Size(104, 63);
            this.BtnResetFiltri.TabIndex = 18;
            this.BtnResetFiltri.Text = "Resetta filtri";
            this.BtnResetFiltri.UseVisualStyleBackColor = false;
            this.BtnResetFiltri.Click += new System.EventHandler(this.BtnResetFiltri_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(400, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 458);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnResetFiltri);
            this.Controls.Add(this.BtnAlert);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtYearFilter);
            this.Controls.Add(this.BtnFilterYear);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCountryFilter);
            this.Controls.Add(this.BtnFilterCountry);
            this.Controls.Add(this.txtRegionFilter);
            this.Controls.Add(this.BtnFilterRegion);
            this.Controls.Add(this.btnVisualizzaCsv);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnVisualizzaCsv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button BtnFilterRegion;
        private System.Windows.Forms.TextBox txtRegionFilter;
        private System.Windows.Forms.TextBox txtCountryFilter;
        private System.Windows.Forms.Button BtnFilterCountry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnFilterYear;
        private System.Windows.Forms.TextBox txtYearFilter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnAlert;
        private System.Windows.Forms.Button BtnResetFiltri;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

