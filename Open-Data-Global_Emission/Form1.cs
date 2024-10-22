using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open_Data_Global_Emission
{
    public partial class Form1 : Form
    {
        private List<EmissionData> emissionList; // Lista che conterrà i dati caricati dal CSV.
        private const double SogliaEmissioni = 100000; // Definisce una soglia d'allerta per le emissioni (ad esempio 100000).

        public Form1()
        {
            InitializeComponent(); // Inizializza i componenti della finestra.
            emissionList = new List<EmissionData>(); // Inizializza la lista delle emissioni vuota.
            listView1.ItemActivate += ListView_ItemActivate; // Aggiunge un handler per l'evento di selezione di un item nella ListView.
            listView1.FullRowSelect = true; // Configura la ListView per selezionare intere righe.

            // Aggiunge i tipi di energia alla ComboBox.
            comboBoxEnergyType.Items.AddRange(new string[] { "Agriculture", "Energy" });
            comboBoxEnergyType.SelectedIndex = 0; // Seleziona il primo elemento della ComboBox di default.

            // Collega l'evento di cambio selezione della ComboBox al metodo corrispondente.
            comboBoxEnergyType.SelectedIndexChanged += comboBoxEnergyType_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Metodo vuoto eseguito al caricamento del form.
        }

        private void btnVisualizzaCsv_Click(object sender, EventArgs e)
        {
            CaricaDaCsv(); // Chiama il metodo per caricare il CSV.
            CaricaNellaListView(); // Carica i dati nella ListView dopo averli caricati dalla lista.
        }

        private async void CaricaDaCsv()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Methane_final.csv"); // Ottieni il percorso del file CSV.

            try
            {
                if (!File.Exists(filePath)) // Controlla se il file esiste.
                {
                    MessageBox.Show($"Il file {filePath} non esiste. Assicurati che sia nel percorso corretto.");
                    return;
                }

                emissionList.Clear(); // Pulisce la lista delle emissioni prima di caricare nuovi dati.

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false; // Salta la prima riga che contiene gli header.
                            continue;
                        }

                        string[] campo = line.Split(','); // Divide la riga in colonne.

                        // Controlla se la riga ha esattamente 8 colonne.
                        if (campo.Length != 8)
                        {
                            continue; // Salta le righe con un numero di colonne errato.
                        }

                        // Aggiunge i dati alla lista emissionList.
                        emissionList.Add(new EmissionData
                        {
                            Number = campo[0].Trim(),
                            Region = campo[1].Trim(),
                            Country = campo[2].Trim(),
                            Emissions = campo[3].Trim(),
                            Type = campo[4].Trim(),
                            Segment = campo[5].Trim(),
                            Reason = campo[6].Trim(),
                            BaseYear = campo[7].Trim()
                        });
                    }
                }

                CaricaNellaListView(); // Carica i dati appena letti nella ListView.

                MessageBox.Show("Dati caricati correttamente."); // Notifica all'utente che i dati sono stati caricati.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la lettura del file: {ex.Message}");
            }
        }

        private void CaricaNellaListView()
        {
            listView1.View = View.Details; // Configura la ListView per mostrare i dettagli.

            listView1.Items.Clear(); // Pulisce gli elementi esistenti nella ListView.
            listView1.Columns.Clear(); // Pulisce le colonne esistenti nella ListView.

            // Aggiunge le colonne con titoli specifici alla ListView.
            listView1.Columns.Add("number", 100);
            listView1.Columns.Add("region", 100);
            listView1.Columns.Add("country", 100);
            listView1.Columns.Add("emissions", 100);
            listView1.Columns.Add("type", 100);
            listView1.Columns.Add("segment", 100);
            listView1.Columns.Add("reason", 100);
            listView1.Columns.Add("baseYear", 100);

            // Verifica il numero di colonne aggiunte (debug).
            Console.WriteLine($"Numero di colonne: {listView1.Columns.Count}");

            // Aggiunge i dati della lista emissionList alla ListView.
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

                listView1.Items.Add(item); // Aggiunge l'elemento alla ListView.
            }

            // Imposta la larghezza delle colonne in base al contenuto.
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // Auto-adeguamento delle colonne al contenuto.
            }
        }

        // Metodo vuoto che gestisce la selezione di un elemento nella ListView (potenzialmente per estendere funzionalità).
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtRegionFilter_TextChanged(object sender, EventArgs e)
        {
            // Metodo vuoto collegato al campo filtro "Regione".
        }

        // Funzione per visualizzare i dati filtrati nella ListView.
        private void VisualizzaDatiFiltrati(List<EmissionData> datiFiltrati)
        {
            listView1.Items.Clear(); // Pulisce gli elementi esistenti nella ListView.

            foreach (var emission in datiFiltrati)
            {
                // Aggiunge i dati filtrati nella ListView.
                ListViewItem item = new ListViewItem(emission.Number);
                item.SubItems.Add(emission.Region);
                item.SubItems.Add(emission.Country);
                item.SubItems.Add(emission.Emissions);
                item.SubItems.Add(emission.Type);
                item.SubItems.Add(emission.Segment);
                item.SubItems.Add(emission.Reason);
                item.SubItems.Add(emission.BaseYear);

                listView1.Items.Add(item); // Aggiunge l'elemento alla ListView.
            }
        }

        // Metodo che gestisce l'applicazione dei filtri e visualizza i dati filtrati.
        private void FiltraEVisualizzaDati()
        {
            if (emissionList == null || emissionList.Count == 0) // Controlla se la lista emissionList è vuota.
            {
                MessageBox.Show("Per favore, carica prima il file CSV.");
                return;
            }

            // Prende i valori dai text box e dalla ComboBox per ogni filtro.
            string regioneDaFiltrare = txtRegionFilter.Text.Trim();
            string countryDaFiltrare = txtCountryFilter.Text.Trim();
            string yearDaFiltrare = txtYearFilter.Text.Trim();
            string tipoEnergiaDaFiltrare = comboBoxEnergyType.SelectedItem?.ToString().Trim();

            // Filtra la lista emissionList in base ai valori inseriti dall'utente.
            var datiFiltrati = emissionList.Where(emission =>
                (string.IsNullOrEmpty(regioneDaFiltrare) || emission.Region.Equals(regioneDaFiltrare, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(countryDaFiltrare) || emission.Country.Equals(countryDaFiltrare, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(yearDaFiltrare) || emission.BaseYear.Contains(yearDaFiltrare)) &&
                (string.IsNullOrEmpty(tipoEnergiaDaFiltrare) || emission.Type.Equals(tipoEnergiaDaFiltrare, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            // Visualizza i dati filtrati nella ListView.
            VisualizzaDatiFiltrati(datiFiltrati);
        }

        // Gestione dei filtri per regione, paese, anno tramite pulsanti.
        private void BtnFilterRegion_Click(object sender, EventArgs e)
        {
            FiltraEVisualizzaDati(); // Applica tutti i filtri insieme.
        }

        private void BtnFilterCountry_Click(object sender, EventArgs e)
        {
            FiltraEVisualizzaDati(); // Applica tutti i filtri insieme.
        }

        private void BtnFilterYear_Click(object sender, EventArgs e)
        {
            FiltraEVisualizzaDati(); // Applica tutti i filtri insieme.
        }

        private void txtCountryFilter_TextChanged(object sender, EventArgs e)
        {
            // Metodo vuoto per il filtro del paese.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdinaPerEmissioni(true); // Ordina la lista emissionList in ordine crescente in base alle emissioni.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrdinaPerEmissioni(false); // Ordina la lista emissionList in ordine decrescente in base alle emissioni.
        }

        private void OrdinaPerEmissioni(bool ordineCrescente)
        {
            // Controlla se emissionList contiene dati prima di applicare l'ordinamento.
            if (emissionList == null || emissionList.Count == 0)
            {
                MessageBox.Show("Per favore, carica prima il file CSV.");
                return;
            }

            // Prova a ordinare la lista emissionList basandosi sulla colonna Emissions.
            if (ordineCrescente)
            {
                // Ordina in ordine crescente le emissioni.
                emissionList.Sort((x, y) => x.Emissions.CompareTo(y.Emissions));
            }
            else
            {
                // Ordina in ordine decrescente le emissioni.
                emissionList.Sort((x, y) => y.Emissions.CompareTo(x.Emissions));
            }

            // Pulisce la ListView prima di caricare i dati ordinati.
            listView1.Items.Clear();

            // Aggiunge i dati ordinati alla ListView.
            for (int i = 0; i < emissionList.Count; i++)
            {
                ListViewItem item = new ListViewItem(emissionList[i].Number);
                item.SubItems.Add(emissionList[i].Region);
                item.SubItems.Add(emissionList[i].Country);
                item.SubItems.Add(emissionList[i].Emissions);
                item.SubItems.Add(emissionList[i].Type);
                item.SubItems.Add(emissionList[i].Segment);
                item.SubItems.Add(emissionList[i].Reason);
                item.SubItems.Add(emissionList[i].BaseYear);

                listView1.Items.Add(item); // Aggiunge l'elemento ordinato alla ListView.
            }
        }

        private void BtnCalcolaStatistiche_Click(object sender, EventArgs e)
        {
            try
            {
                // Calcola la somma totale delle emissioni.
                double sommaEmissioni = emissionList.Sum(emission => double.Parse(emission.Emissions));

                // Calcola la media delle emissioni.
                double mediaEmissioni = emissionList.Average(emission => double.Parse(emission.Emissions));

                // Mostra le statistiche (somma e media) all'utente tramite un messaggio.
                MessageBox.Show($"Somma totale delle emissioni: {sommaEmissioni}\nMedia delle emissioni: {mediaEmissioni}");
            }
            catch (FormatException ex)
            {
                // Mostra un errore nel caso in cui i dati delle emissioni non siano nel formato corretto.
                MessageBox.Show($"Errore nel calcolo delle statistiche: Formato numerico non valido. {ex.Message}");
            }
            catch (Exception ex)
            {
                // Mostra un errore generico per qualsiasi altro tipo di eccezione.
                MessageBox.Show($"Errore nel calcolo delle statistiche: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Metodo vuoto per la gestione di un clic su una label.
        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            // Filtra le regioni che hanno emissioni superiori alla soglia definita (SogliaEmissioni).
            var regioniAllerta = emissionList.Where(emission =>
                double.TryParse(emission.Emissions, out double emissionValue) && emissionValue > SogliaEmissioni).ToList();

            if (regioniAllerta.Count == 0)
            {
                // Se nessuna regione supera la soglia, notifica l'utente.
                MessageBox.Show($"Nessuna regione ha superato la soglia di {SogliaEmissioni}.");
            }
            else
            {
                // Se ci sono regioni che superano la soglia, visualizza i dati filtrati nella ListView.
                VisualizzaDatiFiltrati(regioniAllerta);
            }
        }

        private void ListView_ItemActivate(object sender, EventArgs e)
        {
            // Verifica se c'è un elemento selezionato nella ListView.
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                string driverName = selectedItem.SubItems[1].Text;

                // Costruisce l'URL per la pagina Wikipedia della regione selezionata.
                string wikipediaUrl = $"https://en.wikipedia.org/wiki/{driverName.Replace(" ", "_")}";

                // Usa Process.Start per aprire il link nel browser predefinito.
                Process.Start(new ProcessStartInfo
                {
                    FileName = wikipediaUrl,
                    UseShellExecute = true // Necessario per aprire l'URL nel browser predefinito.
                });
            }
        }

        // Classe che rappresenta i dati sulle emissioni con tutte le proprietà (es. Number, Region, Country).
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

        // Gestisce il cambio di selezione della ComboBox per il tipo di energia.
        private void comboBoxEnergyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ottieni il tipo di energia selezionato dalla ComboBox.
            string tipoEnergiaSelezionato = comboBoxEnergyType.SelectedItem?.ToString().Trim().ToLower();

            // Filtra la lista emissionList in base al tipo di energia selezionato.
            var datiFiltrati = emissionList.Where(emission =>
                emission.Type.Equals(tipoEnergiaSelezionato)).ToList();

            // Visualizza i dati filtrati nella ListView.
            VisualizzaDatiFiltrati(datiFiltrati);
        }
    }
}

