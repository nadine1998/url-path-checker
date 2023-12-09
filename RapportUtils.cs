using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPath
{
    internal class RapportUtils
    {
        public static void GenerateTextRepor1(string outputFilePath, List<string> vulnerabilities)
        {

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
    }
}
