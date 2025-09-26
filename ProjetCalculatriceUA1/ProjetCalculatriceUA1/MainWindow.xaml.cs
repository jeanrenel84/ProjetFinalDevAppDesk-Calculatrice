using System.Numerics;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetCalculatriceUA1
{

    public partial class MainWindow : Window
    {
        private string valeuractuelle = "";
        private string operation = "";
        private string fonctionTrigonometrie = "";
        private double resultat = 0;




        public MainWindow()
        {
            InitializeComponent();

            Resultat.Text = "0";
            Calcul.Text = "";
        }


        private void Nombre_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            valeuractuelle += button.Content.ToString();

            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
                Calcul.Text = fonctionTrigonometrie + "(" + valeuractuelle + ")";
            else if (!string.IsNullOrEmpty(operation))
                Calcul.Text = $"{resultat} {operation} {valeuractuelle}";
            else
                Calcul.Text = valeuractuelle;

            Resultat.Text = "0";
        }

        private void Constante_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "pi": valeuractuelle = Math.PI.ToString(); break;
                case "exponentielle": valeuractuelle = Math.E.ToString(); break;
            }

            MiseAJour();
        }

        private void Trigonometrie_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            fonctionTrigonometrie = button.Content.ToString();
            valeuractuelle = "";
            Calcul.Text = fonctionTrigonometrie + "(";
            Resultat.Text = "0";
        }

        private void Virgule_Click(object sender, RoutedEventArgs e)
        {
            if (!valeuractuelle.Contains("."))
                valeuractuelle += ".";
            MiseAJour();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            resultat = double.Parse(valeuractuelle);
            valeuractuelle = "";
            Calcul.Text = $"{resultat} {operation}";
            Resultat.Text = "0";
        }

        private void Egal_Click(object sender, RoutedEventArgs? e)
        {
            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
            {
                double angle = double.Parse(valeuractuelle) * Math.PI / 180;
                switch (fonctionTrigonometrie)
                {
                    case "Sin": resultat = Math.Sin(angle); break;
                    case "Cos": resultat = Math.Cos(angle); break;
                    case "Tan": resultat = Math.Tan(angle); break;
                    case "Arcsin": resultat = Math.Asin(double.Parse(valeuractuelle)) * 180 / Math.PI; break;
                    case "Arccos": resultat = Math.Acos(double.Parse(valeuractuelle)) * 180 / Math.PI; break;
                    case "Arctan": resultat = Math.Atan(double.Parse(valeuractuelle)) * 180 / Math.PI; break;
                }

                Resultat.Text = resultat.ToString();
                Calcul.Text = fonctionTrigonometrie + "(" + valeuractuelle + ")";
                valeuractuelle = resultat.ToString();
                fonctionTrigonometrie = "";
                return;
            }

            if (double.TryParse(valeuractuelle, out double valeur))
            {
                switch (operation)
                {
                    case "+": resultat += valeur; break;
                    case "-": resultat -= valeur; break;
                    case "×": resultat *= valeur; break;
                    case "÷":
                        if (valeur != 0)
                            resultat /= valeur;
                        else
                        {
                            Resultat.Text = "Erreur : division par zéro";
                            return;
                        }
                        break;
                }

                valeuractuelle = resultat.ToString();
                operation = "";
                Calcul.Text = "";
                Resultat.Text = resultat.ToString();
            }
        }

        private void PlusOuMoins_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(valeuractuelle, out double valeur))
                valeuractuelle = (-valeur).ToString();
            MiseAJour();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (valeuractuelle.Length > 1)
                valeuractuelle = valeuractuelle.Substring(0, valeuractuelle.Length - 1);
            else
                valeuractuelle = "0";

            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
                Calcul.Text = fonctionTrigonometrie + "(" + valeuractuelle + ")";
            else
                Calcul.Text = valeuractuelle;

            Resultat.Text = "0";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            valeuractuelle = "";
            operation = "";
            resultat = 0;
            fonctionTrigonometrie = "";
            Calcul.Text = "";
            Resultat.Text = "0";
        }

        private void ClearE_Click(object sender, RoutedEventArgs e)
        {
            valeuractuelle = "";

            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
                Calcul.Text = fonctionTrigonometrie + "(" + valeuractuelle + ")";
            else if (!string.IsNullOrEmpty(operation))
                Calcul.Text = $"{resultat} {operation}";
            else
                Calcul.Text = "";

            Resultat.Text = "0";
        }


        private void MiseAJour()
        {
            if (!string.IsNullOrEmpty(fonctionTrigonometrie))
                Calcul.Text = fonctionTrigonometrie + "(" + valeuractuelle + ")";
            else if (!string.IsNullOrEmpty(operation))
                Calcul.Text = $"{resultat} {operation} {valeuractuelle}";
            else
                Calcul.Text = valeuractuelle;

            Resultat.Text = "0"; } 
            
