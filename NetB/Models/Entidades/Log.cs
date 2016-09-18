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
        public int Id { get; set; }
        [ForeignKey("Id")]
        public Usuarios Usuarios_Id { get; set; }
        public DateTime Login { get; set; }
        public DateTime Logout { get; set; }
    }
}
