using ScottPlot;
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

namespace Plot
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

        private void btm1_Click(object sender, RoutedEventArgs e)
        {
            btm1.Visibility = Visibility.Hidden;
            btm2.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Visible;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string text = textBox1.Text;
                double y = double.Parse(text);
                var func1 = new Func<double, double?>((x) => Math.Sin(y * x));
                plt.Plot.AddFunction(func1, lineWidth: 5);
                plt.Refresh();
            }
        }
        private void btm2_Click(object sender, RoutedEventArgs e)
        {
            btm1.Visibility = Visibility.Hidden;
            btm2.Visibility = Visibility.Hidden;
            textBox2.Visibility = Visibility.Visible;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string text = textBox2.Text;
                double y = double.Parse(text);
                var func1 = new Func<double, double?>((x) => Math.Cos(y * x));
                plt.Plot.AddFunction(func1, lineWidth: 5);
                plt.Refresh();
            }
        }
    }
}
