using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace CheckPath
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10) // Set a reasonable timeout
        };

        private string filePath = "";
        private List<string> vulnerabilitiesList = new List<string>();
        private bool analyzeFinished = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadCsvButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
        }

        private async void analyzeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                var words = ReadCsvFile(filePath);
                vulnerabilitiesList = await AnalyzeUrl(this.urlTextBox.Text, words);
                // Implement logic to display vulnerabilities or further process them
            }
            else
                MessageBox.Show("Chargez la wordlist s'il vous plait !", "ERROR");
        }

        private List<string> ReadCsvFile(string filePath)
        {
            var words = new List<string>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    words.AddRange(fields);
                }
            }
            return words;
        }

        public async Task<List<string>> AnalyzeUrl(string url, List<string> words)
        {
            this.analyzeFinished = false;
            var vulnerabilities = new List<string>();
            int taille = words.Count;
            this.listeVulBox.Items.Clear();
            url = url[url.Length - 1].Equals('/') ? url : url + '/';

            if (IsValidUrl(url) == false)
            {
                MessageBox.Show("URL invalide. Réessayez s'il vous plait", "Attention");
                return null;
            }

            for (int i = 0; i < taille; i++)
            {
                this.chargementLabel.Text = calculProgress(i, taille).ToString() + " %";
                try
                {
                    string testUrl = $"{url}{words[i]}";
                    routeLabel.Text = testUrl;
                    using (var response = await httpClient.GetAsync(testUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            vulnerabilities.Add($"Route trouvée: {testUrl}");
                            listeVulBox.Items.Add(testUrl);
                            // MessageBox.Show(testUrl, vulnerabilities.Count.ToString());
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    //vulnerabilities.Add($"HTTP request error: {e.Message}");
                }
                catch (Exception e)
                {
                    //vulnerabilities.Add($"General error: {e.Message}");
                }
            }
            this.analyzeFinished = true;
            string message = vulnerabilities.Count.ToString() + " vulnérabilités trouvées. \nVous pouvez générer un rapport";
            MessageBox.Show(message, "Analyse terminée");
            return vulnerabilities;
        }

        public static void GenerateTextRepor1(string outputFilePath, List<string> vulnerabilities)
        {
            // Créez un fichier texte et écrivez le contenu
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Rapport de Vulnérabilités\n");

                if (vulnerabilities.Count > 0)
                {
                    writer.WriteLine("Liste des Vulnérabilités :\n");
                    foreach (var vulnerability in vulnerabilities)
                    {
                        writer.WriteLine("- " + vulnerability);
                    }
                }
                else
                {
                    writer.WriteLine("Aucune vulnérabilité n'a été trouvée.");
                }

                MessageBox.Show("Le rapport texte a été généré avec succés : " + outputFilePath, "Opération terminée");
            }
        }

        private void rapportButton_Click(object sender, EventArgs e)
        {
            if (analyzeFinished)
            {
                // Combinez le chemin du bureau avec le nom du fichier
                SaveFileDialog rapportFile = new SaveFileDialog();
                rapportFile.Filter = "TXT Files|*.txt";
                rapportFile.Title = "Sauvegarder le rapport";
                if(rapportFile.ShowDialog() == DialogResult.OK)
                    GenerateTextRepor1(rapportFile.FileName, vulnerabilitiesList);
            }
            else
            {
                MessageBox.Show("Rapport pas encore disponible !", "Attention");
            }

        }

        public double calculProgress(int index, int taille)
        {

            return (index + 1) * 100 / taille;
        }


        public bool IsValidUrl(string url)
        {
            string pattern = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";
            return Regex.IsMatch(url, pattern);
        }

        private void chargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadCsvButton_Click(sender, e);
        }

        private void analyserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            analyzeButton_Click(sender, e);
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
