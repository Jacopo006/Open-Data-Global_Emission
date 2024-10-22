﻿using System;
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
        private List<EmissionData> emissionList;
        private const double SogliaEmissioni = 100000; // Imposta una soglia d'allerta (valore esempio)

        public Form1()
        {
            InitializeComponent();
            emissionList = new List<EmissionData>();
            listView1.ItemActivate += ListView_ItemActivate;
            listView1.FullRowSelect = true;

            // Aggiungi i tipi di energia alla ComboBox basati sui dati effettivi del CSV
            comboBoxEnergyType.Items.AddRange(new string[] { "Agriculture", "Energy" });
            comboBoxEnergyType.SelectedIndex = 0; // Seleziona il primo tipo di energia per default

            // Collegare l'evento SelectedIndexChanged alla ComboBox
            comboBoxEnergyType.SelectedIndexChanged += comboBoxEnergyType_SelectedIndexChanged;
        }

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
                    MessageBox.Show($"Il file {filePath} non esiste. Assicurati che sia nel percorso corretto.");
                    return;
                }

                emissionList.Clear(); // Pulisce l'elenco emissionList prima di caricare nuovi dati

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false; // Salta la prima riga (header)
                            continue;
                        }

                        string[] campo = line.Split(',');

                        // Verifica se ci sono esattamente 8 colonne
                        if (campo.Length != 8)
                        {
                            continue; // Salta righe con numero di colonne errato
                        }


                        // Aggiunge i dati alla lista emissionList
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

                CaricaNellaListView(); // Mostra i dati caricati nella ListView

                MessageBox.Show("Dati caricati correttamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la lettura del file: {ex.Message}");
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
            
        }
        private void txtRegionFilter_TextChanged(object sender, EventArgs e)
        {

        }

        // Funzione per visualizzare i dati filtrati
        // Metodo esistente per visualizzare i dati filtrati
        private void VisualizzaDatiFiltrati(List<EmissionData> datiFiltrati)
        {
            listView1.Items.Clear();

            foreach (var emission in datiFiltrati)
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

        }
        private void FiltraEVisualizzaDati()
        {
            if (emissionList == null || emissionList.Count == 0)
            {
                MessageBox.Show("Per favore, carica prima il file CSV.");
                return;
            }

            // Prendi i valori dai text box e dalla ComboBox per ogni filtro
            string regioneDaFiltrare = txtRegionFilter.Text.Trim();
            string countryDaFiltrare = txtCountryFilter.Text.Trim();
            string yearDaFiltrare = txtYearFilter.Text.Trim();
            string tipoEnergiaDaFiltrare = comboBoxEnergyType.SelectedItem?.ToString().Trim();

            // Filtra la lista emissionList in base ai campi inseriti
            var datiFiltrati = emissionList.Where(emission =>
                (string.IsNullOrEmpty(regioneDaFiltrare) || emission.Region.Equals(regioneDaFiltrare, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(countryDaFiltrare) || emission.Country.Equals(countryDaFiltrare, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(yearDaFiltrare) || emission.BaseYear.Contains(yearDaFiltrare)) &&
                (string.IsNullOrEmpty(tipoEnergiaDaFiltrare) || emission.Type.Equals(tipoEnergiaDaFiltrare, StringComparison.OrdinalIgnoreCase)) // Filtro sul tipo di energia
            ).ToList();

            // Visualizza i dati filtrati nella ListView
            VisualizzaDatiFiltrati(datiFiltrati);
        }


        private void BtnFilterRegion_Click(object sender, EventArgs e)
        {
            FiltraEVisualizzaDati(); // Applica tutti i filtri insieme
        }

        private void BtnFilterCountry_Click(object sender, EventArgs e)
        {
            FiltraEVisualizzaDati(); // Applica tutti i filtri insieme
        }

        private void BtnFilterYear_Click(object sender, EventArgs e)
        {
            FiltraEVisualizzaDati(); // Applica tutti i filtri insieme
        }

        private void txtCountryFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdinaPerEmissioni(true); // Ordine crescente
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrdinaPerEmissioni(false); // Ordine decrescente
        }

        private void OrdinaPerEmissioni(bool ordineCrescente)
        {

            // Prova a ordinare la lista basandosi sulla colonna Emissions
            if (ordineCrescente)
            {
                // Ordine crescente
                emissionList.Sort((x, y) => x.Emissions.CompareTo(y.Emissions));
            }
            else
            {
                // Ordine decrescente
                emissionList.Sort((x, y) => y.Emissions.CompareTo(x.Emissions));
            }

            // Pulisce la ListView
            listView1.Items.Clear();

            // Mostra i dati ordinati nella ListView
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

                listView1.Items.Add(item);
            }
        }

        private void BtnCalcolaStatistiche_Click(object sender, EventArgs e)
        {
            try
            {
                // Calcola la somma totale e la media delle emissioni
                double sommaEmissioni = emissionList.Sum(emission => double.Parse(emission.Emissions));
                double mediaEmissioni = emissionList.Average(emission => double.Parse(emission.Emissions));

                // Mostra le statistiche
                MessageBox.Show($"Somma totale delle emissioni: {sommaEmissioni}\nMedia delle emissioni: {mediaEmissioni}");
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Errore nel calcolo delle statistiche: Formato numerico non valido. {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nel calcolo delle statistiche: {ex.Message}");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void BtnAlert_Click(object sender, EventArgs e)
        {

            // Filtra le regioni che hanno emissioni superiori alla soglia
            var regioniAllerta = emissionList.Where(emission =>
                double.TryParse(emission.Emissions, out double emissionValue) && emissionValue > SogliaEmissioni).ToList();

            if (regioniAllerta.Count == 0)
            {
                MessageBox.Show($"Nessuna regione ha superato la soglia di {SogliaEmissioni}.");
            }
            else
            {
                // Mostra i risultati nella ListView
                VisualizzaDatiFiltrati(regioniAllerta);
            }
        }

        private void ListView_ItemActivate(object sender, EventArgs e)
        {
            // Verifica se c'è un elemento selezionato
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                string driverName = selectedItem.SubItems[1].Text;

                // Costruisci l'URL per la pagina Wikipedia del pilota
                string wikipediaUrl = $"https://en.wikipedia.org/wiki/{driverName.Replace(" ", "_")}";

                // Usa Process.Start per aprire il link nel browser predefinito
                Process.Start(new ProcessStartInfo
                {
                    FileName = wikipediaUrl,
                    UseShellExecute = true // Necessario per aprire l'URL nel browser predefinito
                });
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

        private void comboBoxEnergyType_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Ottieni il tipo di energia selezionato dalla ComboBox
            string tipoEnergiaSelezionato = comboBoxEnergyType.SelectedItem?.ToString().Trim().ToLower();

            // Filtra la lista emissionList in base al tipo di energia selezionato
            var datiFiltrati = emissionList.Where(emission =>
                emission.Type.Equals(tipoEnergiaSelezionato)).ToList();

            // Visualizza i dati filtrati nella ListView
            VisualizzaDatiFiltrati(datiFiltrati);

        }

    }
}
