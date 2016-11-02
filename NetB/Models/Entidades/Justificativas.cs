using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.Entidades
{
    public class Justificativas
    {
        public int id { get; set; }
        public int tarefas_id { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
    }
}
