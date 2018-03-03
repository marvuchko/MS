using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSQuarto.Controller;
using MSQuarto.Model;

namespace MSQuarto.View
{
    public interface IView
    {
        void Iscrtaj();
        void AddListener(IController cont);
        void Pobeda();
        void AzurirajPoruku(int indeks);
        void AzurirajRezultat();
        ProvidnoDugme[,] Tabla { get; }
        void PrikaziPotez(Potez p);
        void Nereseno();
    }
}
