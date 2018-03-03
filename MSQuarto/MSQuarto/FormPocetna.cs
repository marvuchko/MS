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
using MSQuarto.Properties;

namespace MSQuarto
{
    public partial class FormPocetna : Form
    {

        System.Resources.ResourceManager RM = new ResourceManager("MSQuarto.Properties.Resources", typeof(Resources).Assembly);
        public FormPocetna()
        {
            InitializeComponent();
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
        }

        private void meniDugme_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Image img = (Image) RM.GetObject(btn.Tag + "Pr");
            btn.BackgroundImage = img;

        }

        private void meniDugme_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Image img = (Image)RM.GetObject(btn.Tag as string);
            btn.BackgroundImage = img;
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNovaIgra_Click(object sender, EventArgs e)
        {
            FormaDijalog fd = new FormaDijalog(this);
            if (fd.ShowDialog() == DialogResult.OK) { 
            
            }
            this.Show();
        }

        private void btnUputstva_Click(object sender, EventArgs e)
        {
            DialogResult res =
                MessageBox.Show("Ova akcija će otvoriti stranicu na wikipediji o igrici \"Quarto\". Da li želite to?",
                    "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.No) return;
            string putanja = @"https://en.wikipedia.org/wiki/Quarto_(board_game)";
            try
            {
                System.Diagnostics.Process.Start(putanja);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nije moguće uspostaviti vezu.",
                    "Greška!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void FormPocetna_Load(object sender, EventArgs e)
        {

        }

        private void meniDugme_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor1.Handle);
        }

        private void meniDugme_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.cursor.Handle);
        }
    }
}