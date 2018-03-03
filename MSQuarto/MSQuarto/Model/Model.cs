using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using MSQuarto.Properties;

namespace MSQuarto.Model
{
    public class Model : IModel
    {
        private int _poeni1 = 0;
        private int _poeni2 = 0;
        private int _naPotezu = 0;
        static ResourceManager RM = new ResourceManager("MSQuarto.Properties.Resources", typeof(Resources).Assembly);
        private Figura _selektovanaFigura;
        private Image[] _slike = new Image[]
        {
            //Zelene-Pune
            (Image)RM.GetObject("figura0"), //Visoka
            (Image)RM.GetObject("figura2"), //Visoka
            (Image)RM.GetObject("figura8"), //Niska
            (Image)RM.GetObject("figura4"), //Niska
            //Zelene-Suplje
            (Image)RM.GetObject("figura10"), //Visoka 
            (Image)RM.GetObject("figura12"), //Visoka
            (Image)RM.GetObject("figura6"), //Niska
            (Image)RM.GetObject("figura14"), //Niska
            //Braon-Pune
            (Image)RM.GetObject("figura1"), //Visoka
            (Image)RM.GetObject("figura3"), //Visoka
            (Image)RM.GetObject("figura9"), //Niska
            (Image)RM.GetObject("figura5"), //Niska
            //Braon-Suplje
            (Image)RM.GetObject("figura11"), //Visoka
            (Image)RM.GetObject("figura13"), //Visoka
            (Image)RM.GetObject("figura7"), //Niska
            (Image)RM.GetObject("figura15"), //Niska

        };
        private Polje[,] _tabla;
        private Figura[] _figureZaIzbor;

        public Model()
        {
            NovaIgra();
        }

        #region Clanice Interfejsa
        public Polje DajPolje(int x, int y)
        {
            if ((x < 0 || x >= 4) || (y < 0 || y >= 4)) return null;
            return _tabla[x, y];
        }

        public void ZauzmiPolje(int x, int y)
        {
            _tabla[x, y].TrenutnaFigura = _selektovanaFigura;
            foreach (var figura in _figureZaIzbor)
            {
                if (figura.Slika == _selektovanaFigura.Slika && _selektovanaFigura.Slika != null)
                {
                    figura.Iskoriscena = true;
                    break;
                }
            }
        }

        public Figura DajFiguruZaIzbor(int x)
        {
            return _figureZaIzbor[x];
        }

        public void PostaviSelektovanu(Figura f)
        {
            _selektovanaFigura = f;
        }

        public Figura DajSelektovanu()
        {
            return _selektovanaFigura;
        }

        public int BrojSlobodnihPolja()
        {
            int c = 0;
            foreach (var polje in _tabla)
            {
                if (polje.TrenutnaFigura != null) c++;
            }
            return 16 - c;
        }
        #endregion


        public void NovaIgra()
        {
            _tabla = new Polje[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _tabla[i, j] = new Polje(new Point(i, j));
                }
            }

            _figureZaIzbor = new Figura[16];
            for (int i = 0; i < 16; i++)
            {
                _figureZaIzbor[i] = new Figura();
                _figureZaIzbor[i].Slika = _slike[i];

                //Osobine figure
                _figureZaIzbor[i].Zelen = i < 8;
                _figureZaIzbor[i].ImaSupljinu = (i >= 4 && i < 8) || (i >= 12 && i < 16);
                _figureZaIzbor[i].Visok = (i % 4 <= 1);
                _figureZaIzbor[i].Cetvrtast = (i % 2 == 1);
            }

            //imena figura
            _figureZaIzbor[0].Ime = "figura0";
            _figureZaIzbor[1].Ime = "figura2";
            _figureZaIzbor[2].Ime = "figura8";
            _figureZaIzbor[3].Ime = "figura4";

            _figureZaIzbor[4].Ime = "figura10";
            _figureZaIzbor[5].Ime = "figura12";
            _figureZaIzbor[6].Ime = "figura6";
            _figureZaIzbor[7].Ime = "figura14";

            _figureZaIzbor[8].Ime = "figura1";
            _figureZaIzbor[9].Ime = "figura3";
            _figureZaIzbor[10].Ime = "figura9";
            _figureZaIzbor[11].Ime = "figura5";

            _figureZaIzbor[12].Ime = "figura11";
            _figureZaIzbor[13].Ime = "figura13";
            _figureZaIzbor[14].Ime = "figura7";
            _figureZaIzbor[15].Ime = "figura15";
        }

        public void Pobeda()
        {
            if (_naPotezu == 1) _poeni1++;
            else
            {
                _poeni2++;
            }
        }

        public Polje[,] Tabla {
            get {
                return _tabla;
            }
        }

        public Figura[] Figure {
            get {
                return _figureZaIzbor;
            }
        }

        public void SledeciIgrac()
        {
            _naPotezu = _naPotezu ^ 1;
        }

        public int TrenutniIgrac()
        {
            return _naPotezu;
            
        }

        public int PobedeIgracPrvi()
        {
            return _poeni1;
        }

        public int PobedeIgracDrugi()
        {
            return _poeni2;
        }

        public int Evaluacija()
        {
 
            for (int i = 0; i < 4; i++)
            {
                List<int> osobinePoVrstama = new List<int>() { 0, 0, 0, 0 };
                for (int j = 0; j < 4; j++)
                {
                    Polje x = _tabla[i, j];
                    if (!x.JeSlobodno())
                    {
                        if (x.TrenutnaFigura.Visok) osobinePoVrstama[0]++;
                        else osobinePoVrstama[0]--;
                        if (x.TrenutnaFigura.Cetvrtast) osobinePoVrstama[1]++;
                        else osobinePoVrstama[1]--;
                        if (x.TrenutnaFigura.ImaSupljinu) osobinePoVrstama[2]++;
                        else osobinePoVrstama[2]--;
                        if (x.TrenutnaFigura.Zelen) osobinePoVrstama[3]++;
                        else osobinePoVrstama[3]--;
                    }
                }
                int zajednoPoVrstama = Math.Max(Math.Abs(osobinePoVrstama.Max()), Math.Abs(osobinePoVrstama.Min()));

                
                if (zajednoPoVrstama == 4) return 1000;
                if (zajednoPoVrstama == 3) return -1000;
                if (zajednoPoVrstama == 2) return 300;

            }
            return 0;

        }


        public IModel Clone()
        {
            Model m = new Model();
            for(int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++) {
                    Polje p = new Polje();
                    p.Lokacija = new Point(i, j);
                    p.TrenutnaFigura = DajPolje(i, j).TrenutnaFigura;
                    m.Tabla[i, j] = p;
                }
            for (int i = 0; i < 16; i++) {
                Figura f = new Figura();
                f.ImaSupljinu = Figure[i].ImaSupljinu;
                f.Ime = Figure[i].Ime;
                f.Iskoriscena = Figure[i].Iskoriscena;
                f.Slika = Figure[i].Slika;
                f.Visok = Figure[i].Visok;
                f.Zelen = Figure[i].Zelen;
                f.Cetvrtast = Figure[i].Cetvrtast;
                m.Figure[i] = f;
            }
                return m;
        }

        public Polje[,] DajTablu()
        {
            return _tabla;
        }
    }
}

