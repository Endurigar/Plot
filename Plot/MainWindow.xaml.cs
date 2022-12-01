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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            plt.Reset();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string text = textBox1.Text;
                string sin ="sin";
                string cos ="cos";
                //Simple plots
                if (text.Contains(sin) && !text.Contains('-') && !text.Contains('+') && !text.Contains('*') && !text.Contains('/'))
                {
                    double y = Finder.Сoefficient(text);
                    var func1 = new Func<double, double?>((x) => Math.Sin(y*x));
                    plt.Plot.AddFunction(func1, lineWidth: 5);
                    plt.Refresh();
                }
                if (text.Contains(cos) && !text.Contains('-') && !text.Contains('+') && !text.Contains('*') && !text.Contains('/'))
                {
                    double y = Finder.Сoefficient(text);
                    var func1 = new Func<double, double?>((x) => Math.Cos(y * x));
                    plt.Plot.AddFunction(func1, lineWidth: 5);
                    plt.Refresh();
                }
                //Plots with '-' & '+'
                if (text.Contains('-'))
                {
                    int Index = text.IndexOf('-');
                    string firstPart = text.Substring(0, Index - 1);
                    string secondPart = text.Substring(Index+1);
                    double firstPartCoff = Finder.Сoefficient(firstPart);
                    double secondPartCoff = Finder.Сoefficient(secondPart);
                    if (firstPart.Contains(sin) && !secondPart.Contains(sin))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) - Math.Cos(secondPartCoff*x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    else if(firstPart.Contains(sin) && secondPart.Contains(sin))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) - Math.Sin(secondPartCoff*x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    if(firstPart.Contains(cos)&&!secondPart.Contains(cos))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) - Math.Sin(secondPartCoff*x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    else if(firstPart.Contains(cos)&&secondPart.Contains(cos))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) - Math.Cos(secondPartCoff*x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                }
                if (text.Contains('+'))
                {
                    int Index = text.IndexOf('+');
                    string firstPart = text.Substring(0, Index - 1);
                    string secondPart = text.Substring(Index + 1);
                    double firstPartCoff = Finder.Сoefficient(firstPart);
                    double secondPartCoff = Finder.Сoefficient(secondPart);
                    if (firstPart.Contains(sin) && !secondPart.Contains(sin))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) + Math.Cos(secondPartCoff*x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    else if (firstPart.Contains(sin) && secondPart.Contains(sin))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) + Math.Sin(secondPartCoff*x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    else if (firstPart.Contains(cos) && secondPart.Contains(cos))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) + Math.Cos(secondPartCoff*x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                }
                //Plots '*' & '/'
                if (text.Contains('*'))
                {
                    int Index = text.IndexOf('*');
                    string firstPart = text.Substring(0, Index - 1);
                    string secondPart = text.Substring(Index + 1);
                    double firstPartCoff = Finder.Сoefficient(firstPart);
                    double secondPartCoff = Finder.Сoefficient(secondPart);
                    if (firstPart.Contains(sin) && !secondPart.Contains(sin))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) * Math.Cos(secondPartCoff * x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    else if (firstPart.Contains(sin) && secondPart.Contains(sin))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) * Math.Sin(secondPartCoff * x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    else if (firstPart.Contains(cos) && secondPart.Contains(cos))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) * Math.Cos(secondPartCoff * x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                }
                if (text.Contains('/'))
                {
                    int Index = text.IndexOf('/');
                    string firstPart = text.Substring(0, Index - 1);
                    string secondPart = text.Substring(Index + 1);
                    double firstPartCoff = Finder.Сoefficient(firstPart);
                    double secondPartCoff = Finder.Сoefficient(secondPart);
                    if (firstPart.Contains(sin) && !secondPart.Contains(sin))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) / Math.Cos(secondPartCoff * x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    else if (firstPart.Contains(sin) && secondPart.Contains(sin))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) / Math.Sin(secondPartCoff * x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    if (firstPart.Contains(cos) && !secondPart.Contains(cos))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) / Math.Sin(secondPartCoff * x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                    else if (firstPart.Contains(cos) && secondPart.Contains(cos))
                    {
                        var func1 = new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) / Math.Cos(secondPartCoff * x));
                        plt.Plot.AddFunction(func1, lineWidth: 5);
                        plt.Refresh();
                    }
                }
            }
        }
    }
}
