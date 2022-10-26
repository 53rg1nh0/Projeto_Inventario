using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Entites
{
    public class Movimetacao
    {
        [Key]
        public int ID_M { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public int FK_ID_C { get; set; }
        public int FK_ID_E { get; set; }
        public int Chamado { get; set; }
    }
}
