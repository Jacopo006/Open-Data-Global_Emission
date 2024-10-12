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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVisualizzaCsv = new System.Windows.Forms.Button();
            this.BtnFilterRegion = new System.Windows.Forms.Button();
            this.txtRegionFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
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
            this.BtnFilterRegion.Location = new System.Drawing.Point(644, 105);
            this.BtnFilterRegion.Name = "BtnFilterRegion";
            this.BtnFilterRegion.Size = new System.Drawing.Size(70, 67);
            this.BtnFilterRegion.TabIndex = 2;
            this.BtnFilterRegion.Text = "Filtra Per Regione";
            this.BtnFilterRegion.UseVisualStyleBackColor = true;
            this.BtnFilterRegion.Click += new System.EventHandler(this.BtnFilterRegion_Click);
            // 
            // txtRegionFilter
            // 
            this.txtRegionFilter.Location = new System.Drawing.Point(538, 105);
            this.txtRegionFilter.Name = "txtRegionFilter";
            this.txtRegionFilter.Size = new System.Drawing.Size(100, 20);
            this.txtRegionFilter.TabIndex = 3;
            this.txtRegionFilter.TextChanged += new System.EventHandler(this.txtRegionFilter_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 605);
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
    }
}

