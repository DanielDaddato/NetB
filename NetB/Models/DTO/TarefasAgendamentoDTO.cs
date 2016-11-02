using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.DTO
{
    public class TarefasAgendamentoDTO
    {
            public int id { get; set; }
            public string projeto { get; set; }
            public string responsavel_email { get; set; }
            public string nome { get; set; }
            public string descricao { get; set; }
            public DateTime? previsao { get; set; }
            public string observacoes { get; set; }
            public List<string> lstEmailUsuarios { get; set; }
    }
}
