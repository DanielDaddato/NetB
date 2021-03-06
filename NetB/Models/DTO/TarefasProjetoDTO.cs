﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Models.DTO
{
    public class TarefasProjetoDTO
    {
            public int id { get; set; }
            public string projeto { get; set; }
            public string responsavel_id { get; set; }
            public string nome { get; set; }
            public string descricao { get; set; }
            public string inicio { get; set; }
            public string previsao { get; set; }
            public string conclusao { get; set; }
            public string observacoes { get; set; }
            public int dias_estimados { get; set; }
            public int dias_trabalhados { get; set; }
            public int valor_estimado { get; set; }
            public int valor_utilizado { get; set; }
            public string statusCor { get; set; }
    }
}
