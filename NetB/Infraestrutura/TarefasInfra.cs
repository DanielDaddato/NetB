using NetB.Models.DTO;
using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Infraestrutura
{
    public class TarefasInfra
    {
        public async Task<Dictionary<string, List<TarefasUsuariosDTO>>> BuscaTarefasPorUsuario()
        {
            var usuarios = await new UsuariosRepositorio().PegarUsuarios();
            var tarefas = await new TarefasRepositorio().BuscarTodasTarefas();
            Dictionary<string, List<TarefasUsuariosDTO>> ListaTarefas = new Dictionary<string, List<TarefasUsuariosDTO>>();
            foreach (var usuario in usuarios)
            {
                var tar = tarefas.Where(x => x.UsuarioId == usuario.id).Select(x => x).ToList();
                ListaTarefas.Add(usuario.nome,tar);
            }
            return ListaTarefas;
        }
    }
}
