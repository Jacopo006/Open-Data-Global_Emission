using System;
using System.IO;
using System.Windows.Forms;

namespace Open_Data_Global_Emission
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Evento che viene eseguito quando si carica la finestra
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details; // Imposta la vista della ListView
        }

        // Evento Click del bottone per visualizzare il CSV
        private void btnVisualizzaCsv_Click(object sender, EventArgs e)
        {
            CaricaDaCsv(); // Carica e visualizza il CSV
        }

        // Metodo che carica i dati dal file CSV
        private void CaricaDaCsv()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Methane_final.csv");

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"Il file {filePath} non esiste. Assicurati che sia nel percorso corretto.");
                    return;
                }

                listView1.Items.Clear(); // Pulisce gli elementi esistenti
                listView1.Columns.Clear(); // Pulisce le colonne esistenti

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;

                    // Leggi la prima riga per impostare le intestazioni
                    if ((line = sr.ReadLine()) != null)
                    {
                        // Aggiungi le colonne direttamente dalla prima riga
                        string[] colonne = line.Split(',');
                        foreach (string col in colonne)
                        {
                            listView1.Columns.Add(col.Trim(), 150); // Aggiungi colonne dalla prima riga
                        }
                    }

                    // Leggi le righe successive e aggiungi i dati
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] campo = line.Split(',');

                        // Verifica se il numero di campi è corretto
                        if (campo.Length != listView1.Columns.Count)
                        {
                            MessageBox.Show("Riga ignorata: non contiene il numero corretto di campi."); // Messaggio di debug
                            continue; // Ignora la riga se non ha il numero corretto di campi
                        }

                        // Crea un nuovo ListViewItem
                        ListViewItem item = new ListViewItem(campo[0].Trim()); // Campo 0: "number"
                        for (int i = 1; i < campo.Length; i++)
                        {
                            item.SubItems.Add(campo[i].Trim()); // Aggiungi le altre colonne
                        }

                        // Aggiungi l'elemento alla ListView
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la lettura del file: {ex.Message}"); // Mostra l'eccezione
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
                string selectedNumber = selectedItem.SubItems[0].Text; // Campo "number"
                string selectedCountry = selectedItem.SubItems[1].Text;
                string selectedEmissions = selectedItem.SubItems[2].Text;
                string selectedType = selectedItem.SubItems[3].Text;
                string selectedSegment = selectedItem.SubItems[4].Text;
                string selectedReason = selectedItem.SubItems[5].Text;

                MessageBox.Show($"Hai selezionato: {selectedNumber}, {selectedCountry}, {selectedEmissions}, {selectedType}, {selectedSegment}, {selectedReason}");
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
