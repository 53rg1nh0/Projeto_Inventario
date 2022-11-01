using InventarioTI.Extencions;
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
        private string _userId;
        private string _nome;

        [Key]
        public int ID_C { get; set; }
        public int? Matricula { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }
        public ICollection<Equipamento> Equipamentos { get; set; }
        public ICollection<Movimetacao> Movimetacoes { get; set; }

        public string UserId 
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value.ToLower();
            }
        }

        public string Nome 
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value.Padronizar();
            }
        }
    }
}
