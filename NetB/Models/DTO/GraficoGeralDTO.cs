using NetB.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.DTO
{
    public class GraficoGeralDTO
    {
        public IEnumerable<string> Projetos { get; set; }
        public List<GraficoGeralDataset> ListaDataset { get; set; }
    }
}
