using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.Entidades
{
    public class Projetos
    {
        public int id { get; set; }
        public string pm_projeto { get; set; }
        public int clientes_id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public DateTime? inicio { get; set; }
        public DateTime? previsao { get; set; }
        public DateTime? conclusao { get; set; }
        public int? horas_estimadas { get; set; }
        public int? horas_trabalhadas { get; set; }
        public double orcamento { get; set; }
        public string observacoes { get; set; }
        public bool status { get; set; }
    }
}
