using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// calcul d'un formule en notation polonaise
        /// </summary>
        /// <param name="formule">formule</param>
        /// <returns></returns>
        static Double Polonaise(String formule)
        {
            try
            {
                // coonversion formule en vecteur
                string[] vec = formule.Split(' ');

                // nombre de cases remplies
                int nbCases = vec.Length;

                while (nbCases > 1)
                {
                    // recherche d'un signe à partir de la fin
                    int k = nbCases - 1;

                    while (k > 0 && vec[k] != "+" && vec[k] != "-" && vec[k] != "*" && vec[k] != "/")
                    {
                        k--;
                    }

                    // récupératiçon des 2 valeurs
                    float v1 = float.Parse(vec[k + 1]);
                    float v2 = float.Parse(vec[k + 2]);

                    // calcul
                    float result = 0;
                    switch (vec[k])
                    {
                        case "+":
                            result = v1 + v2;
                            break;
                        case "-":
                            result = v1 - v2;
                            break;
                        case "*":
                            result = v1 * v2;
                            break;
                        case "/":
                            // éviter la division par 0
                            if (v2==0)
                            {
                                return Double.NaN;
                            }
                            result = v1 / v2;
                            break;
                    }

                    // stockage resultat
                    vec[k] = result.ToString();

                    // décalage de 2 cases
                    for (int j = k + 1; j < nbCases - 2; j++)
                    {
                        vec[j] = vec[j + 2];
                    }

                    // les cases suivantes sont mises à blanc
                    for (int j=nbCases-2;j < nbCases; j++)
                    {
                        vec[j] = " ";
                    }

                    nbCases -= 2;
                }
                return Double.Parse(vec[0]);
            }
            catch
            {
                return Double.NaN;
            }
        }
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
