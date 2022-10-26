using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Entites
{
    public class ResponsavelUnidade
    {
        
        public int FK_ID_C { get; set; }
 
        public int FK_ID_U { get; set; }

        [Key]
        public int ChaveEF { get; set; }
    }
}
