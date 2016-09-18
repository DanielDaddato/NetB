using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.Entidades
{
    public class TarefasUsuarios
    {
        [ForeignKey("Id")]
        public Tarefas Tarefas_Id { get; set; }
        [ForeignKey("Id")]
        public Usuarios Usuarios_Id { get; set; }
    }
}
