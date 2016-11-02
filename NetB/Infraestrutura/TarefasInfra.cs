using NetB.Models.DTO;
using NetB.Repositorios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetB.Models;

namespace NetB.Infraestrutura
{
    public class TarefasInfra
    {
        public async Task<Dictionary<string, List<TarefasResponsavelDTO>>> BuscaTarefasPorUsuario()
        {
            var responsaveis = await new ResponsavelRepositorio().BuscaResponsaveis();
            var tarefas = await new TarefasRepositorio().BuscarTodasTarefas();
            foreach (var item in tarefas)
            {
                if (item.Conclusao != null)
                {
                    item.statusCor = "Green";
                }
                else if (item.Previsao.Value < DateTime.Now)
                {
                    item.statusCor = "Red";
                }
                else if (item.Previsao.Value >= DateTime.Now.AddDays(-5) && item.Previsao.Value <= DateTime.Now)
                {
                    item.statusCor = "Yellow";
                }
                else
                {
                    item.statusCor = "Blue";
                }
            }
            Dictionary<string, List<TarefasResponsavelDTO>> ListaTarefas = new Dictionary<string, List<TarefasResponsavelDTO>>();
            foreach (var item in responsaveis)
            {
                var tar = tarefas.Where(x => x.responsavel_id == item.id).Select(x => x).ToList();
                ListaTarefas.Add(item.nome,tar);
            }
            return ListaTarefas;
        }
    }
}
