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

namespace KG3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        Calculation calc;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gridPainting.Children.Clear();
                calc = new Calculation(P1x.Text, P1y.Text, P1z.Text, p2x.Text, p2y.Text, p2z.Text, p3x.Text, p3y.Text, p3z.Text, p4x.Text, p4y.Text, p4z.Text);
                gridPainting.Children.Add(calc.PaintFigure());
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка входных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gridPainting.Children.Clear();
                if (calc != null)
                {
                    gridPainting.Children.Add(calc.RotateFigure(angle.Text, axis.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка входных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
