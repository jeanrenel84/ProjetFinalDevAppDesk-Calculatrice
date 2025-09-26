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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
}