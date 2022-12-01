using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Plot
{
    internal class Finder
    {
        static public double Сoefficient(string text)
        {
                double y = 1;
                Regex regex = new Regex(@"\d+");
                MatchCollection matches = regex.Matches(text);
                if (matches.Count > 0)
                {
                    string temp1 = "";
                    foreach (Match match in matches)
                    {
                        temp1 = temp1 + match.Value;
                    }
                    y = double.Parse(temp1);
                }
                return y;
        }
    }
}
