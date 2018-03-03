using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSQuarto.Model;
using MSQuarto.View;
using MSQuarto.Properties;
using System.Resources;

namespace MSQuarto.Controller
{
    class ControllerDvaIgraca : IController
    {
        static ResourceManager RM = new ResourceManager("MSQuarto.Properties.Resources", typeof(Resources).Assembly);

        private IModel _model;
        private IView _view;

        private List<Point> _indeksiPobednika;

        public ControllerDvaIgraca(IModel _model, IView _view)
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

        public void OdigrajPotez(Point loc)
        {
            _model.ZauzmiPolje(loc.X,loc.Y);
            if (KrajIgre()) { _view.Nereseno(); return; }
            if (DaLijeNekoPobedio()) _view.Pobeda();
            _model.SledeciIgrac();
            if (!DaLijeNekoPobedio()) _view.AzurirajPoruku(_model.TrenutniIgrac());
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

            for (int i = 0; i < 4; i++) {
                if (pom == null || pom.TrenutnaFigura == null) continue;
                for (int j = 0; j < 4; j++) {
                    if (i != j) continue;
                    if (_model.DajPolje(i, j) == null) break;
                    if (_model.DajPolje(i, j).TrenutnaFigura == null) break;
                    if (pom.TrenutnaFigura.Cetvrtast == _model.DajPolje(i, j).TrenutnaFigura.Cetvrtast) l1.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Zelen == _model.DajPolje(i, j).TrenutnaFigura.Zelen) l2.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.Visok == _model.DajPolje(i, j).TrenutnaFigura.Visok) l3.Add(new Point(i, j));
                    if (pom.TrenutnaFigura.ImaSupljinu == _model.DajPolje(i, j).TrenutnaFigura.ImaSupljinu) l4.Add(new Point(i, j));
                }
            }
            if (l1.Count == 4) {
                _indeksiPobednika = l1;
                return true;
            }
            else if (l2.Count == 4) {
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
            
            for (int i = 0; i < 4; i++) {
                if (pom == null || pom.TrenutnaFigura == null) continue;
                for (int j = 0; j < 4; j++) {
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

        private bool ProveraPoRedovima() {

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
                if (l1.Count == 4) {
                    _indeksiPobednika = l1;
                    return true;
                }
                else if (l2.Count == 4) {
                    _indeksiPobednika = l2;
                    return true;
                }
                else if (l3.Count == 4) {
                    _indeksiPobednika = l3;
                    return true;
                }
                else if (l4.Count == 4) {
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

        public void Pobeda() {
            _model.Pobeda();
            _view.AzurirajRezultat();
            for (int i = 0; i < _indeksiPobednika.Count; i++) {
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
