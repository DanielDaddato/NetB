using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.DTO
{
    public class TarefasUsuariosDTO
    {
        public string Tarefa { get; set; }
        public string Projeto { get; set; }
        public DateTime? Previsao { get; set; }
        public string Observacoes { get; set; }
        public int UsuarioId { get; set; }
    }
}
