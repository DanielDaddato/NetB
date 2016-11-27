using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models
{
    public class TarefaDTO
    {
        public int id { get; set; }
        public int responsavel_id { get; set; }
        public string inicio { get; set; }
        public string previsao { get; set; }
        public int dias_estimados { get; set; }
        public double valor_estimado { get; set; }
    }
}
