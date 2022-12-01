using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Plot
{
    internal class PlotManager
    {
        private const string SinString = "sin";
        private const string CosString = "cos";
        internal void Calculate(string value, WpfPlot plot)
        {
            var func = GetFunc(value, Finder.Сoefficient(value));
            if (func != null)
                AddFunction(func, plot);
            //Plots with '-' & '+'
            if (value.Contains('-'))
            {
                int index = value.IndexOf('-');
                var parts = GetParts(value, index);
                var funcTemp = GetFuncSub(parts.Item1, parts.Item2, value);
                if(funcTemp != null)
                    AddFunction(funcTemp, plot);
            }
            if (value.Contains('+'))
            {
                int index = value.IndexOf('+');
                var parts = GetParts(value, index);
                var funcTemp = GetFuncAdd(parts.Item1, parts.Item2, value);
                if (funcTemp != null)
                    AddFunction(funcTemp, plot);
            }
            if (value.Contains('*'))
            {
                int index = value.IndexOf('*');
                var parts = GetParts(value, index);
                var funcTemp = GetFuncMul(parts.Item1, parts.Item2, value);
                if (funcTemp != null)
                    AddFunction(funcTemp, plot);
            }
            if (value.Contains('/'))
            {
                int index = value.IndexOf('/');
                var parts = GetParts(value, index);
                var funcTemp = GetFuncDiv(parts.Item1, parts.Item2, value);
                if (funcTemp != null)
                    AddFunction(funcTemp, plot);
            }

        }
        private void AddFunction(Func<double, double?> func, WpfPlot plot)
        {
            plot.Plot.AddFunction(func, lineWidth: 5);
            plot.Refresh();
        }
        private Func<double, double?> GetFunc(string value, double coefficient)
        {

            if (value.Contains(SinString) && !value.Contains('-') && !value.Contains('+') && !value.Contains('*') && !value.Contains('/'))
                return new Func<double, double?>((x) => Math.Sin(coefficient * x));
            if (value.Contains(CosString) && !value.Contains('-') && !value.Contains('+') && !value.Contains('*') && !value.Contains('/'))
                return new Func<double, double?>((x) => Math.Cos(coefficient * x));
            return null;
        }
        private Func<double, double?> GetFuncSub(string firstPart, string secondPart, string value)
        {
            double firstPartCoff = Finder.Сoefficient(firstPart);
            double secondPartCoff = Finder.Сoefficient(secondPart);
            if (firstPart.Contains(SinString) && !secondPart.Contains(SinString))
                return new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) - Math.Cos(secondPartCoff * x));
            if (firstPart.Contains(SinString) && secondPart.Contains(SinString))
                return new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) - Math.Sin(secondPartCoff * x));
            if (firstPart.Contains(CosString) && !secondPart.Contains(CosString))
                return new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) - Math.Sin(secondPartCoff * x));
            if (firstPart.Contains(CosString) && secondPart.Contains(CosString))
                return new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) - Math.Cos(secondPartCoff * x));
            return null;
        }
        private Func<double, double?> GetFuncAdd(string firstPart, string secondPart, string value)
        {
            double firstPartCoff = Finder.Сoefficient(firstPart);
            double secondPartCoff = Finder.Сoefficient(secondPart);
            if (firstPart.Contains(SinString) && !secondPart.Contains(SinString))
                return new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) + Math.Cos(secondPartCoff * x));
            if (firstPart.Contains(SinString) && secondPart.Contains(SinString))
                return new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) + Math.Sin(secondPartCoff * x));
            if (firstPart.Contains(CosString) && !secondPart.Contains(CosString))
                return new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) + Math.Sin(secondPartCoff * x));
            if (firstPart.Contains(CosString) && secondPart.Contains(CosString))
                return new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) + Math.Cos(secondPartCoff * x));
            return null;
        }
        private Func<double, double?> GetFuncMul(string firstPart, string secondPart, string value)
        {
            double firstPartCoff = Finder.Сoefficient(firstPart);
            double secondPartCoff = Finder.Сoefficient(secondPart);
            if (firstPart.Contains(SinString) && !secondPart.Contains(SinString))
                return new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) * Math.Cos(secondPartCoff * x));
            if (firstPart.Contains(SinString) && secondPart.Contains(SinString))
                return new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) * Math.Sin(secondPartCoff * x));
            if (firstPart.Contains(CosString) && !secondPart.Contains(CosString))
                return new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) * Math.Sin(secondPartCoff * x));
            if (firstPart.Contains(CosString) && secondPart.Contains(CosString))
                return new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) * Math.Cos(secondPartCoff * x));
            return null;
        }
        private Func<double, double?> GetFuncDiv(string firstPart, string secondPart, string value)
        {
            double firstPartCoff = Finder.Сoefficient(firstPart);
            double secondPartCoff = Finder.Сoefficient(secondPart);
            if (firstPart.Contains(SinString) && !secondPart.Contains(SinString))
                return new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) / Math.Cos(secondPartCoff * x));
            if (firstPart.Contains(SinString) && secondPart.Contains(SinString))
                return new Func<double, double?>((x) => Math.Sin(firstPartCoff * x) / Math.Sin(secondPartCoff * x));
            if (firstPart.Contains(CosString) && !secondPart.Contains(CosString))
                return new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) / Math.Sin(secondPartCoff * x));
            if (firstPart.Contains(CosString) && secondPart.Contains(CosString))
                return new Func<double, double?>((x) => Math.Cos(firstPartCoff * x) / Math.Cos(secondPartCoff * x));
            return null;
        }
        private (string,string) GetParts(string value, int index)
        {
            string firstPart = value.Substring(0, index - 1);
            string secondPart = value.Substring(index + 1);
            return (firstPart,secondPart);
        }
    }
}
