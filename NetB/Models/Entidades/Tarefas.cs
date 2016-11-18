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
        public int id { get; set; }
        public string pm_tarefa { get; set; }
        public int projetos_id { get; set; }
        public int responsavel_id { get; set; }
        public int? seq_tarefa { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime? inicio { get; set; }
        public DateTime? previsao { get; set; }
        public DateTime? conclusao { get; set; }
        public string observacoes { get; set; }
        public int dias_estimados { get; set; }
        public int dias_trabalhados { get; set; }
        public int valor_estimado { get; set; }
        public int valor_utilizado { get; set; }
        public bool status { get; set; }
    }
}
