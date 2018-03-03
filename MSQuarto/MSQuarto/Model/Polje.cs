using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSQuarto.Model
{
    public class Polje:ICloneable
    {
        #region Atributi

        public Figura TrenutnaFigura { get; set; }
        public Point Lokacija { get; set; } 
       
        #endregion

        public Polje()
        {
            Lokacija=new Point(0,0);
            TrenutnaFigura = null;
        }
        public Polje(Point loc)
        {
            Lokacija = loc;
            TrenutnaFigura = null;
        }
        #region Metode
        public bool JeSlobodno()
        {
            return TrenutnaFigura == null;
        }

        public object Clone()
        {
            Polje x = new Polje();
            x.Lokacija = new Point(Lokacija.X,Lokacija.Y);
            x.TrenutnaFigura = TrenutnaFigura;
            return x;
        }
        #endregion
    }
}
