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
        private string _serie;
        private string _nomenclatura;
        private string _modelo;

        [Key]
        public int ID_E { get; set; }
        public int Patrimonio { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Processador { get; set; }
        public string Ram { get; set; }
        public string Disco { get; set; }
        public string Status { get; set; }
        public int FK_ID_U { get; set; }
        public int? FK_ID_C { get; set; }

        public string Nomenclatura 
        {
            get
            {
                return _nomenclatura;
            }
            set
            {
                _nomenclatura = value.ToUpper();
            }
        }
        public string Serie 
        {
            get
            {
                return _serie;
            }
            set
            {
                _serie = value.ToUpper();
            }
        }

        public string Modelo 
        {
            get
            {
                return _modelo;
            }
            set
            {
                _modelo = value.ToUpper();
            }
        }
    }
}
