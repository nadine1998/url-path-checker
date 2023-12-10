using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPath
{
    internal class RapportUtils
    {
        public static void GenerateTextRepor1(string outputFilePath, List<Vulnerability> vulnerabilities)
        {

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("**Rapport de Vulnérabilités** \n");

                if (vulnerabilities.Count > 0)
                {
                    
                    writer.WriteLine("** Nombre de routes potentiellement vulnérables ** : " + vulnerabilities.Count.ToString() +"\n");
                    writer.WriteLine("** Liste des routes potentiellement vulnérables ** :  \n");
                    foreach (var vulnerability in vulnerabilities)
                    {
                        writer.WriteLine("\t ** Route trouvée **: " + vulnerability.Route + " ** Code retourné **: " + vulnerability.StatusCode);
                    }
                }
                else
                {
                    writer.WriteLine("**Aucune vulnérabilité n'a été trouvée.**");
                }
                MessageBox.Show("Le rapport texte a été généré avec succès : " + outputFilePath, "Opération terminée");
            }
        }
    }
}
