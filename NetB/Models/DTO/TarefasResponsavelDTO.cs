using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.DTO
{
    public class TarefasResponsavelDTO
    {
        public string Tarefa { get; set; }
        public string Projeto { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Previsao { get; set; }
        public DateTime? Conclusao { get; set; }
        public string Observacoes { get; set; }
        public int responsavel_id { get; set; }
        public string statusCor { get; set; }
    }
}
