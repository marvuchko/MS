using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSQuarto.Model;
using MSQuarto.View;
using MSQuarto.Properties;
using System.Resources;
using System.Windows.Forms;

namespace MSQuarto.Controller
{
    class ControllerJedanIgrac : IController
    {
        static ResourceManager RM = new ResourceManager("MSQuarto.Properties.Resources", typeof(Resources).Assembly);

        private IModel _model;
        private IView _view;
        private List<Point> _indeksiPobednika;
        public ControllerJedanIgrac(IModel _model, IView _view)
        {
            this._model = _model;
            this._view = _view;
        }

        public IModel MojModel()
        {
            return _model;
        }

        public Image DajSliku(int x)
        {
            return _model.DajFiguruZaIzbor(x).Slika;
        }

        public void NovaIgra()
        {
            _view.Iscrtaj();
            _model.NovaIgra();
            _view.AzurirajPoruku(_model.TrenutniIgrac());
        }

        private List<Potez> ListaMogucihPoteza(Polje[,] polje)
        {
            List<Potez> _lista = new List<Potez>();
            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 4; j++) //tabla
                {
                    foreach (var f in ListaMogucihFigura())
                    {
                        if (polje[i,j].JeSlobodno())
                        {
                            _lista.Add(new Potez() {  PostavljenaFigura = f, Pozicija = new Point(i, j)});
                        }
                    }
                }
            }
            return _lista;
        }

        private List<Figura> ListaMogucihFigura() {

            List<Figura> _lista = new List<Figura>();
        
                for (int i = 0; i < 16; i++) //figure
                {
                    if (!_model.DajFiguruZaIzbor(i).Iskoriscena){
                        Figura f = _model.DajFiguruZaIzbor(i);
                        _lista.Add(new Figura()
                        {
                            Cetvrtast = f.Cetvrtast,
                            Zelen = f.Zelen,
                            ImaSupljinu = f.ImaSupljinu,
                            Iskoriscena = f.Iskoriscena,
                            Slika = f.Slika,
                            Ime = f.Ime,
                            Visok = f.Visok
                        });
                    }
                }
            
            return _lista;
        }
        private int Evaluacija(Polje[,] tabla)
        {

            //for (int i = 0; i < 4; i++)
            //{
            //    List<int> osobinePoVrstama = new List<int>() { 0, 0, 0, 0 };
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Polje x = polje[i, j];
            //        if (!x.JeSlobodno())
            //        {
            //            if (x.TrenutnaFigura.Visok) osobinePoVrstama[0]++;
            //            else osobinePoVrstama[0]--;
            //            if (x.TrenutnaFigura.Cetvrtast) osobinePoVrstama[1]++;
            //            else osobinePoVrstama[1]--;
            //            if (x.TrenutnaFigura.ImaSupljinu) osobinePoVrstama[2]++;
            //            else osobinePoVrstama[2]--;
            //            if (x.TrenutnaFigura.Zelen) osobinePoVrstama[3]++;
            //            else osobinePoVrstama[3]--;
            //        }
            //    }
            //    int zajednoPoVrstama = Math.Max(Math.Abs(osobinePoVrstama.Max()), Math.Abs(osobinePoVrstama.Min()));


            //    if (zajednoPoVrstama == 4) return 1000;
            //    if (zajednoPoVrstama == 3) return -1000;
            //    //if (zajednoPoVrstama == 2) return 300;

            //}
            //return 0;
            int c = 0;
            if (!tabla[0, 0].JeSlobodno()) c++;
            if (!tabla[1, 1].JeSlobodno()) c++;
            if (!tabla[2, 2].JeSlobodno()) c++;
            if (!tabla[3, 3].JeSlobodno()) c++;
            return c*100;
        }
        private Potez AlphaBeta(Polje[,] polje, int depth, int alpha, int beta, int max)
        {
            var c = ListaMogucihPoteza(polje);

            if (depth == 0 || c.Count == 0)
            {
                int ca = Evaluacija(polje);
                return new Potez()
                {
                    Value = ca
                };
            }
            Potez najbolji = new Potez();
            if (max == 1)
            {
                najbolji.Value = int.MinValue;
                

                foreach (var p in c)
                {
                    polje[p.Pozicija.X, p.Pozicija.Y].Lokacija = p.Pozicija;
                    polje[p.Pozicija.X, p.Pozicija.Y].TrenutnaFigura = p.PostavljenaFigura;
                    p.PostavljenaFigura.Iskoriscena = true;
                    Potez tmp = AlphaBeta(polje, depth - 1, alpha,beta, 0);
                    
                    polje[p.Pozicija.X, p.Pozicija.Y].TrenutnaFigura = null;
                    p.PostavljenaFigura.Iskoriscena = false;

                    p.Value = tmp.Value;
                    if (p.Value > najbolji.Value) najbolji = p;

                    alpha = Math.Max(alpha, najbolji.Value);

                    if (alpha >= beta) break;
                }
                
            }
            else
            {
                najbolji.Value = int.MaxValue;
                foreach (var p in c)
                {
                    polje[p.Pozicija.X, p.Pozicija.Y].Lokacija = p.Pozicija;
                    polje[p.Pozicija.X, p.Pozicija.Y].TrenutnaFigura = p.PostavljenaFigura;
                    p.PostavljenaFigura.Iskoriscena = true;
                    Potez tmp = AlphaBeta(polje, depth - 1, alpha, beta, 0);

                    polje[p.Pozicija.X, p.Pozicija.Y].TrenutnaFigura = null;
                    p.PostavljenaFigura.Iskoriscena = false;
                    p.Value = tmp.Value;
                    if (p.Value < najbolji.Value) najbolji = p;

                    beta = Math.Min(beta, najbolji.Value);

                    if (alpha >= beta) break;
                }

            }
            return najbolji;
        }

        private void PotezAi()
        {
            
            int bsp = _model.BrojSlobodnihPolja();
            Potez p = new Potez();
            if (bsp > 14)
            {
                Random rand = new Random();
                int i, j, k;

                do
                {
                    i = rand.Next(0, 4);
                    j = rand.Next(0, 4);
                    k = rand.Next(0, 15);

                } while (_model.DajPolje(i, j).JeSlobodno() && _model.DajFiguruZaIzbor(k).Iskoriscena);

                p.PostavljenaFigura = _model.DajFiguruZaIzbor(k);
                p.Pozicija=new Point(i,j);

                _model.PostaviSelektovanu(p.PostavljenaFigura);
                _model.ZauzmiPolje(i,j);
                _view.PrikaziPotez(p);
                _model.SledeciIgrac();
                _view.AzurirajPoruku(_model.TrenutniIgrac());
            }
            else
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Polje[,] tabla= new Polje[4,4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        tabla[i, j] = (Polje)_model.DajPolje(i, j).Clone();
                    }
                }
                p = AlphaBeta(tabla, 4, int.MinValue, int.MaxValue, 1);
                sw.Stop();
                //MessageBox.Show("Vreme izvrsenja AlphaBeta algoritma: "+sw.Elapsed.TotalSeconds.ToString());
                _model.PostaviSelektovanu(p.PostavljenaFigura);
                _model.ZauzmiPolje(p.Pozicija.X, p.Pozicija.Y);
                _view.PrikaziPotez(p);

                _model.SledeciIgrac();
                _view.AzurirajPoruku(_model.TrenutniIgrac());
            }

        }
        public void OdigrajPotez(Point loc)
        {
            _model.ZauzmiPolje(loc.X, loc.Y);
            _view.PrikaziPotez(new Potez() { PostavljenaFigura = _model.DajSelektovanu(), Pozicija = loc });
            if (KrajIgre()) { _view.Nereseno(); return; }
            if (DaLijeNekoPobedio()) _view.Pobeda();
            _model.SledeciIgrac();
            
            if (!DaLijeNekoPobedio())
            {
                _view.AzurirajPoruku(_model.TrenutniIgrac());
                PotezAi();
                if(DaLijeNekoPobedio())_view.Pobeda();
            }
        }
        public void Selektuj(int index)
        {
            Figura f = _model.DajFiguruZaIzbor(index);
            _model.PostaviSelektovanu(f);
        }

        public bool KrajIgre()
        {
            return _model.BrojSlobodnihPolja() == 0;
        }

        private bool ProveraPoDijagonalama()
        {
            //glavna dijagonala
            Polje pom = _model.DajPolje(0, 0);

            List<Point> l1 = new List<Point>();
            List<Point> l2 = new List<Point>();
            List<Point> l3 = new List<Point>();
            List<Point> l4 = new List<Point>();

            for (int i = 0; i < 4; i++)
            {
                if (pom == null || pom.TrenutnaFigura == null) continue;
                for (int j = 0; j < 4; j++)
                {
                    if (i != j) continue;
                    if (_model.DajPolje(i, j) == null) break;
                    if (_model.DajPolje(i, j).TrenutnaFigura == null) break;
                    if (pom.TrenutnaFigura.Cetvrtast == _model.DajPolje(i, j).TrenutnaFigura.Cetvrtast) l1.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Zelen == _model.DajPolje(i, j).TrenutnaFigura.Zelen) l2.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Visok == _model.DajPolje(i, j).TrenutnaFigura.Visok) l3.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.ImaSupljinu == _model.DajPolje(i, j).TrenutnaFigura.ImaSupljinu) l4.Add(new Point(i, j));
                }
            }
            if (l1.Count == 4)
            {
                _indeksiPobednika = l1;
                return true;
            }
            else if (l2.Count == 4)
            {
                _indeksiPobednika = l2;
                return true;
            }
            else if (l3.Count == 4)
            {
                _indeksiPobednika = l3;
                return true;
            }
            else if (l4.Count == 4)
            {
                _indeksiPobednika = l4;
                return true;
            }

            //sporedna dijagonala
            pom = _model.DajPolje(0, 3);
            l1 = new List<Point>();
            l2 = new List<Point>();
            l3 = new List<Point>();
            l4 = new List<Point>();

            for (int i = 0; i < 4; i++)
            {
                if (pom == null || pom.TrenutnaFigura == null) continue;
                for (int j = 0; j < 4; j++)
                {
                    if (i + j != 3) continue;
                    if (_model.DajPolje(i, j) == null) break;
                    if (_model.DajPolje(i, j).TrenutnaFigura == null) break;
                    if (pom.TrenutnaFigura.Cetvrtast == _model.DajPolje(i, j).TrenutnaFigura.Cetvrtast) l1.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Zelen == _model.DajPolje(i, j).TrenutnaFigura.Zelen) l2.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Visok == _model.DajPolje(i, j).TrenutnaFigura.Visok) l3.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.ImaSupljinu == _model.DajPolje(i, j).TrenutnaFigura.ImaSupljinu) l4.Add(new Point(i, j));
                }
            }
            if (l1.Count == 4)
            {
                _indeksiPobednika = l1;
                return true;
            }
            else if (l2.Count == 4)
            {
                _indeksiPobednika = l2;
                return true;
            }
            else if (l3.Count == 4)
            {
                _indeksiPobednika = l3;
                return true;
            }
            else if (l4.Count == 4)
            {
                _indeksiPobednika = l4;
                return true;
            }
            return false;
        }

        private bool ProveraPoRedovima()
        {

            int j = 0;

            for (int i = 0; i < 4; i++)
            {
                Polje pom = _model.DajPolje(i, j);

                List<Point> l1 = new List<Point>();
                List<Point> l2 = new List<Point>();
                List<Point> l3 = new List<Point>();
                List<Point> l4 = new List<Point>();

                if (pom == null || pom.TrenutnaFigura == null) continue;
                for (j = 0; j < 4; j++)
                {
                    if (_model.DajPolje(i, j) == null) break;
                    if (_model.DajPolje(i, j).TrenutnaFigura == null) break;
                    if (pom.TrenutnaFigura.Cetvrtast == _model.DajPolje(i, j).TrenutnaFigura.Cetvrtast) l1.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Zelen == _model.DajPolje(i, j).TrenutnaFigura.Zelen) l2.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Visok == _model.DajPolje(i, j).TrenutnaFigura.Visok) l3.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.ImaSupljinu == _model.DajPolje(i, j).TrenutnaFigura.ImaSupljinu) l4.Add(new Point(i, j));
                }
                if (l1.Count == 4)
                {
                    _indeksiPobednika = l1;
                    return true;
                }
                else if (l2.Count == 4)
                {
                    _indeksiPobednika = l2;
                    return true;
                }
                else if (l3.Count == 4)
                {
                    _indeksiPobednika = l3;
                    return true;
                }
                else if (l4.Count == 4)
                {
                    _indeksiPobednika = l4;
                    return true;
                }
            }
            return false;
        }

        private bool ProveraPoKolonama()
        {
            int i = 0;

            for (int j = 0; j < 4; j++)
            {
                Polje pom = _model.DajPolje(i, j);

                List<Point> l1 = new List<Point>();
                List<Point> l2 = new List<Point>();
                List<Point> l3 = new List<Point>();
                List<Point> l4 = new List<Point>();

                if (pom == null || pom.TrenutnaFigura == null) continue;
                for (i = 0; i < 4; i++)
                {
                    if (_model.DajPolje(i, j) == null) break;
                    if (_model.DajPolje(i, j).TrenutnaFigura == null) break;
                    if (pom.TrenutnaFigura.Cetvrtast == _model.DajPolje(i, j).TrenutnaFigura.Cetvrtast) l1.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Zelen == _model.DajPolje(i, j).TrenutnaFigura.Zelen) l2.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Visok == _model.DajPolje(i, j).TrenutnaFigura.Visok) l3.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.ImaSupljinu == _model.DajPolje(i, j).TrenutnaFigura.ImaSupljinu) l4.Add(new Point(i, j));
                }
                if (l1.Count == 4)
                {
                    _indeksiPobednika = l1;
                    return true;
                }
                else if (l2.Count == 4)
                {
                    _indeksiPobednika = l2;
                    return true;
                }
                else if (l3.Count == 4)
                {
                    _indeksiPobednika = l3;
                    return true;
                }
                else if (l4.Count == 4)
                {
                    _indeksiPobednika = l4;
                    return true;
                }
            }
            return false;
        }

        public bool DaLijeNekoPobedio()
        {
            return ProveraPoRedovima() || ProveraPoKolonama() || ProveraPoDijagonalama();
        }

        public void Pobeda()
        {
            _model.Pobeda();
            _view.AzurirajRezultat();
            for (int i = 0; i < _indeksiPobednika.Count; i++)
            {
                Point pom = _indeksiPobednika[i];
                _view.Tabla[pom.X, pom.Y].BackgroundImage = (Image)RM.GetObject(_model.DajPolje(pom.X, pom.Y).TrenutnaFigura.Ime + "C");
            }

        }

        public int BrojPobeda(int indeks)
        {
            if (indeks == 1) return _model.PobedeIgracPrvi();
            else return _model.PobedeIgracDrugi();
        }

        public int Pobednik()
        {
            return _model.TrenutniIgrac();
        }
    }
}

