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
                        // Aggiungi le colonne dalla prima riga del CSV
                        string[] colonne = line.Split(','); // Assicurati che il delimitatore sia corretto
                        foreach (string col in colonne)
                        {
                            listView1.Columns.Add(col.Trim(), 150); // Imposta una larghezza iniziale di 150
                        }
                    }

                    // Leggi le righe successive e aggiungi i dati
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] campo = line.Split(','); // Assicurati che il delimitatore sia corretto

                        // Assicurati che ci siano abbastanza campi
                        if (campo.Length != listView1.Columns.Count)
                        {
                            MessageBox.Show("Riga ignorata: non contiene il numero corretto di campi."); // Messaggio di debug
                            continue; // Ignora la riga se non ha il numero corretto di campi
                        }

                        // Crea un nuovo ListViewItem e aggiungi tutti i campi
                        ListViewItem item = new ListViewItem(campo[0].Trim()); // Campo 0: "number"
                        for (int i = 1; i < campo.Length; i++)
                        {
                            item.SubItems.Add(campo[i].Trim()); // Aggiungi le altre colonne come SubItems
                        }

                        // Aggiungi l'elemento alla ListView
                        listView1.Items.Add(item);
                    }
                }

                // Imposta la larghezza delle colonne in base al contenuto
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.Width = -2; // -2 significa "adatta automaticamente alla larghezza del contenuto"
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
                string selectedRegion = selectedItem.SubItems[1].Text;
                string selectedCountry = selectedItem.SubItems[2].Text;
                string selectedEmissions = selectedItem.SubItems[3].Text;
                string selectedType = selectedItem.SubItems[4].Text;
                string selectedSegment = selectedItem.SubItems[5].Text;
                string selectedReason = selectedItem.SubItems[6].Text;
                string selectedBaseYear = selectedItem.SubItems[7].Text;

                MessageBox.Show($"Hai selezionato: {selectedNumber}, {selectedRegion}, {selectedCountry}, {selectedEmissions}, {selectedType}, {selectedSegment}, {selectedReason}, {selectedBaseYear}");
            }
        }
    }
}
