using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace InvoerBeveiliging.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

 
        private void BtnNogEenScherm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        /*
        public static void MarkeerTextBox(TextBox beveiligdeTextBox, bool inputCorrect)
        {
            if (inputCorrect)
            {
                beveiligdeTextBox.BorderThickness = new Thickness(1);
                beveiligdeTextBox.BorderBrush = Brushes.Gray;
                beveiligdeTextBox.Background = Brushes.White;
            }
            else
            {
                beveiligdeTextBox.BorderThickness = new Thickness(3);
                beveiligdeTextBox.BorderBrush = Brushes.Red;
                beveiligdeTextBox.Background = Brushes.LightPink;
            }
        }
 
         */
    }
}
