using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Extencions
{
    static class StringExtencion
    {
        public static string Padronizar(this string nome)
        {
            string a;
            string[] aux = nome.ToLower().Trim().Split(" ");

            nome = "";
            foreach (var _nome in aux)
            {
                if (!(_nome == "e" || _nome == "de" || _nome == "da" || _nome == "do"))
                {
                    a = _nome.Substring(0, 1).ToUpper() + _nome.Substring(1);
                }
                else
                {
                    a = _nome;
                }
                nome += a + " ";
            }
            return nome.TrimEnd();
        }
    }
}
