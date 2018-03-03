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

        public int ReprezentacijaBrojem()
        {
            char z, v, s, c;
            z = (Zelen) ? '1' : '0';
            s = (ImaSupljinu) ? '1' : '0';
            v = (Visok) ? '1' : '0';
            c = (Cetvrtast) ? '1' : '0';

            string a = z.ToString() + s + v + c;
            return Convert.ToInt32(a, 2);
        }

    }
}
