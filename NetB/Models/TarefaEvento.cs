using System;
using System.Collections.Generic;
using NetB.Models;

namespace NetB.Repositorios
{
    public class TarefaEvento
    {
        public string descricao { get; set; }
        public DateTime? end { get; set; }
        public int id { get; set; }
        public string projeto { get; set; }
        public string responsavel { get; set; }
        public DateTime? start { get; set; }
        public string title { get; set; }
    }
}