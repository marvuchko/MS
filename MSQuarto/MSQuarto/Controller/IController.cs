using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSQuarto.Model;

namespace MSQuarto.Controller
{
    public interface IController
    {
        void NovaIgra();
        void OdigrajPotez(Point loc);
        void Selektuj(int indeks);
        IModel MojModel();
        Image DajSliku(int x);
        bool DaLijeNekoPobedio();
        bool KrajIgre();
        void Pobeda();
        int BrojPobeda(int indeks);
        int Pobednik();
    }
}
