using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models
{
    public class Evento
    {
        public int id { get; set; }
        public string title { get; set; }
        public string descricao { get; set; }
        public string responsavel { get; set; }
        public string projeto { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
    }
}
