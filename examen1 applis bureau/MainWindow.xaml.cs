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

using System;
using System.Windows;

namespace examen1_applis_bureau
{
    public partial class MainWindow : Window
    {
        private double _result;
        private string _operator;
        private bool _isNewEntry;





        public MainWindow()
        {
            InitializeComponent();
            _result = 0;
            _operator = string.Empty;
            _isNewEntry = false;
        }

        private void UpdateDisplay(string text)
        {
            if (_isNewEntry)
            {
                Resultat.Text = string.Empty; // Réinitialise le résultat
                _isNewEntry = false;
            }

            Calcul.Text += text; // Met à jour les calculs en cours
        }

        private void ce_Click(object sender, RoutedEventArgs e)
        {
            Calcul.Text = string.Empty; // Réinitialise les calculs
            Resultat.Text = string.Empty; // Réinitialise le résultat
            _result = 0;
            _operator = string.Empty;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (Calcul.Text.Length > 0)
            {
                Calcul.Text = Calcul.Text.Substring(0, Calcul.Text.Length - 1); // Supprime le dernier caractère
            }
        }

        private void Operator_Click(string operation)
        {
            if (double.TryParse(Calcul.Text, out double currentValue))
            {
                _result = currentValue;
                _operator = operation;
                _isNewEntry = true;
                Calcul.Text += $" {operation} "; // Met à jour les calculs
            }
        }

        private void egal_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Calcul.Text, out double currentValue))
            {
                switch (_operator)
                {
                    case "+":
                        _result += currentValue;
                        break;
                    case "-":
                        _result -= currentValue;
                        break;
                    case "*":
                        _result *= currentValue;
                        break;
                    case "/":
                        if (currentValue != 0)
                        {
                            _result /= currentValue;
                        }
                        else
                        {
                            MessageBox.Show("Erreur : Division par zéro !");
                            return;
                        }
                        break;
                        // Ajoutez d'autres opérations selon besoin
                }

                Resultat.Text = _result.ToString(); // Affiche le résultat
                _operator = string.Empty; // Réinitialiser l'opérateur
            }
        }

        // Gestionnaires d'événements pour les boutons
        private void sin_Click(string operation)
        {
            {
                if (double.TryParse(Calcul.Text, out double currentValue))
                {
                    _result = currentValue;
                    _operator = operation;
                    _isNewEntry = true;
                    Calcul.Text += $" {operation} "; // Met à jour les calculs
                }
            }
        }
        private void cos_Click(object sender, RoutedEventArgs e) => Operator_Click("cos");
        private void tan_Click(object sender, RoutedEventArgs e) => Operator_Click("tan");
        private void plus_Click(object sender, RoutedEventArgs e) => Operator_Click("+");
        private void soustraction_Click(object sender, RoutedEventArgs e) => Operator_Click("-");
        private void multiplication_Click(object sender, RoutedEventArgs e) => Operator_Click("*");
        private void division_Click(object sender, RoutedEventArgs e) => Operator_Click("/");
        private void un_Click(object sender, RoutedEventArgs e) => UpdateDisplay("1");
        private void deux_Click(object sender, RoutedEventArgs e) => UpdateDisplay("2");
        private void trois_Click(object sender, RoutedEventArgs e) => UpdateDisplay("3");
        private void quatre_Click(object sender, RoutedEventArgs e) => UpdateDisplay("4");
        private void cinq_Click(object sender, RoutedEventArgs e) => UpdateDisplay("5");
        private void six_Click(object sender, RoutedEventArgs e) => UpdateDisplay("6");
        private void sept_Click(object sender, RoutedEventArgs e) => UpdateDisplay("7");
        private void huit_Click(object sender, RoutedEventArgs e) => UpdateDisplay("8");
        private void neuf_Click(object sender, RoutedEventArgs e) => UpdateDisplay("9");
        private void zero_Click(object sender, RoutedEventArgs e) => UpdateDisplay("0");
        private void virgule_Click(object sender, RoutedEventArgs e) => UpdateDisplay(".");
        private void arcsin_Click(object sender, RoutedEventArgs e) => Operator_Click("arcsin");
        private void arccos_Click(object sender, RoutedEventArgs e) => Operator_Click("arccos");
        private void arctan_Click(object sender, RoutedEventArgs e) => Operator_Click("arctan");
        private void c_Click(object sender, RoutedEventArgs e) => Operator_Click("c");
        private void epsilon_Click(object sender, RoutedEventArgs e) => Operator_Click("arctan");
    }
}


