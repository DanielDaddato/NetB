using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.Entidades
{
    public class Tarefas
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public Projetos Projetos_Id { get; set; }
        public string Nome { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Previsão { get; set; }
        public DateTime Conclusao { get; set; }
        public string Observacoes { get; set; }
        public bool Status { get; set; }
    }
}
