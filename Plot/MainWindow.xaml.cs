using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
        private PlotManager plotManager;
        public MainWindow()
        {
            InitializeComponent();
            plotManager = new PlotManager();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            plt.Reset();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                plotManager.Calculate(textBox1.Text, plt);
            }
        }
    }
}