=======
            //gestionResultatLimit();
            calcul.Text = "0";
            zero.Click += GererSymboles;
            un.Click += GererSymboles;
            deux.Click += GererSymboles;
            trois.Click += GererSymboles;
            quatre.Click += GererSymboles;
            cinq.Click += GererSymboles;
            six.Click += GererSymboles;
            sept.Click += GererSymboles;
            huit.Click += GererSymboles;
            neuf.Click += GererSymboles;
            pi.Click += GererSymboles;
            exponentielle.Click += GererSymboles;
            plus.Click += GererOperateurs;
            multiplication.Click += GererOperateurs;
            soustraction.Click += GererOperateurs;
            division.Click += GererOperateurs;
            back.Click += EffacerOperande;
            effacerResultat.Click += EffacerDernierChiffreOperande;

        }

        // je voulais limiter le nombre de charactere saisi dans l'operande a 16
       /* void gestionResultatLimit()
        {
            int maxChar = 16;
            if (resultat.Text.Length>maxChar) { 
                resultat.Text=resultat.Text.Substring(0,maxChar);
            }
        }*/

        

        //Methode pour la gestion des symboles
        public void GererSymboles(object sender, RoutedEventArgs e ) {
            Button symboles = sender as Button;
            string contenu= symboles.Content.ToString();
            switch (contenu) {
                    case "0":
                    if (resultat.Text != "")
                        resultat.Text += "0";
                    break;
                    case "1":
                    if (resultat.Text != "")
                        resultat.Text += "1";
                    else
                        resultat.Text = "1";
                    break;
                    case "2":
                    if (resultat.Text != "")
                        resultat.Text += "2";
                    else
                        resultat.Text = "2";
                    break;
                    case "3":
                    if (resultat.Text != "")
                        resultat.Text += "3";
                    else
                        resultat.Text = "3";
                    break;
                    case "4":
                    if (resultat.Text != "")
                        resultat.Text += "4";
                    else
                        resultat.Text = "4";
                    break;
                    case "5":
                    if (resultat.Text != "")
                        resultat.Text += "5";
                    else
                        resultat.Text = "5";
                    break;
                    case "6":
                    if (resultat.Text != "")
                        resultat.Text += "6";
                    else
                        resultat.Text = "6";
                    break;
                    case "7":
                    if (resultat.Text != "")
                        resultat.Text += "7";
                    else
                        resultat.Text = "7";
                    break;
                    case "8":
                    if (resultat.Text != "")
                        resultat.Text += "8";
                    else
                        resultat.Text = "8";
                    break;
                    case "9":
                    if (resultat.Text != "")
                        resultat.Text += "9";
                    else
                        resultat.Text = "9";
                    break;

                    case "π":
                    if (resultat.Text != "")
                        resultat.Text += "π";
                    else
                        resultat.Text = "π";
                        calcul.Text = Math.PI.ToString();
                    break;
                    case "e":
                    if (resultat.Text != "")
                        resultat.Text += "e";
                    else
                        resultat.Text = "e";
                       calcul.Text = Math.E.ToString();

                    break;
            }

        }


        //Methode pour la gestion des operateurs
        public void GererOperateurs(object sender, RoutedEventArgs e)
        {
            Button symboles = sender as Button;
            string contenu = symboles.Content.ToString();
            char extract;
            switch (contenu)
            {
                case "÷":
                     extract = resultat.Text[resultat.Text.Length - 1];
                    if (resultat.Text != "" && extract!='÷')
                    {
                        resultat.Text += "÷";
                    }
                break;
                case "×":
                    extract = resultat.Text[resultat.Text.Length - 1];
                    if (resultat.Text != "" && extract != '×')
                    {
                        resultat.Text += "×";
                        
                    }
                break;
                case "+":
                    extract = resultat.Text[resultat.Text.Length - 1];
                    if (resultat.Text != "" && extract != '+')
                    {
                        resultat.Text += "+";
                    }
                break;

                case "-":
                    extract = resultat.Text[resultat.Text.Length - 1];
                    if (resultat.Text != "" && extract != '-')
                    {
                        resultat.Text += "-";
                    }
                break;
            }

        }

        //Fonction pour la gestion du back

        public void EffacerOperande(object sender, RoutedEventArgs e)
        {
            Button symboles = sender as Button;
            string contenu = symboles.Content.ToString();
            if (contenu == "Back")
            {

                if (resultat.Text!= "")
                {
                    resultat.Text = resultat.Text.Substring(0, resultat.Text.Length - 1);
                }
                else
                {
                    calcul.Text = "0";
                }

            }
        }

        // fonction qui efface le dernier chiffre/nombre affiche dans operande
        public void EffacerDernierChiffreOperande(object sender, RoutedEventArgs e)
        {
            Button symboles = sender as Button;
            string contenu = symboles.Content.ToString();
            int indexOperateur;
            char[] tabOperateur = { '+', '-', '×', '÷' };
            
            if (contenu == "CE" && !string.IsNullOrEmpty(resultat.Text))
            {
                indexOperateur = resultat.Text.LastIndexOfAny(tabOperateur);

                if (indexOperateur != -1)
                {

                    resultat.Text = resultat.Text.Substring(0, indexOperateur + 1);
                }
                else 
                    resultat.Text = "";              

            }
        }

        // Fonction qui gere les operations.



        private void effacerTout_Click(object sender, RoutedEventArgs e)
        {
            resultat.Text= "";
            calcul.Text = "0";
        }

        private void plusOuMoins_Click(object sender, RoutedEventArgs e)
        {
            if (resultat.Text == "")
                resultat.Text = "";            
            if (resultat.Text.Contains("-") )
                resultat.Text = resultat.Text;
            else if (resultat.Text != "0" && resultat.Text != "")
                resultat.Text = "-" + resultat.Text;

        }
    }

