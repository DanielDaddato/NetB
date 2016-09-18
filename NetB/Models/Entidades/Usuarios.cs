using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.Entidades
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime cadastro { get; set; }
        public int departamento_id { get; set; }
        [ForeignKey("departamento_id")]
        public Departamentos departamentos { get; set; }
        public int permissoes_id { get; set; }
        [ForeignKey("permissoes_id")]
        public Permissoes permissoes { get; set; }
        public bool status { get; set; }
    }
}
