using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Open_Data_Global_Emission
{
    public partial class Form1 : Form
    {
        private List<MethaneData> listMethane;

        public Form1()
        {
            InitializeComponent();
        }

        // Evento che viene eseguito quando si carica la finestra
        private void Form1_Load(object sender, EventArgs e)
        {
            listMethane = new List<MethaneData>();
        }

        // Evento Click del bottone per visualizzare il CSV
        private void btnVisualizzaCsv_Click(object sender, EventArgs e)
        {
            // Carica i dati dal CSV
            CaricaDaCsv();
            // Visualizza i dati nella ListView
            CaricaNellaListView();
        }

        // Metodo che carica i dati dal file CSV
        private void CaricaDaCsv()
        {
            string filePath = "Methane_final.csv"; // Assicurati che il file sia nel percorso corretto

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Il file {filePath} non esiste. Assicurati che sia nel percorso corretto.");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    bool primaLinea = true; // Per saltare l'intestazione

                    listMethane.Clear(); // Pulisce la lista prima di aggiungere nuovi dati

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (primaLinea)
                        {
                            primaLinea = false; // Salta la prima riga (header)
                            continue;
                        }

                        string[] campo = line.Split(',');
                        if (campo.Length < 6) continue; // Assicurati che ci siano abbastanza campi

                        // Crea un nuovo oggetto MethaneData e lo aggiunge alla lista
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
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la lettura del file: {ex.Message}");
            }
        }

        // Metodo che carica i dati nella ListView
        private void CaricaNellaListView()
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

        // Evento che gestisce la selezione di un elemento nella ListView
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se ci sono elementi selezionati
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Mostra le informazioni dell'elemento selezionato in un MessageBox
                string selectedRegion = selectedItem.SubItems[0].Text;
                string selectedCountry = selectedItem.SubItems[1].Text;
                double selectedEmissions = double.Parse(selectedItem.SubItems[2].Text);
                string selectedType = selectedItem.SubItems[3].Text;
                string selectedSegment = selectedItem.SubItems[4].Text;
                string selectedReason = selectedItem.SubItems[5].Text;

                MessageBox.Show($"Hai selezionato: {selectedRegion}, {selectedCountry}, {selectedEmissions}, {selectedType}, {selectedSegment}, {selectedReason}");
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
    }
}
