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
        public int clientes_id { get; set; }
        public string nome { get; set; }
        public int endereco { get; set; }
        public int inicio { get; set; }
        public int previsao { get; set; }
        public int conclusao { get; set; }
        public int preco { get; set; }
        public int observacoes { get; set; }
        public bool status { get; set; }
    }
}
