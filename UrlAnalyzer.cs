using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;

namespace CheckPath
{
    internal class UrlAnalyzer
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };


        public static async Task<List<Vulnerability>> AnalyzeUrl(string url, List<string> words, ListBox listeVulBox, Label chargementLabel, Label routeLabel)
        {
            List<Vulnerability> vulnerabilities = new List<Vulnerability>();
            int taille = words.Count;
            listeVulBox.Items.Clear();

            try
            {
                using HttpResponseMessage rootResponse = await httpClient.GetAsync(url);
                if (rootResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    
                    MessageBox.Show("La requête vers le site racine " + url + " a échoué. le site n'éxiste pas .", "Attention");
                    return vulnerabilities;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpRequestException e = ex;
                MessageBox.Show("Erreur lors de la requête vers le site racine : " + e.Message, "Erreur");
                return vulnerabilities;
            }

            url = (url[url.Length - 1].Equals('/') ? url : (url + "/"));

            if (!IsValidUrl(url))
            {
                MessageBox.Show("URL invalide. Réessayez s'il vous plaît", "Attention");
                return vulnerabilities;
            }

            for (int i = 0; i < taille; i++)
            {
                chargementLabel.Text = calculProgress(i, taille) + " %";

                try
                {
                    string testUrl = (routeLabel.Text = url + words[i]);
                    using HttpResponseMessage response = await httpClient.GetAsync(testUrl);

                    if ( response.StatusCode != HttpStatusCode.NotFound)
                    {
                        Vulnerability vulnerability = new Vulnerability
                        {
                            Route = testUrl,
                            StatusCode = (int)response.StatusCode
                        };

                        vulnerabilities.Add(vulnerability);
                        listeVulBox.Items.Add(testUrl);
                    }
                }
                catch (HttpRequestException)
                {
                    
                }
                catch (Exception)
                {
                    
                }
            }

            string message = vulnerabilities.Count + " vulnérabilités trouvées. \nVous pouvez générer un rapport";
            MessageBox.Show(message, "Analyse terminée");
            return vulnerabilities;
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
