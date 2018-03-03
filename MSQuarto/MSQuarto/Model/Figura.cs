using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSQuarto.Model
{
    public class Figura
    {
        public bool Visok { get; set; }
        public bool Zelen { get; set; }
        public bool Cetvrtast { get; set; }
        public bool ImaSupljinu { get; set; }
        public bool Iskoriscena { get; set; }
        public Image Slika { get; set; }
        public string Ime { get; set; }

    }
}
