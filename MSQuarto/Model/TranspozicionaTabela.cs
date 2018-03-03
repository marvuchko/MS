using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSQuarto.Model
{
    public static class TranspozicionaTabela
    {
        public static Dictionary<string, Unos> _tranpozicionaTabela = new Dictionary<string, Unos>();
        public static IModel Model { get; set; }
        public static string Hash(int[,] polje)
        {
            string kljuc = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string tmp = (polje[i, j]).ToString().PadLeft(2, '0');
                    kljuc += tmp;
                }
            }

            return kljuc;
        }

        public static void DodajUnos(string kljuc, Unos unos)
        {
            _tranpozicionaTabela.Add(kljuc, unos);
        }

        public static Unos DajUnos(string kljuc)
        {
            Unos unos;
            _tranpozicionaTabela.TryGetValue(kljuc, out unos);
            return unos;
        }


    }
}
