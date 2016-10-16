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
        public async Task<Dictionary<string, List<TarefasUsuariosDTO>>> BuscaTarefasPorUsuario()
        {
            var responsaveis = await new ResponsavelRepositorio().BuscaResponsaveis();
            var tarefas = await new TarefasRepositorio().BuscarTodasTarefas();
            Dictionary<string, List<TarefasUsuariosDTO>> ListaTarefas = new Dictionary<string, List<TarefasUsuariosDTO>>();
            foreach (var item in responsaveis)
            {
                var tar = tarefas.Where(x => x.UsuarioId == item.id).Select(x => x).ToList();
                ListaTarefas.Add(item.nome,tar);
            }
            return ListaTarefas;
        }
    }
}
