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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCountryFilter = new System.Windows.Forms.TextBox();
            this.BtnFilterCountry = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnFilterYear = new System.Windows.Forms.Button();
            this.txtYearFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCalcolaStatistiche = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(28, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(503, 522);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnVisualizzaCsv
            // 
            this.btnVisualizzaCsv.Location = new System.Drawing.Point(537, 32);
            this.btnVisualizzaCsv.Name = "btnVisualizzaCsv";
            this.btnVisualizzaCsv.Size = new System.Drawing.Size(70, 67);
            this.btnVisualizzaCsv.TabIndex = 1;
            this.btnVisualizzaCsv.Text = "Apri File";
            this.btnVisualizzaCsv.UseVisualStyleBackColor = true;
            this.btnVisualizzaCsv.Click += new System.EventHandler(this.btnVisualizzaCsv_Click);
            // 
            // BtnFilterRegion
            // 
            this.BtnFilterRegion.Location = new System.Drawing.Point(645, 126);
            this.BtnFilterRegion.Name = "BtnFilterRegion";
            this.BtnFilterRegion.Size = new System.Drawing.Size(113, 20);
            this.BtnFilterRegion.TabIndex = 2;
            this.BtnFilterRegion.Text = "Filtra Per Regione";
            this.BtnFilterRegion.UseVisualStyleBackColor = true;
            this.BtnFilterRegion.Click += new System.EventHandler(this.BtnFilterRegion_Click);
            // 
            // txtRegionFilter
            // 
            this.txtRegionFilter.Location = new System.Drawing.Point(539, 126);
            this.txtRegionFilter.Name = "txtRegionFilter";
            this.txtRegionFilter.Size = new System.Drawing.Size(100, 20);
            this.txtRegionFilter.TabIndex = 3;
            this.txtRegionFilter.TextChanged += new System.EventHandler(this.txtRegionFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(539, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inserisci il nome della regione che vuoi filtrare";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Inserisci il nome del paese che vuoi filtrare";
            // 
            // txtCountryFilter
            // 
            this.txtCountryFilter.Location = new System.Drawing.Point(537, 178);
            this.txtCountryFilter.Name = "txtCountryFilter";
            this.txtCountryFilter.Size = new System.Drawing.Size(100, 20);
            this.txtCountryFilter.TabIndex = 6;
            this.txtCountryFilter.TextChanged += new System.EventHandler(this.txtCountryFilter_TextChanged);
            // 
            // BtnFilterCountry
            // 
            this.BtnFilterCountry.Location = new System.Drawing.Point(643, 178);
            this.BtnFilterCountry.Name = "BtnFilterCountry";
            this.BtnFilterCountry.Size = new System.Drawing.Size(113, 20);
            this.BtnFilterCountry.TabIndex = 5;
            this.BtnFilterCountry.Text = "Filtra Per Paese";
            this.BtnFilterCountry.UseVisualStyleBackColor = true;
            this.BtnFilterCountry.Click += new System.EventHandler(this.BtnFilterCountry_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(613, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 67);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ordinamento Emissioni Decrescente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(719, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 67);
            this.button2.TabIndex = 9;
            this.button2.Text = "Ordinamento Emissioni Crescente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnFilterYear
            // 
            this.BtnFilterYear.Location = new System.Drawing.Point(643, 226);
            this.BtnFilterYear.Name = "BtnFilterYear";
            this.BtnFilterYear.Size = new System.Drawing.Size(113, 20);
            this.BtnFilterYear.TabIndex = 10;
            this.BtnFilterYear.Text = "Filtra per Anno";
            this.BtnFilterYear.UseVisualStyleBackColor = true;
            this.BtnFilterYear.Click += new System.EventHandler(this.BtnFilterYear_Click);
            // 
            // txtYearFilter
            // 
            this.txtYearFilter.Location = new System.Drawing.Point(537, 226);
            this.txtYearFilter.Name = "txtYearFilter";
            this.txtYearFilter.Size = new System.Drawing.Size(100, 20);
            this.txtYearFilter.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Inserisci la data del paese che vuoi filtrare";
            // 
            // BtnCalcolaStatistiche
            // 
            this.BtnCalcolaStatistiche.Location = new System.Drawing.Point(537, 264);
            this.BtnCalcolaStatistiche.Name = "BtnCalcolaStatistiche";
            this.BtnCalcolaStatistiche.Size = new System.Drawing.Size(100, 67);
            this.BtnCalcolaStatistiche.TabIndex = 13;
            this.BtnCalcolaStatistiche.Text = "Media Emissioni";
            this.BtnCalcolaStatistiche.UseVisualStyleBackColor = true;
            this.BtnCalcolaStatistiche.Click += new System.EventHandler(this.BtnCalcolaStatistiche_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 605);
            this.Controls.Add(this.BtnCalcolaStatistiche);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYearFilter);
            this.Controls.Add(this.BtnFilterYear);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCountryFilter);
            this.Controls.Add(this.BtnFilterCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRegionFilter);
            this.Controls.Add(this.BtnFilterRegion);
            this.Controls.Add(this.btnVisualizzaCsv);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnVisualizzaCsv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button BtnFilterRegion;
        private System.Windows.Forms.TextBox txtRegionFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCountryFilter;
        private System.Windows.Forms.Button BtnFilterCountry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnFilterYear;
        private System.Windows.Forms.TextBox txtYearFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCalcolaStatistiche;
    }
}

