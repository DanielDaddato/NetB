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
        public int Id { get; set; }
        [ForeignKey("Id")]
        public Clientes Clientes_Id { get; set; }
        public string Nome { get; set; }
        public int Endereco { get; set; }
        public int Inicio { get; set; }
        public int Previsão { get; set; }
        public int Conclusao { get; set; }
        public int Preco { get; set; }
        public int Observacoes { get; set; }
        public bool Status { get; set; }
    }
}
