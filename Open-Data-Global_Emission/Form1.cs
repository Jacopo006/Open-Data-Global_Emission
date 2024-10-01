using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Open_Data_Global_Emission
{
    public partial class Form1 : Form
    {
        private List<MethaneData> listMethane;
        private bool OrdinatoCresc = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listMethane = new List<MethaneData>();

            // Carica i dati dal CSV
            CaricaDaCsv();
            // Carica i dati nella ListView
            CaricaNellaList();
        }

        private void CaricaDaCsv()
        {
            using (StreamReader sr = new StreamReader("Methane_final.csv"))
            {
                string line;
                bool PrimaLinea = true; // Per saltare l'intestazione

                while ((line = sr.ReadLine()) != null)
                {
                    if (PrimaLinea)
                    {
                        PrimaLinea = false; // Salta la prima riga (header)
                        continue;
                    }

                    string[] campo = line.Split(',');
                    if (campo.Length < 6) continue; // Assicurati che ci siano abbastanza campi

                    MethaneData data = new MethaneData
                    {
                        Region = campo[1],
                        Country = campo[2],
                        Emissions = double.TryParse(campo[3], out double emissions) ? emissions : 0,
                        Type = campo[4],
                        Segment = campo[5],
                        Reason = campo.Length > 6 ? campo[6] : string.Empty
                    };
                    listMethane.Add(data);
                }
            }
        }

        private void CaricaNellaList()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear(); // Azzera le colonne esistenti

            // Imposta la vista della ListView per mostrare i dettagli
            listView1.View = View.Details;

            // Aggiungi le colonne alla ListView
            listView1.Columns.Add("Region", 150);
            listView1.Columns.Add("Country", 150);
            listView1.Columns.Add("Emissions", 100);
            listView1.Columns.Add("Type", 100);
            listView1.Columns.Add("Segment", 100);
            listView1.Columns.Add("Reason", 150);

            // Aggiungi i dati dalla lista 'listMethane' alla ListView
            foreach (MethaneData data in listMethane)
            {
                ListViewItem item = new ListViewItem(data.Region);
                item.SubItems.Add(data.Country);
                item.SubItems.Add(data.Emissions.ToString());
                item.SubItems.Add(data.Type);
                item.SubItems.Add(data.Segment);
                item.SubItems.Add(data.Reason);

                // Aggiungi l'elemento alla ListView
                listView1.Items.Add(item);
            }
        }

        // Definizione della classe MethaneData
        class MethaneData
        {
            public string Region { get; set; }
            public string Country { get; set; }
            public double Emissions { get; set; }
            public string Type { get; set; }
            public string Segment { get; set; }
            public string Reason { get; set; }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0: // Region
                    listMethane = OrdinatoCresc
                        ? listMethane.OrderBy(m => m.Region).ToList()
                        : listMethane.OrderByDescending(m => m.Region).ToList();
                    break;
                case 1: // Country
                    listMethane = OrdinatoCresc
                        ? listMethane.OrderBy(m => m.Country).ToList()
                        : listMethane.OrderByDescending(m => m.Country).ToList();
                    break;
                case 2: // Emissions
                    listMethane = OrdinatoCresc
                        ? listMethane.OrderBy(m => m.Emissions).ToList()
                        : listMethane.OrderByDescending(m => m.Emissions).ToList();
                    break;
                    // Aggiungi casi per le altre colonne se necessario
            }

            // Inverte l'ordinamento per il prossimo click
            OrdinatoCresc = !OrdinatoCresc;

            CaricaNellaList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se ci sono elementi selezionati
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                // Esempio di utilizzo dei dati selezionati
                string selectedRegion = selectedItem.SubItems[0].Text;
                string selectedCountry = selectedItem.SubItems[1].Text;
                double selectedEmissions = double.Parse(selectedItem.SubItems[2].Text);
                string selectedType = selectedItem.SubItems[3].Text;
                string selectedSegment = selectedItem.SubItems[4].Text;
                string selectedReason = selectedItem.SubItems[5].Text;

                // Fai qualcosa con i dati selezionati
                MessageBox.Show($"Hai selezionato: {selectedRegion}, {selectedCountry}, {selectedEmissions}, {selectedType}, {selectedSegment}, {selectedReason}");
            }
        }
    }
}
