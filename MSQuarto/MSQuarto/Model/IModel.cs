using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSQuarto.Model
{
    public interface IModel
    {
        void ZauzmiPolje(int x, int y);
        Polje DajPolje(int x, int y);
        Figura DajFiguruZaIzbor(int x);
        void PostaviSelektovanu(Figura f);
        Figura DajSelektovanu();
        int BrojSlobodnihPolja();
        void NovaIgra();
        void Pobeda();
        void SledeciIgrac();
        int TrenutniIgrac();
        int PobedeIgracPrvi();
        int PobedeIgracDrugi();
        int Evaluacija();
        IModel Clone();
        Polje[,] DajTablu();
    }
}
