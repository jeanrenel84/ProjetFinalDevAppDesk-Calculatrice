using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjetCalculatriceUA1
{

    public partial class MainWindow : Window
    {
        // Ceci est le dernier chiffre que l'on tappe dans la calculatrice
        // exemple : 5+3 -----> 3 ici est la valeur actuelle
        private string valeurActuelle = "";

        // Ceci est la valeur a l'écran.
        // Aussi utiliser pour gérer Pi et e
        private string valeurAffichage = ""; 

        //symbole d'operation "+, -, x, / ect...s"
        private string operation = "";

        //trigonometrie comme sin, cos, tan, ect...
        private string fonctionTrigonometrie = "";

        private double resultat = 0;

        // Pour garder trace du calcul complet
        private string historique = ""; 

        // CONSTRUCTEUR

        public MainWindow()
        {
            InitializeComponent();

            // Initialisation de l'affichage
            Resultat.Text = "0";
            Calcul.Text = "";
        }

        // ═══════════════════════════════════════════════════════════
        // GESTION DES NOMBRES (0-9)
        // ═══════════════════════════════════════════════════════════


        private void Nombre_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            valeurActuelle += button.Content.ToString();

            // Pour les nombres, affichage = valeur
            valeurAffichage = valeurActuelle; 

            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
            {
                Calcul.Text = fonctionTrigonometrie + "(" + valeurAffichage + ")";
            }
            else if (!string.IsNullOrEmpty(historique))
            {
                // Si on a un historique, on construit : historique + operation + valeurAffichage
                Calcul.Text = historique + " " + operation + " " + valeurAffichage;
            }
            else if (!string.IsNullOrEmpty(operation))
            {
                // Mode opération en cours
                Calcul.Text = resultat.ToString("G10") + " " + operation + " " + valeurAffichage;
            }
            else
            {
                // Mode saisie simple
                Calcul.Text = valeurAffichage;
            }
        }

        // ═══════════════════════════════════════════════════════════
        // GESTION DES CONSTANTES (π, e)
        // ═══════════════════════════════════════════════════════════


        private void Constante_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "pi":
                    // Symbole pour l'affichage
                    valeurAffichage = "π";
                    // Valeur qui sera convertie en nombre
                    valeurActuelle = "π" ;
                    //Calcul.Text = 3.14.ToString();
                    break;

                case "exponentielle":
                    // Symbole pour l'affichage
                    valeurAffichage = "e";
                    // Valeur qui sera convertie en nombre
                    valeurActuelle = "e";  
                    break;
            }

            // On ajoute le SYMBOLE au calcul en haut
            if (!string.IsNullOrEmpty(historique))
            {
                Calcul.Text = historique + " " + operation + " " + valeurAffichage;
            }
            else if (!string.IsNullOrEmpty(operation))
            {
                Calcul.Text = resultat.ToString("G10") + " " + operation + " " + valeurAffichage;
            }
            else
            {
                Calcul.Text = valeurAffichage;
            }
        }

        private double ObtenirValeurNumerique(string valeur)
        {
            if (valeur == "π") return Math.PI;
            if (valeur == "e") return Math.E;

            if (double.TryParse(valeur, out double resultat))
                return resultat;

            return 0;
        }

        // GESTION DES FONCTIONS TRIGONOMÉTRIQUES

        private void Trigonometrie_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            // Stocker la fonction sélectionnée
            fonctionTrigonometrie = button.Content.ToString();
            valeurActuelle = "";

            // Afficher la fonction avec parenthèse ouverte
            Calcul.Text = fonctionTrigonometrie + "(";
        }


        // GESTION DE LA VIRGULE


        private void Virgule_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier qu'il n'y a pas déjà un point
            if (!valeurActuelle.Contains("."))
            {
                // Si valeur vide, commencer par "0."
                if (string.IsNullOrEmpty(valeurActuelle))
                    valeurActuelle = "0";

                valeurActuelle += ".";
                valeurAffichage = valeurActuelle;
            }

            MiseAJour();
        }


        // GESTION DES OPÉRATIONS (+, -, ×, ÷)

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            // Si une opération était déjà en cours, calculer d'abord
            if (!string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(valeurActuelle))
            {
                Egal_Click(null, null);
            }
            else if (string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(valeurActuelle))
            {
                // Premier nombre : on le stocke dans resultat
                resultat = ObtenirValeurNumerique(valeurActuelle);
            }
            // Si on clique sur une opération après un "=", utiliser le résultat précédent
            else if (string.IsNullOrEmpty(valeurActuelle) && !string.IsNullOrEmpty(historique))
            {
                // Le résultat est déjà stocké, on continue
            }

            // Stocker l'opération
            operation = button.Content.ToString();

            // Si on a un historique (après un =), on le continue
            if (!string.IsNullOrEmpty(historique))
            {
                Calcul.Text = historique + " " + operation;
            }
            else
            {
                // Sinon affichage avec le symbole si c'est π ou e
                historique = valeurAffichage != "" ? valeurAffichage : resultat.ToString("G10");
                Calcul.Text = historique + " " + operation;
            }

            valeurActuelle = "";
            valeurAffichage = "";
        }


        // CALCUL DU RÉSULTAT (=)

        private void Egal_Click(object sender, RoutedEventArgs e)
        {
            // CAS 1 : FONCTION TRIGONOMÉTRIQUE
            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
            {
                double valeur = ObtenirValeurNumerique(valeurActuelle);

                if (valeur == 0 && valeurActuelle != "0")
                {
                    // Valeur invalide
                    return; 
                }

                // Conversion degrés → radians pour Sin, Cos, Tan
                double angle = valeur * Math.PI / 180;

                switch (fonctionTrigonometrie)
                {
                    case "Sin":
                        resultat = Math.Round(Math.Sin(angle), 10);
                        break;
                    case "Cos":
                        resultat = Math.Round(Math.Cos(angle), 10);
                        break;
                    case "Tan":
                        resultat = Math.Round(Math.Tan(angle), 10);
                        break;
                    case "Arcsin":
                        if (valeur < -1 || valeur > 1)
                        {
                            Resultat.Text = "Valeur doit être entre 1 et -1";
                            return;
                        }
                        resultat = Math.Round(Math.Asin(valeur) * 180 / Math.PI, 10);
                        break;
                    case "Arccos":
                        if (valeur < -1 || valeur > 1)
                        {
                            Resultat.Text = "Valeur doit être entre 1 et -1";
                            return;
                        }
                        resultat = Math.Round(Math.Acos(valeur) * 180 / Math.PI, 10);
                        break;
                    case "Arctan":
                        resultat = Math.Round(Math.Atan(valeur) * 180 / Math.PI, 10);
                        break;
                }

                // Afficher le résultat (max 10 décimales significatives)
                Resultat.Text = resultat.ToString("G10");
                Calcul.Text = fonctionTrigonometrie + "(" + valeurActuelle + ")";

                // Préparer pour un nouveau calcul
                historique = Calcul.Text;
                valeurActuelle = resultat.ToString("G10");
                fonctionTrigonometrie = "";
                return;
            }
            if (string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(valeurActuelle))
            {
                resultat = ObtenirValeurNumerique(valeurActuelle);
                string resultatText = resultat.ToString("G10");

                Resultat.Text = resultatText;
                return;
            }

            // CAS 2 : OPÉRATION STANDARD (+, -, ×, ÷)
            if (!string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(valeurActuelle))
            {
                double valeurOp = ObtenirValeurNumerique(valeurActuelle);

                // Sauvegarder l'opération complète avec le SYMBOLE
                string operationComplete = (string.IsNullOrEmpty(historique) ? valeurAffichage : historique)
                                          + " " + operation + " " + valeurAffichage;

                switch (operation)
                {
                    case "+":
                        resultat += valeurOp;
                        break;
                    case "-":
                        resultat -= valeurOp;
                        break;
                    case "×":
                        resultat *= valeurOp;
                        break;
                    case "÷":
                        if (valeurOp == 0)
                        {
                            Resultat.Text = "Erreur : division par zéro";
                            Clear_Click(null, null);
                            return;
                        }
                        resultat /= valeurOp;
                        break;
                }

                // Arrondir pour éviter les erreurs de précision
                resultat = Math.Round(resultat, 10);

                // Afficher le résultat dans Resultat
                Resultat.Text = resultat.ToString("G10");

                // GARDER l'opération dans Calcul
                Calcul.Text = operationComplete;

                // Sauvegarder l'historique pour la suite
                historique = operationComplete;

                valeurActuelle = "";
                valeurAffichage = "";
                operation = "";
            }
        }


        // CHANGEMENT DE SIGNE (+/-)

        private void PlusOuMoins_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(valeurActuelle) || valeurActuelle == "0")
                return;

            if (double.TryParse(valeurActuelle, out double valeur))
            {
                // Inverser le signe
                valeurActuelle = (-valeur).ToString();
                valeurAffichage = valeurActuelle;
                MiseAJour();
            }
        }


        // EFFACEMENT

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(valeurActuelle))
                return;

            if (valeurActuelle.Length > 1)
            {
                // Supprimer le dernier caractère
                valeurActuelle = valeurActuelle.Substring(0, valeurActuelle.Length - 1);
                valeurAffichage = valeurActuelle;
            }
            else
            {
                // Si un seul caractère, revenir à vide
                valeurActuelle = "";
                valeurAffichage = "";
            }

            MiseAJour();
        }

        // C (Clear) : Efface tout et réinitialise la calculatrice

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            valeurActuelle = "";
            valeurAffichage = "";
            operation = "";
            resultat = 0;
            fonctionTrigonometrie = "";
            historique = "";

            Calcul.Text = "";
            Resultat.Text = "0";
        }


        // CE (Clear Entry) : Efface seulement la valeur actuelle

        private void ClearE_Click(object sender, RoutedEventArgs e)
        {
            valeurActuelle = "";
            valeurAffichage = "";

            // Mettre à jour l'affichage selon le contexte
            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
            {
                Calcul.Text = fonctionTrigonometrie + "(";
                Resultat.Text = "0";
            }
            else if (!string.IsNullOrEmpty(operation))
            {
                // Si on est en train de saisir une opération
                if (!string.IsNullOrEmpty(historique))
                {
                    Calcul.Text = historique + " " + operation;
                }
                else
                {
                    Calcul.Text = $"{resultat} {operation}";
                }
                Resultat.Text = "0";
            }
            else if (!string.IsNullOrEmpty(historique))
            {
                // Si on a déjà un résultat calculé, on le garde
                Calcul.Text = historique;
                Resultat.Text = resultat.ToString("G10");
            }
            else
            {
                Calcul.Text = "";
                Resultat.Text = "0";
            }
        }


        // MISE À JOUR DE L'AFFICHAGE

        private void MiseAJour()
        {
            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
            {
                // Mode fonction 
                Calcul.Text = fonctionTrigonometrie + "(" + valeurAffichage + ")";
            }
            else if (!string.IsNullOrEmpty(historique))
            {
                // Mode continuation après un =
                if (!string.IsNullOrEmpty(operation))
                {
                    Calcul.Text = historique + " " + operation + " " + valeurAffichage;
                }
                else
                {
                    Calcul.Text = valeurAffichage;
                    // On recommence un nouveau calcul
                    historique = ""; 
                }
            }
            else if (!string.IsNullOrEmpty(operation))
            {
                // Mode opération 
                Calcul.Text = $"{resultat} {operation} {valeurAffichage}";
            }
            else
            {
                // Mode saisie simple
                Calcul.Text = valeurAffichage;
            }
        }
    }
}