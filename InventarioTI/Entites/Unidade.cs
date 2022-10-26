using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Entites
{
    public class Unidade
    {
        [Key]
        public int ID_U { get; set; }
        public string Regiao { get; set; }
        public string Uf { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

    }
}
