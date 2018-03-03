using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MSQuarto.View
{
    public class ProvidnoDugme : Button
    {
        private bool _posecivano;

        public ProvidnoDugme()
        {
            _posecivano = false;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public bool Posecivano
        {
            get
            {
                return _posecivano;
            }
            set
            {
                _posecivano = value;
            }
        }
    }
}
