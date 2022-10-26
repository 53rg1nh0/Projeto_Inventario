using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Entites
{
    public class Responsavel
    {
        [Key]
        public int ID_R { get; set; }
        public string TelefoneCOrporativo { get; set; }
        public string TelefoneSecundario { get; set; }
        public string Email { get; set; }
        public int Nivel { get; set; }
        public string Senha { get; set; }
    }
}
