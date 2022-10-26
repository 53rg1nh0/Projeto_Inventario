using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Entites
{
    public class Cliente
    {
        [Key]
        public int ID_C { get; set; }
        public string UserId { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }
        public int ID_FK_U { get; set; }
    }
}
