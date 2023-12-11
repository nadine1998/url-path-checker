using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;
using System.Runtime.CompilerServices;

namespace CheckPath
{
    internal class UrlAnalyzerUtils
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };


        public static async Task<ListVulnerability> AnalyzeUrl(string url, List<string> words, ListBox listeVulBox, Label chargementLabel, Label routeLabel)
        {
            ListVulnerability listvulnerabilities = new ListVulnerability();
            int taille = words.Count;
            listeVulBox.Items.Clear();

            try
            {
                using HttpResponseMessage rootResponse = await httpClient.GetAsync(url);
                if (rootResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("La requête vers le site racine " + url + " a échoué. le site n'éxiste pas .", "Attention");
                    return listvulnerabilities;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpRequestException e = ex;
                MessageBox.Show("Vérifiez votre connexion internet ! ", "Erreur");
                return listvulnerabilities;
            }

            url = (url[url.Length - 1].Equals('/') ? url : (url + "/"));

            if (!IsValidUrl(url))
            {
                MessageBox.Show("URL invalide. Réessayez s'il vous plaît", "Attention");
                return listvulnerabilities;
            }

            for (int i = 0; i < taille; i++)
            {
                chargementLabel.Text = calculProgress(i, taille) + " %";

                try
                {
                    string testUrl = (routeLabel.Text = url + words[i]);
                    using HttpResponseMessage response = await httpClient.GetAsync(testUrl);

                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        Vulnerability vulnerability = new Vulnerability();
                        vulnerability.Route = testUrl;
                        vulnerability.StatusCode = (int)response.StatusCode;
                        listvulnerabilities.addVulnerability(vulnerability);
                        listeVulBox.Items.Add(testUrl);
                    }
                }
                catch (HttpRequestException)
                {
                    // route introuvable  
                }
                catch (Exception)
                {
                    // exception globale
                }
            }

            string message = listvulnerabilities.Taille() + " vulnérabilités trouvées. \nVous pouvez générer un rapport";
            MessageBox.Show(message, "Analyse terminée");
            return listvulnerabilities;
        }


        public static bool IsValidUrl(string url)
        {
            string pattern = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";
            return Regex.IsMatch(url, pattern);
        }

        public static double calculProgress(int index, int taille)
        {
            return (index + 1) * 100 / taille;
        }
    }
}
