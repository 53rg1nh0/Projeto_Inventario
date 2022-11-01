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
        public Cliente Cliente { get; set; }
        public Equipamento Equipamento { get; set; }
        public Unidade Unidade { get; set; }
        public Responsavel Responsavel { get; set; }
        public int? Chamado { get; set; }
    }
}
