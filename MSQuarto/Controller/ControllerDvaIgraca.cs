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
            _view.PrikaziLabelu();
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

        public bool DaLijeNekoPobedio()
        {
            var tabla = _model.ReprezentacijaTableBrojevima();
            //Redovi
            _indeksiPobednika = new List<Point>();

            for (int i = 0; i < 4; i++)
            {

                if (tabla[i, 0] == -1 || tabla[i, 1] == -1 || tabla[i, 2] == -1 || tabla[i, 3] == -1) continue;

                int osobine1 = tabla[i, 0] & tabla[i, 1] & tabla[i, 2] & tabla[i, 3];
                int osobine2 = (tabla[i, 0] ^ 15) & (tabla[i, 1] ^ 15) & (tabla[i, 2] ^ 15) & (tabla[i, 3] ^ 15);

                if (osobine1 != 0 || osobine2 != 0)
                {
                    _indeksiPobednika.Add(new Point(i, 0));
                    _indeksiPobednika.Add(new Point(i, 1));
                    _indeksiPobednika.Add(new Point(i, 2));
                    _indeksiPobednika.Add(new Point(i, 3));
                    return true;
                }
            }

            //Kolone
            for (int i = 0; i < 4; i++)
            {

                if (tabla[0, i] == -1 || tabla[1, i] == -1 || tabla[2, i] == -1 || tabla[3, i] == -1) continue;

                int osobine1 = tabla[0, i] & tabla[1, i] & tabla[2, i] & tabla[3, i];
                int osobine2 = (tabla[0, i] ^ 15) & (tabla[1, i] ^ 15) & (tabla[2, i] ^ 15) & (tabla[3, i] ^ 15);

                if (osobine1 != 0 || osobine2 != 0)
                {
                    _indeksiPobednika.Add(new Point(0, i));
                    _indeksiPobednika.Add(new Point(1, i));
                    _indeksiPobednika.Add(new Point(2, i));
                    _indeksiPobednika.Add(new Point(3, i));
                    return true;
                }
            }

            //Glavna dijagonala
            if (tabla[0, 0] != -1 && tabla[1, 1] != -1 && tabla[2, 2] != -1 && tabla[3, 3] != -1)
            {
                int osobine1 = tabla[0, 0] & tabla[1, 1] & tabla[2, 2] & tabla[3, 3];
                int osobine2 = (tabla[0, 0] ^ 15) & (tabla[1, 1] ^ 15) & (tabla[2, 2] ^ 15) & (tabla[3, 3] ^ 15);

                if (osobine1 != 0 || osobine2 != 0)
                {
                    _indeksiPobednika.Add(new Point(0, 0));
                    _indeksiPobednika.Add(new Point(1, 1));
                    _indeksiPobednika.Add(new Point(2, 2));
                    _indeksiPobednika.Add(new Point(3, 3));
                    return true;
                }
            }

            //Sporedna dijagonala
            if (tabla[0, 3] != -1 && tabla[1, 2] != -1 && tabla[2, 1] != -1 && tabla[3, 0] != -1)
            {
                int osobine1 = tabla[0, 3] & tabla[1, 2] & tabla[2, 1] & tabla[3, 0];
                int osobine2 = (tabla[0, 3] ^ 15) & (tabla[1, 2] ^ 15) & (tabla[2, 1] ^ 15) & (tabla[3, 0] ^ 15);

                if (osobine1 != 0 || osobine2 != 0)
                {
                    _indeksiPobednika.Add(new Point(0, 3));
                    _indeksiPobednika.Add(new Point(1, 2));
                    _indeksiPobednika.Add(new Point(2, 1));
                    _indeksiPobednika.Add(new Point(3, 0));
                    return true;
                }
            }
            return false;
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
