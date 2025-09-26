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

                Resultat.Text = "0";
            }
        }
    }

