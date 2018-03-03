using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSQuarto.Controller;
using MSQuarto.Model;
using MSQuarto.Properties;
using MSQuarto.View;

namespace MSQuarto
{
    public partial class FormIgra : Form, IView
    {
        #region Atributi

        private IController _controller;
        private ProvidnoDugme[,] _tabla=null;
        private ProvidnoDugme[] _figureZaIzbor = null;
        private ProvidnoDugme _selektovano = null;
        
        
        private string[] _igraci = { "prvi igrač", "drugi igrač" };
        #endregion

        FormaDijalog RoditeljForma { set; get; }

        public FormIgra(FormaDijalog d)
        {
            InitializeComponent();
            RoditeljForma = d;
            d.Close();
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
        }

        public void PostaviElemente()
        {
            _tabla = new ProvidnoDugme[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    _tabla[i, j] = new ProvidnoDugme();
                    _tabla[i, j].BackgroundImage = null;
                    _tabla[i, j].SetBounds(86 + j * 82, 20 + i * 82, 30, 75);
                    _tabla[i, j].Click += TablaDugme_Click;
                    _tabla[i, j].Tag = new Point(i, j);
                    this.Controls.Add(_tabla[i, j]);
                }
            _figureZaIzbor = new ProvidnoDugme[16];
            for (int j = 0; j < 16; j++)
            {
                _figureZaIzbor[j] = new ProvidnoDugme();
                _figureZaIzbor[j].BackgroundImage = _controller.DajSliku(j);
                _figureZaIzbor[j].SetBounds(56 + (j % 8) * 51, 435 + (j / 8) * 56, 20, 56);
                _figureZaIzbor[j].Click += new EventHandler(BiranjeFigureZaIzbor);
                _figureZaIzbor[j].MouseEnter += new EventHandler(figureMouseEnter);
                _figureZaIzbor[j].MouseLeave += new EventHandler(figureMouseLeave);
                _figureZaIzbor[j].Tag = j.ToString();
                this.Controls.Add(_figureZaIzbor[j]);
            }
            _selektovano = new ProvidnoDugme();
            _selektovano.SetBounds(494, 474, 30, 75);
            this.Controls.Add(_selektovano);
        }

        private void figureMouseEnter(object sender, EventArgs e)
        {
            ProvidnoDugme pd = (ProvidnoDugme)sender;
            if (!pd.Posecivano)
                this.Cursor = new Cursor(Properties.Resources.cursor1.Handle);
        }

        private void figureMouseLeave(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
        }
        private void TablaDugme_Click(object sender, EventArgs e)
        {
            if (_selektovano.BackgroundImage == null) return;

            ProvidnoDugme pd = sender as ProvidnoDugme;
            if (pd.BackgroundImage != null) return;
            
            pd.BackgroundImage = _selektovano.BackgroundImage;
            _selektovano.BackgroundImage = null;
            _controller.OdigrajPotez((Point)pd.Tag);
            
        }

        private void BiranjeFigureZaIzbor(object sender, EventArgs e)
        {
            ProvidnoDugme pd = sender as ProvidnoDugme;
            if (pd.Posecivano) return;
            if (_selektovano.BackgroundImage != null) return;
            _selektovano.BackgroundImage = _figureZaIzbor[int.Parse(pd.Tag as string)].BackgroundImage;
            pd.Posecivano = true;
            pd.BackgroundImage = null;
            _controller.Selektuj(int.Parse(pd.Tag.ToString()));
        }

        #region Dugmici za meni
        private void btnIgrajOpet_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Button).BackgroundImage = Properties.Resources.dugme1Pr;
        }

        private void btnGlavniMeni_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Button).BackgroundImage = Properties.Resources.dugme2Pr;
        }

        private void btnIgrajOpet_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Button).BackgroundImage = Properties.Resources.dugme1;
        }

        private void btnGlavniMeni_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Button).BackgroundImage = Properties.Resources.dugme2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        private void FormIgra_Load(object sender, System.EventArgs e)
        {
            lblPoruka.Text = "Na potezu je: prvi igrač";
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
            
            _controller.NovaIgra();
        }

        private void ObrisiSve()
        {
            if (_figureZaIzbor == null) return;
            if (_tabla == null) return;
            if (_selektovano == null) return;
            foreach (var providnoDugme in _figureZaIzbor)
            {
                this.Controls.Remove(providnoDugme);
            }
            foreach (var providnoDugme in _tabla)
            {
                this.Controls.Remove(providnoDugme);
            }

            this.Controls.Remove(_selektovano);
        }
        private void btnIgrajOpet_Click(object sender, EventArgs e)
        {
            _controller.NovaIgra();
        }

        public void AzurirajPoruku(int indeks)
        {
            lblPoruka.Text = "Na potezu je: " + _igraci[indeks];
        }

        private void meniDugme_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor1.Handle);
        }

        private void meniDugme_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
        }


        #region Clanice Interfejsa
        public void Iscrtaj()
        {
            ObrisiSve();
            PostaviElemente();
        }
        public void AddListener(Controller.IController cont)
        {
            _controller = cont;
        }
        public void Pobeda()
        {
            lblPoruka.Text = "Pobedio je: " + _igraci[_controller.Pobednik()];
            _controller.Pobeda();
            foreach (var providnoDugme in _figureZaIzbor)
            {
                providnoDugme.Click -= BiranjeFigureZaIzbor;
                providnoDugme.MouseEnter -= figureMouseEnter;
            }            
        }

        public void AzurirajRezultat()
        {
            lblPrviIgrac.Text = _controller.BrojPobeda(2).ToString();
            lblDrugiIgrac.Text = _controller.BrojPobeda(1).ToString();
        }
        #endregion


        public ProvidnoDugme[,] Tabla
        {
            get
            {
                return _tabla;
            }
        }

        public void Nereseno()
        {
            MessageBox.Show("NEREŠENO");
        }

        public void PrikaziPotez(Potez p)
        {
            if (_tabla[p.Pozicija.X, p.Pozicija.Y].BackgroundImage != null)
            {
                return;
            }
            _tabla[p.Pozicija.X, p.Pozicija.Y].BackgroundImage = p.PostavljenaFigura.Slika;
            _tabla[p.Pozicija.X, p.Pozicija.Y].Posecivano = true;
            ProvidnoDugme pd = DajDugmePoSlici(p.PostavljenaFigura.Slika); //figura za izbor
            if (pd != null) {
                pd.Posecivano = true;
                pd.BackgroundImage = null;
                _selektovano.BackgroundImage = null;
            }
        }

        private ProvidnoDugme DajDugmePoSlici(Image img)
        {
            foreach (var providnoDugme in _figureZaIzbor)
            {
                if (providnoDugme.BackgroundImage == img) return providnoDugme;
            }
            return null;
        }


        public void SakrijLabelu()
        {
            lblPoruka.Visible = false;
        }

        public void PrikaziLabelu()
        {
            lblPoruka.Visible = true;
        }

    }
}