using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open_Data_Global_Emission
{

    public partial class Form1 : Form
    {
        private List<EmissionData> emissionList; // Lista che conterrà i dati caricati dal CSV.
        private const double SogliaEmissioni = 128.42; // Soglia aggiornata dinamicamente.

        public Form1()
        {
            InitializeComponent();
            emissionList = new List<EmissionData>();
            listView1.ItemActivate += ListView_ItemActivate;
            listView1.FullRowSelect = true;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            InitializeCustomStyles();
            
        }
        private void InitializeCustomStyles()
        {
            // Imposta lo stile generale del form
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Pulsanti principali nella parte superiore
            StilePulsante(btnVisualizzaCsv, "Visualizza CSV", Color.FromArgb(63, 81, 181), new Point(20, 20));
            StilePulsante(button1, "Ordina Crescente", Color.FromArgb(76, 175, 80), new Point(200, 20));
            StilePulsante(button2, "Ordina Decrescente", Color.FromArgb(244, 67, 54), new Point(380, 20));
            StilePulsante(BtnResetFiltri, "Reset Filtri", Color.FromArgb(220, 220, 220), new Point(560, 20), Color.Black);

            // ComboBox accanto ai pulsanti
            comboBox1.BackColor = Color.White;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Location = new Point(740, 25);
            comboBox1.Size = new Size(150, 30);

            // Etichette per i campi di filtro sotto i pulsanti principali
            Label lblRegionFilter = new Label
            {
                Text = "Filtro Regione:",
                Location = new Point(20, 70),
                AutoSize = true
            };
            this.Controls.Add(lblRegionFilter);

            Label lblCountryFilter = new Label
            {
                Text = "Filtro Paese:",
                Location = new Point(240, 70),
                AutoSize = true
            };
            this.Controls.Add(lblCountryFilter);

            Label lblYearFilter = new Label
            {
                Text = "Filtro Anno:",
                Location = new Point(460, 70),
                AutoSize = true
            };
            this.Controls.Add(lblYearFilter);

            Label lblSoglia = new Label
            {
                Text = "Soglia Emissioni:",
                Location = new Point(680, 70),
                AutoSize = true
            };
            this.Controls.Add(lblSoglia);

            // TextBox per i filtri
            txtRegionFilter.BorderStyle = BorderStyle.FixedSingle;
            txtRegionFilter.Location = new Point(20, 100);
            txtRegionFilter.Size = new Size(200, 30);

            txtCountryFilter.BorderStyle = BorderStyle.FixedSingle;
            txtCountryFilter.Location = new Point(240, 100);
            txtCountryFilter.Size = new Size(200, 30);

            txtYearFilter.BorderStyle = BorderStyle.FixedSingle;
            txtYearFilter.Location = new Point(460, 100);
            txtYearFilter.Size = new Size(200, 30);

            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(680, 100);
            textBox1.Size = new Size(160, 30);

            // Bottoni di filtro sotto le TextBox
            StilePulsante(BtnFilterRegion, "Filtra", Color.Blue, new Point(20, 140));
            StilePulsante(BtnFilterCountry, "Filtra", Color.Blue, new Point(240, 140));
            StilePulsante(BtnFilterYear, "Filtra", Color.Blue, new Point(460, 140));
            StilePulsante(BtnAlert, "Soglia", Color.Blue, new Point(680, 140));

            // Abbassa la ListView per lasciare spazio ai filtri
            listView1.View = View.Details;
            listView1.BackColor = Color.White;
            listView1.ForeColor = Color.Black;
            listView1.BorderStyle = BorderStyle.None;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(20, 190); // Abbassa la ListView per lasciare spazio ai filtri
            listView1.Size = new Size(880, 300);
            this.Controls.Add(listView1);
        }

        // Metodo per applicare lo stile e la posizione ai pulsanti esistenti
        private void StilePulsante(Button button, string text, Color backColor, Point location, Color? foreColor = null)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backColor;
            button.ForeColor = foreColor ?? Color.White;
            button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button.Text = text;
            button.Size = new Size(140, 40);
            button.Location = location;
            button.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(button);
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

                // Popola la ComboBox con le opzioni di emissione specifiche
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "Agriculture", "Energy", "Other", "Waste" });

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
            listView1.View = View.Details;

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
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtRegionFilter_TextChanged(object sender, EventArgs e)
        {
            // Metodo vuoto collegato al campo filtro "Regione".
        }

        // Metodo che gestisce l'applicazione dei filtri e visualizza i dati filtrati.
        private void FiltraEOrdinaDati(bool ordineCrescente = true)
        {
            if (emissionList == null || emissionList.Count == 0)
            {
                MessageBox.Show("Per favore, carica prima il file CSV.");
                return;
            }

            // Prende i valori dai text box e dalla ComboBox per ogni filtro
            string regioneDaFiltrare = txtRegionFilter.Text.Trim();
            string countryDaFiltrare = txtCountryFilter.Text.Trim();
            string yearDaFiltrare = txtYearFilter.Text.Trim();
            string typeDaFiltrare = comboBox1.SelectedItem?.ToString();

            // Verifica che l'input nella textBox1 sia un valore numerico valido per la soglia
            double sogliaUtente = 0;
            bool sogliaValida = double.TryParse(textBox1.Text, out sogliaUtente);

            // Filtra la lista emissionList in base ai valori inseriti dall'utente
            var datiFiltrati = emissionList.Where(emission =>
                (string.IsNullOrEmpty(regioneDaFiltrare) || emission.Region.Equals(regioneDaFiltrare, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(countryDaFiltrare) || emission.Country.Equals(countryDaFiltrare, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(yearDaFiltrare) || emission.BaseYear.Contains(yearDaFiltrare)) &&
                (string.IsNullOrEmpty(typeDaFiltrare) || emission.Type.Equals(typeDaFiltrare, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            
            // Ordina i dati filtrati
            if (ordineCrescente)
            {
                datiFiltrati = datiFiltrati.OrderBy(x => double.Parse(x.Emissions.Trim(), System.Globalization.CultureInfo.InvariantCulture)).ToList();
            }
            else
            {
                datiFiltrati = datiFiltrati.OrderByDescending(x => double.Parse(x.Emissions.Trim(), System.Globalization.CultureInfo.InvariantCulture)).ToList();
            }

            // Visualizza i dati filtrati e ordinati nella ListView
            VisualizzaDatiFiltratiConSoglia(datiFiltrati, sogliaUtente, sogliaValida);
        }


        private void BtnFilterRegion_Click(object sender, EventArgs e)
        {
            FiltraEOrdinaDati(); // Applica i filtri e ordina in ordine crescente (predefinito)
        }

        private void BtnFilterCountry_Click(object sender, EventArgs e)
        {
            FiltraEOrdinaDati(); // Applica i filtri e ordina in ordine crescente (predefinito)
        }

        private void BtnFilterYear_Click(object sender, EventArgs e)
        {
            FiltraEOrdinaDati(); // Applica i filtri e ordina in ordine crescente (predefinito)
        }

        private void txtCountryFilter_TextChanged(object sender, EventArgs e)
        {
            // Metodo vuoto per il filtro del paese.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FiltraEOrdinaDati(false); // Ordina in ordine decrescente
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FiltraEOrdinaDati(true); // Ordina in ordine crescente
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
        private void BtnAlert_Click(object sender, EventArgs e)
        {
            // Verifica che l'input nella textBox1 sia un valore numerico valido
            if (double.TryParse(textBox1.Text, out double sogliaUtente))
            {
                FiltraEOrdinaDati(); // Applica tutti i filtri inclusa la soglia
            }
            else
            {
                MessageBox.Show("Inserisci un valore numerico valido per la soglia.");
            }
            textBox1.Text = "";
        }

        // Metodo che carica la ListView e applica la colorazione in base alla soglia
        private void VisualizzaDatiFiltratiConSoglia(List<EmissionData> datiFiltrati, double soglia, bool sogliaValida)
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

                // Applica la colorazione solo se la soglia è valida e maggiore di 0.
                if (sogliaValida && soglia > 0)
                {
                    // Prova a parse il valore delle emissioni dalla stringa.
                    if (double.TryParse(emission.Emissions.Replace(",", ".").Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double emissionValue))
                    {

                        // Applica i colori in base al valore delle emissioni rispetto alla soglia
                        if (emissionValue < soglia * 0.8) // Sotto l'80% della soglia
                        {
                            item.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else if (emissionValue >= soglia * 0.8 && emissionValue < soglia)
                        {
                            item.BackColor = System.Drawing.Color.Yellow;
                        }
                        else if (emissionValue >= soglia)
                        {
                            item.BackColor = System.Drawing.Color.LightCoral;
                        }
                    }
                    else
                    {
                        // Se il valore delle emissioni non è valido, non applicare colorazione
                        item.BackColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    // Se la soglia non è valida o non applicabile, nessuna colorazione viene applicata.
                    item.BackColor = System.Drawing.Color.White;
                }

                listView1.Items.Add(item); // Aggiunge l'elemento alla ListView.
            }

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // Auto-adeguamento delle colonne al contenuto.
            }
        }


        private void BtnResetFiltri_Click(object sender, EventArgs e)
        {
            // Resetta tutti i filtri di input.
            txtRegionFilter.Text = "";  // Reset del filtro per regione.
            txtCountryFilter.Text = "";  // Reset del filtro per paese.
            txtYearFilter.Text = "";  // Reset del filtro per anno.
            textBox1.Text = "";  // Reset del filtro della soglia.

            // Ricarica la ListView con tutti i dati non filtrati.
            CaricaNellaListView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltraEOrdinaDati(); // Applica il filtro ogni volta che cambia la selezione
        }
    }
}

