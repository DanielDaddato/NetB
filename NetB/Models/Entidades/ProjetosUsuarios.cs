using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.Entidades
{
    public class ProjetosUsuarios
    {
        [ForeignKey("Id")]
        public Projetos Projetos_Id { get; set; }
        [ForeignKey("Id")]
        public Usuarios Usuarios_Id { get; set; }
    }
}
