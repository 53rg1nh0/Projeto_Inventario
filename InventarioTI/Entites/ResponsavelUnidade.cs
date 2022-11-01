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
        public int ID_R { get; set; }
        public Responsavel Responsavel { get; set; }

        public int ID_U { get; set; }
        public Unidade Unidade { get; set; }
    }
}
