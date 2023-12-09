using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace CheckPath
{
    internal class UrlAnalyzer
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };
        public static async Task<List<string>> AnalyzeUrl(string url, List<string> words, ListBox listeVulBox, Label chargementLabel, Label routeLabel)
        {
            var vulnerabilities = new List<string>();
            int taille = words.Count;
            listeVulBox.Items.Clear();


            if (!IsValidUrl(url))
            {
                MessageBox.Show("URL invalide. Réessayez s'il vous plait", "Attention");
                return null;
            }
            // Effectuer une requête vers le site racine
            try
            {
                using (var rootResponse = await httpClient.GetAsync(url))
                {
                    if (!rootResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"La requête vers le site racine {url} a échoué. le site n'éxiste pas .", "Attention");
                        return vulnerabilities;
                    }
                    if ((int)rootResponse.StatusCode >= 300 && (int)rootResponse.StatusCode < 400)
                    {
                      
                        var redirectLocation = rootResponse.Headers.Location?.AbsoluteUri;

                        if (!string.IsNullOrEmpty(redirectLocation))
                        {
                     
                            using (var redirectedResponse = await httpClient.GetAsync(redirectLocation))
                            {
                                if (redirectedResponse.IsSuccessStatusCode)
                                {
                                    MessageBox.Show($"Redirection vers : {redirectLocation}", "Redirection réussie");
                                }
                                else
                                {
                                    MessageBox.Show($"La requête vers l'emplacement de redirection {redirectLocation} a échoué. Aucune vulnérabilité trouvée.", "Attention");
                                    return vulnerabilities;
                                }
                            }
                        }
                    }
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Erreur lors de la requête vers le site racine : {e.Message}", "Erreur");
                return vulnerabilities;
            }

            url = url[url.Length - 1].Equals('/') ? url : url + '/';

            for (int i = 0; i < taille; i++)
            {
                chargementLabel.Text = calculProgress(i, taille).ToString() + " %";
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
            string message = vulnerabilities.Count.ToString() + " vulnérabilités trouvées. \nVous pouvez générer un rapport";
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
