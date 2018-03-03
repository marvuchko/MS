using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        private double _kreiranjeListePoteza;
        public ControllerJedanIgrac(IModel _model, IView _view)
        {
            this._model = _model;
            this._view = _view;
            _view.SakrijLabelu();
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

        private List<Potez> ListaMogucihPoteza(int[,] polje)
        {
            List<Potez> _lista = new List<Potez>();
            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 4; j++) //tabla
                {
                    foreach (var f in ListaMogucihFigura())
                    {
                        if (polje[i,j]==-1)
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
                    Figura f = _model.DajFiguruZaIzbor(i);
                    if(!f.Iskoriscena) _lista.Add(
                        f);
                }
            
            return _lista;
        }

       
        private int Evaluacija(int[,] tabla)
        {
            //Redovi (uslov za pobedu)
            for (int i = 0; i < 4; i++)
            {
                
                if(tabla[i,0]==-1 || tabla[i,1]==-1 || tabla[i,2]==-1 || tabla[i,3]==-1) continue;

                int osobine1 = tabla[i, 0] & tabla[i, 1] & tabla[i, 2] & tabla[i, 3];
                int osobine2 = (tabla[i, 0] ^ 15) & (tabla[i, 1] ^ 15) & (tabla[i, 2] ^ 15) & (tabla[i, 3] ^ 15);

                if ((osobine1 != 0 || osobine2 != 0) && _model.TrenutniIgrac() == 1) return 2000;
                if ((osobine1 != 0 || osobine2 != 0) && _model.TrenutniIgrac() == 0) return -2000;
            }

            //Kolone (uslov za pobedu)
            for (int i = 0; i < 4; i++)
            {

                if (tabla[0, i] == -1 || tabla[1, i] == -1 || tabla[2, i] == -1 || tabla[3, i] == -1) continue;

                int osobine1 = tabla[0, i] & tabla[1, i] & tabla[2, i] & tabla[3, i];
                int osobine2 = (tabla[0, i] ^ 15) & (tabla[1, i] ^ 15) & (tabla[2, i] ^ 15) & (tabla[3, i] ^ 15);

                if ((osobine1 != 0 || osobine2 != 0) && _model.TrenutniIgrac() == 1) return 2000;
                if ((osobine1 != 0 || osobine2 != 0) && _model.TrenutniIgrac() == 0) return -2000;
            }

            //Glavna dijagonala (uslov za pobedu)
            if (tabla[0, 0] != -1 && tabla[1, 1] != -1 && tabla[2, 2] != -1 && tabla[3, 3] != -1)
            {
                int osobine1 = tabla[0, 0] & tabla[1, 1] & tabla[2, 2] & tabla[3, 3];
                int osobine2 = (tabla[0, 0] ^ 15) & (tabla[1, 1] ^ 15) & (tabla[2, 2] ^ 15) & (tabla[3, 3] ^ 15);

                if ((osobine1 != 0 || osobine2 != 0) && _model.TrenutniIgrac() == 1) return 2000;
                if ((osobine1 != 0 || osobine2 != 0) && _model.TrenutniIgrac() == 0) return -2000;
            }

            //Sporedna dijagonala (uslov za pobedu)
            if (tabla[0, 3] != -1 && tabla[1, 2] != -1 && tabla[2, 1] != -1 && tabla[3, 0] != -1)
            {
                int osobine1 = tabla[0,3] & tabla[1, 2] & tabla[2, 1] & tabla[3, 0];
                int osobine2 = (tabla[0, 3] ^ 15) & (tabla[1, 2] ^ 15) & (tabla[2, 1] ^ 15) & (tabla[3, 0] ^ 15);

                if ((osobine1 != 0 || osobine2 != 0) && _model.TrenutniIgrac() == 1) return 2000;
                if ((osobine1 != 0 || osobine2 != 0) && _model.TrenutniIgrac() == 0) return -2000;
            }

            int triUVrsti = 0, triUKoloni = 0, triNaDijagonali = 0,
                dveUVrsti = 0, dveUKoloni = 0, dveNaDijagonali = 0;
            int rez = 0;

            int andOP1 = 15, andOP2 = 15, br;
            for (int i = 0; i < 4; i++) {
                br = 0;
                for (int j = 0; j < 4; j++) {
                    if (tabla[i, j] != -1) {
                        andOP1 &= tabla[i, j];
                        andOP2 &= tabla[i, j] ^ 15;
                        br++;
                    }
                }
                //tri iste u vrsti;
                if(br == 3 && (andOP1 != 0 || andOP2 != 0)) triUVrsti++;
                //dve iste u vrsti
                if (br == 2 && (andOP1 != 0 || andOP2 != 0)) dveUVrsti++;
                //jedna u vrsti
                if (br == 1 && (andOP1 != 0 || andOP2 != 0)) rez -= 150;
                andOP1 = 15;
                andOP2 = 15;
            }

            andOP1 = 15;
            andOP2 = 15;
            br = 0;
            for (int i = 0; i < 4; i++)
            {
                br = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (tabla[j, i] != -1)
                    {
                        andOP1 &= tabla[j, i];
                        andOP2 &= tabla[j, i] ^ 15;
                        br++;
                    }
                }
                //tri iste u koloni;
                if (br == 3 && (andOP1 != 0 || andOP2 != 0)) triUKoloni++;
                //dve iste u koloni;
                if (br == 2 && (andOP1 != 0 || andOP2 != 0)) dveUKoloni++;
                //jedna u koloni;
                if (br == 1 && (andOP1 != 0 || andOP2 != 0)) rez -= 150;
                andOP1 = 15;
                andOP2 = 15;
            }

            andOP1 = 15;
            andOP2 = 15;
            br = 0;
            for (int i = 0; i < 4; i++) {
                if (tabla[i, i] != -1) {
                    andOP1 &= tabla[i, i];
                    andOP2 &= tabla[i, i] ^ 15;
                    br++;
                }
            }
            //tri na glavnoj dijagonali
            if (br == 3 && (andOP1 != 0 || andOP2 != 0)) triNaDijagonali++;
            //dve na glavnoj dijagonali
            if (br == 2 && (andOP1 != 0 || andOP2 != 0)) dveNaDijagonali++;
            //jedna na glavnoj dijagonali
            if (br == 1 && (andOP1 != 0 || andOP2 != 0)) rez -= 150;
          
           
            andOP1 = 15;
            andOP2 = 15;
            br = 0;
            for (int i = 0; i < 4; i++)
            {
                if (tabla[i, 3 - i] != -1)
                {
                    andOP1 &= tabla[i, 3 - i];
                    andOP1 &= tabla[i, 3 - i] ^ 15;
                    br++;
                }

            }
            //tri na sporednoj dijagonali
            if (br == 3 && (andOP1 != 0 || andOP2 != 0)) triNaDijagonali++;
            //dve na sporednoj dijagonali
            if (br == 2 && (andOP1 != 0 || andOP2 != 0)) dveNaDijagonali++;
            //jedna na sporednoj dijagonali
            if (br == 1 && (andOP1 != 0 || andOP2 != 0)) rez -= 150;
            
            if(_model.TrenutniIgrac() == 1)
                return 150 * (dveUVrsti + dveUKoloni + dveNaDijagonali) - 320 * (triNaDijagonali + triUKoloni + triUKoloni) + rez;
            else
                return -1 * (150 * (dveUVrsti + dveUKoloni + dveNaDijagonali) - 320 * (triNaDijagonali + triUKoloni + triUKoloni) + rez);
            
        }
        private Potez AlphaBeta(int[,] polje, int depth, int alpha, int beta, int max)
        {
            string kljuc = TranspozicionaTabela.Hash(polje);
            Unos unos = TranspozicionaTabela.DajUnos(kljuc);

            if (unos != null)
            {
                if (unos.Dubina == depth) return unos.NajboljiPotez;
            }

            //Stopwatch sw = new Stopwatch();
           // sw.Start();
            var c = ListaMogucihPoteza(polje);
            //sw.Stop();
            //_kreiranjeListePoteza += sw.Elapsed.TotalSeconds;
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
                    polje[p.Pozicija.X, p.Pozicija.Y] = p.PostavljenaFigura.ReprezentacijaBrojem();
                    p.PostavljenaFigura.Iskoriscena = true;

                    Potez tmp = AlphaBeta(polje, depth - 1, alpha, beta, 0);
                    
                    polje[p.Pozicija.X, p.Pozicija.Y] = -1;
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
                    polje[p.Pozicija.X, p.Pozicija.Y] = p.PostavljenaFigura.ReprezentacijaBrojem();
                    p.PostavljenaFigura.Iskoriscena = true;
                    Potez tmp = AlphaBeta(polje, depth - 1, alpha, beta, 1);

                    polje[p.Pozicija.X, p.Pozicija.Y] = -1;
                    p.PostavljenaFigura.Iskoriscena = false;
                    p.Value = tmp.Value;
                    if (p.Value < najbolji.Value) najbolji = p;

                    beta = Math.Min(beta, najbolji.Value);

                    if (alpha >= beta) break;
                }

            }

            Unos tmpUnos = TranspozicionaTabela.DajUnos(kljuc);
            if (tmpUnos == null)
            {
                tmpUnos = new Unos() {Alfa = alpha, Beta = beta, Dubina = depth, NajboljiPotez = najbolji};
                TranspozicionaTabela.DodajUnos(kljuc, tmpUnos);
            }
            else
            {
                tmpUnos.Dubina = depth;
                tmpUnos.Alfa = alpha;
                tmpUnos.Beta = beta;
                tmpUnos.NajboljiPotez = najbolji;
            }

            return najbolji;
        }

        

        private void PotezAi()
        {
            {
                //Ostali potezi
                Stopwatch sw = new Stopwatch();
                sw.Start();

                int[,] tabla = new int[4,4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        tabla[i, j] = _model.ReprezentacijaTableBrojevima()[i, j];
                    }
                }
                _kreiranjeListePoteza = 0;
                Potez p = AlphaBeta(tabla, 2, int.MinValue, int.MaxValue, 1);
                sw.Stop();
                
                //MessageBox.Show("Vreme izvrsenja AlphaBeta algoritma: "+sw.Elapsed.TotalSeconds.ToString());
                //MessageBox.Show("Vreme kreiranja liste poteza" + _kreiranjeListePoteza);
                _model.PostaviSelektovanu(p.PostavljenaFigura);
                _model.ZauzmiPolje(p.Pozicija.X, p.Pozicija.Y);
                _view.PrikaziPotez(p);
                if (KrajIgre()) { _view.Nereseno(); return; }
                _view.AzurirajPoruku(_model.TrenutniIgrac());
                if (DaLijeNekoPobedio()) _view.Pobeda();
                _model.SledeciIgrac();
            }

        }
        public void OdigrajPotez(Point loc)
        {
            _model.ZauzmiPolje(loc.X, loc.Y);
            Potez p = new Potez() {PostavljenaFigura = _model.DajSelektovanu(), Pozicija = loc};
            _view.PrikaziPotez(p);
            //for(int i=0;i<16;i++)
            //MessageBox.Show(_model.DajFiguruZaIzbor(i).Ime + "\n" + _model.DajFiguruZaIzbor(i).ReprezentacijaBrojem());
            if (KrajIgre()) { _view.Nereseno(); return; }

            if (DaLijeNekoPobedio())
            {
                _view.Pobeda();
                return;
            }

            _view.AzurirajPoruku(_model.TrenutniIgrac());
            _model.SledeciIgrac();
            
            PotezAi();

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
            _indeksiPobednika= new List<Point>();

            for (int i = 0; i < 4; i++)
            {

                if (tabla[i, 0] == -1 || tabla[i, 1] == -1 || tabla[i, 2] == -1 || tabla[i, 3] == -1) continue;

                int osobine1 = tabla[i, 0] & tabla[i, 1] & tabla[i, 2] & tabla[i, 3];
                int osobine2 = (tabla[i, 0] ^ 15) & (tabla[i, 1] ^ 15) & (tabla[i, 2] ^ 15) & (tabla[i, 3] ^ 15);

                if (osobine1 != 0 || osobine2 != 0) {
                    _indeksiPobednika.Add(new Point(i,0));
                    _indeksiPobednika.Add(new Point(i,1));
                    _indeksiPobednika.Add(new Point(i,2));
                    _indeksiPobednika.Add(new Point(i,3));
                    return true;
                }
            }

            //Kolone
            for (int i = 0; i < 4; i++)
            {

                if (tabla[0, i] == -1 || tabla[1, i] == -1 || tabla[2, i] == -1 || tabla[3, i] == -1) continue;

                int osobine1 = tabla[0, i] & tabla[1, i] & tabla[2, i] & tabla[3, i];
                int osobine2 = (tabla[0, i] ^ 15) & (tabla[1, i] ^ 15) & (tabla[2, i] ^ 15) & (tabla[3, i] ^ 15);

                if (osobine1 != 0 || osobine2 != 0) {
                    _indeksiPobednika.Add(new Point(0,i));
                    _indeksiPobednika.Add(new Point(1,i));
                    _indeksiPobednika.Add(new Point(2,i));
                    _indeksiPobednika.Add(new Point(3,i));
                    return true;
                }
            }

            //Glavna dijagonala
            if (tabla[0, 0] != -1 && tabla[1, 1] != -1 && tabla[2, 2] != -1 && tabla[3, 3] != -1)
            {
                int osobine1 = tabla[0, 0] & tabla[1, 1] & tabla[2, 2] & tabla[3, 3];
                int osobine2 = (tabla[0, 0] ^ 15) & (tabla[1, 1] ^ 15) & (tabla[2, 2] ^ 15) & (tabla[3, 3] ^ 15);

                if (osobine1 != 0 || osobine2 != 0) {
                    _indeksiPobednika.Add(new Point(0,0));
                    _indeksiPobednika.Add(new Point(1,1));
                    _indeksiPobednika.Add(new Point(2,2));
                    _indeksiPobednika.Add(new Point(3,3));
                    return true;
                }
            }

            //Sporedna dijagonala
            if (tabla[0, 3] != -1 && tabla[1, 2] != -1 && tabla[2, 1] != -1 && tabla[3, 0] != -1)
            {
                int osobine1 = tabla[0, 3] & tabla[1, 2] & tabla[2, 1] & tabla[3, 0];
                int osobine2 = (tabla[0, 3] ^ 15) & (tabla[1, 2] ^ 15) & (tabla[2, 1] ^ 15) & (tabla[3, 0] ^ 15);

                if (osobine1 != 0 || osobine2 != 0) {
                    _indeksiPobednika.Add(new Point(0,3));
                    _indeksiPobednika.Add(new Point(1,2));
                    _indeksiPobednika.Add(new Point(2,1));
                    _indeksiPobednika.Add(new Point(3,0));
                    return true;
                }
            }
            return false;
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

