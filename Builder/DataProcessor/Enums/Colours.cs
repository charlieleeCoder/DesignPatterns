using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Enums
{
    // Define valid colours
    public enum Colour
    {
        red,
        green,
        blue,
        yellow
    }

    public static class ColoursDictionary
    {
        public static Dictionary<Colour, string> ColourLookup = new Dictionary<Colour, string>
        {
            { Colour.red, "Red" },
            { Colour.green, "Green" },
            { Colour.blue, "Blue" },
            { Colour.yellow, "Yellow" }
        };
    }

}
