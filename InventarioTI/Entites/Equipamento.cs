using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Entites
{
    public class Equipamento
    {
        [Key]
        public int ID_E { get; set; }
        public string Patrimonio { get; set; }
        public string Tipo { get; set; }
        public string Serie { get; set; }
        public string Nomenclatura { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Processador { get; set; }
        public string Ram { get; set; }
        public string Disco { get; set; }
        public string Status { get; set; }
        public int FK_ID_U { get; set; }
        public int? FK_ID_C { get; set; }
    }
}
