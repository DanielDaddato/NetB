using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models
{
    public class GraficoGeralDataset
    {
        public string Nome { get; set; }
        public List<int?> Estimado { get; set; } = new List<int?>();
        public List<int?> Realizado { get; set; } = new List<int?>();
        public string Cor { get; set; }
    }
}
