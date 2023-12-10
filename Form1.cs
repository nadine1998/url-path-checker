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
            Timeout = TimeSpan.FromSeconds(10) 
        };

        private string filePath = "";
        private List<Vulnerability> vulnerabilitiesList = new List<Vulnerability>();
        private bool analyzeFinished = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void loadCsvButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
        }

        private async void analyzeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                //var words = ReadCsvFile(filePath);
                analyzeFinished = false;
                var words = WordlistUtils.ReadWordListFile(filePath);
                vulnerabilitiesList = await UrlAnalyzer.AnalyzeUrl(this.urlTextBox.Text, words, this.listeVulBox, this.chargementLabel, this.routeLabel);
                analyzeFinished = true;
            }
            else
                MessageBox.Show("Chargez la wordlist s'il vous plait !", "Attention");
        }


        private void rapportButton_Click(object sender, EventArgs e)
        {
            if (this.analyzeFinished)
            {
                SaveFileDialog rapportFile = new SaveFileDialog();
                rapportFile.Filter = "TXT Files|*.txt";
                rapportFile.Title = "Sauvegarder le rapport";
                if(rapportFile.ShowDialog() == DialogResult.OK)
                    RapportUtils.GenerateTextRepor1(rapportFile.FileName, vulnerabilitiesList);
            }
            else
            {
                MessageBox.Show("Rapport pas encore disponible !", "Attention");
            }

        }

    }
}
