using NetB.Models.DTO;
using NetB.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Repositorios
{
    public class TarefasRepositorio
    {
        public async Task<IEnumerable<TarefasDTO>> TarefasDoUsuario(int idUsuario)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Tarefas
                    .Join(netBContext.TarefasUsuarios,
                    tarefas => tarefas.id,
                    tarefasUsuarios => tarefasUsuarios.tarefas_id,
                    (tarefas, tarefasUsuario) => new { tarefas, tarefasUsuario }
                    )
                    .Join(netBContext.Projetos,
                    join => join.tarefas.projetos_id,
                    projetos => projetos.id,
                    (join, projetos) => new { join, projetos })
                    .Where(x => x.join.tarefas.status == false && x.join.tarefasUsuario.usuarios_id == idUsuario)
                    .Select(x => new TarefasDTO
                    {
                        Tarefa = x.join.tarefas.nome,
                        Projeto = x.projetos.nome,
                        Previsao = x.join.tarefas.previsao,
                        Observacoes = x.join.tarefas.observacoes
                    }).ToListAsync();

            };
        }

        public async Task<IEnumerable<TarefasUsuariosDTO>> BuscarTodasTarefas()
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Tarefas
                    .Join(netBContext.TarefasUsuarios,
                    tarefas => tarefas.id,
                    tarefasUsuarios => tarefasUsuarios.tarefas_id,
                    (tarefas, tarefasUsuario) => new { tarefas, tarefasUsuario }
                    )
                    .Join(netBContext.Projetos,
                    join => join.tarefas.projetos_id,
                    projetos => projetos.id,
                    (join, projetos) => new { join, projetos })
                    .Join(netBContext.Usuarios,
                    join => join.join.tarefasUsuario.usuarios_id,
                    usuario => usuario.id,
                    (join,usuario) => new {join,usuario}).Select(x => new TarefasUsuariosDTO
                    {
                        Tarefa = x.join.join.tarefas.nome,
                        Projeto = x.join.projetos.nome,
                        Previsao = x.join.join.tarefas.previsao,
                        Observacoes = x.join.join.tarefas.observacoes,
                        UsuarioId = x.usuario.id
                    }).ToListAsync();

            };
        }
    }
}
