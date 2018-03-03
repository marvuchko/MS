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

namespace MSQuarto
{
    public partial class FormaDijalog : Form
    {
        FormPocetna RoditeljForma { set; get; }

        System.Resources.ResourceManager RM = new ResourceManager("MSQuarto.Properties.Resources", typeof(Resources).Assembly);

        public FormaDijalog(FormPocetna f)
        {
            InitializeComponent();
            RoditeljForma = f;
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
        }

        private void dijalogDugmiciMouseEnter(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor1.Handle);
        }

        private void dijalogDugmiciMouseLeave(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
        }

        private void dijalogDugmiciMouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Image img = (Image)RM.GetObject(btn.Tag.ToString() + "Pr");
            btn.BackgroundImage = img;
        }

        private void dijalogDugmiciMouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Image img = (Image)RM.GetObject(btn.Tag.ToString());
            btn.BackgroundImage = img;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radioMouseEnter(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor1.Handle);
        }

        private void radioMouseLeave(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
        }

        private void FormaDijalogLoad(object sender, EventArgs e)
        {
            rbDrugi.Checked = true;
        }

        private void btnPrihvati_Click(object sender, EventArgs e)
        {
            FormIgra fi = new FormIgra(this);
            IModel model = new Model.Model();
            IController ctrl2 = new ControllerDvaIgraca(model,fi);
            IController ctrl1 = new ControllerJedanIgrac(model,fi);

            fi.AddListener(rbDrugi.Checked ? ctrl2 : ctrl1);

            RoditeljForma.Hide();
            this.Hide();
            this.DialogResult = fi.ShowDialog();
            this.Close();
        }
    }
}
