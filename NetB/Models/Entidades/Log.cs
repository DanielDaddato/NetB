using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.Entidades
{
    public class Log
    {
        public int id { get; set; }
        public int usuarios_id { get; set; }
        public DateTime login { get; set; }
        public DateTime logout { get; set; }
    }
}
