using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.DTO
{
    public class TarefasDTO
    {
        public int id { get; set; }
        public string projeto { get; set; }
        public int responsavel_id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string inicio { get; set; }
        public string previsao { get; set; }
        public string observacoes { get; set; }
    }
}
