using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open_Data_Global_Emission
{
    public partial class Form1 : Form
    {
        private List<EmissionData> emissionList;

        public Form1()
        {
            InitializeComponent();
            emissionList = new List<EmissionData>();
        }

        // Assicurati di chiamare SetupListView() nel costruttore o all'inizio
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnVisualizzaCsv_Click(object sender, EventArgs e)
        {
            CaricaDaCsv(); // Carica e visualizza il CSV
            CaricaNellaListView(); // Carica i dati nella ListView
        }

        private async void CaricaDaCsv()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Methane_final.csv");

            try
            {
                if (!File.Exists(filePath))
                {
                    listView1.Items.Add($"Il file {filePath} non esiste. Assicurati che sia nel percorso corretto.");
                    return;
                }

                listView1.Items.Clear(); // Pulisci la ListView esistente
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        if (isFirstLine)
                        {
                            // Salta la prima riga (header)
                            isFirstLine = false;
                            continue;
                        }

                        string[] campo = line.Split(',');

                        // Controlla se ci sono esattamente 8 colonne
                        if (campo.Length != 8)
                        {
                            continue; // Ignora righe con numero di colonne errato
                        }

                        // Crea un nuovo elemento ListView per la riga
                        ListViewItem item = new ListViewItem(campo[0].Trim()); // Prima colonna (Number)

                        // Aggiungi le altre colonne
                        for (int i = 1; i < campo.Length; i++)
                        {
                            item.SubItems.Add(campo[i].Trim());
                        }

                        // Aggiungi l'elemento alla ListView
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                listView1.Items.Add($"Errore durante la lettura del file: {ex.Message}");
            }
        }



        private void CaricaNellaListView()
        {
            listView1.View = View.Details;

            listView1.Items.Clear(); // Pulisci gli elementi esistenti
            listView1.Columns.Clear(); // Pulisci le colonne esistenti

            // Aggiungi i titoli delle colonne
            listView1.Columns.Add("number", 100);
            listView1.Columns.Add("region", 100);
            listView1.Columns.Add("country", 100);
            listView1.Columns.Add("emissions", 100);
            listView1.Columns.Add("type", 100);
            listView1.Columns.Add("segment", 100);
            listView1.Columns.Add("reason", 100);
            listView1.Columns.Add("baseYear", 100);

            // Debug: verifica il numero di colonne aggiunte
            Console.WriteLine($"Numero di colonne: {listView1.Columns.Count}");

            // Aggiungi i dati dalla lista alla ListView
            foreach (var emission in emissionList)
            {
                ListViewItem item = new ListViewItem(emission.Number);
                item.SubItems.Add(emission.Region);
                item.SubItems.Add(emission.Country);
                item.SubItems.Add(emission.Emissions);
                item.SubItems.Add(emission.Type);
                item.SubItems.Add(emission.Segment);
                item.SubItems.Add(emission.Reason);
                item.SubItems.Add(emission.BaseYear);

                listView1.Items.Add(item);
            }

            // Imposta la larghezza delle colonne in base al contenuto
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // -2 significa "adatta automaticamente alla larghezza del contenuto"
            }
        }


        // Evento che gestisce la selezione di un elemento nella ListView
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string message = $"Hai selezionato: {selectedItem.SubItems[0].Text}, {selectedItem.SubItems[1].Text}, {selectedItem.SubItems[2].Text}, {selectedItem.SubItems[3].Text}, {selectedItem.SubItems[4].Text}, {selectedItem.SubItems[5].Text}, {selectedItem.SubItems[6].Text}, {selectedItem.SubItems[7].Text}";
                MessageBox.Show(message);
            }
        }
    }

    public class EmissionData
    {
        public string Number { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Emissions { get; set; }
        public string Type { get; set; }
        public string Segment { get; set; }
        public string Reason { get; set; }
        public string BaseYear { get; set; }
    }
}
