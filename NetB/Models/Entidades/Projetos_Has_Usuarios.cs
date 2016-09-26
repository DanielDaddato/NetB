using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.Entidades
{
    public class Projetos_Has_Usuarios
    {
        public int id { get; set; }
        public int projetos_id { get; set; }
        public int usuarios_id { get; set; }
    }
}
