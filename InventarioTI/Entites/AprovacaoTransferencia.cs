using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Entites
{
    public class AprovacaoTransferencia
    {
        [Key]
        public int ID_A { get; set; }
        public Responsavel Responsavel { get; set; }
        public Equipamento Equipamento { get; set; }
        public string UnidadeDestino { get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataAprovacao { get; set; }
        public string ResponsavelAprovacao { get; set; }
    }
}
