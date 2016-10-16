using NetB.Models;
using NetB.Models.DTO;
using NetB.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
                    .Join(netBContext.Projetos,
                    tarefas => tarefas.projetos_id,
                    projetos => projetos.id,
                    (tarefas, projetos) => new { tarefas, projetos })
                    .Join(netBContext.ProjetosUsuarios,
                    join => join.projetos.id,
                    projUser => projUser.projetos_id,
                    (join, projUser) => new { join, projUser })
                    .Join(netBContext.Usuarios,
                    join2 => join2.projUser.usuarios_id,
                    usuarios => usuarios.id,
                    (join2, usuarios) => new { join2, usuarios })
                    .Where(x => x.usuarios.id == idUsuario && x.join2.join.projetos.status == true).Select(x => new TarefasDTO
                    {
                        nome = x.join2.join.tarefas.nome,
                        projeto = x.join2.join.projetos.nome,
                        observacoes = x.join2.join.tarefas.observacoes,
                        previsao = x.join2.join.tarefas.previsao.Value.ToString(),
                        descricao = x.join2.join.tarefas.descricao,
                        inicio  = x.join2.join.tarefas.inicio.Value.ToString()
                    }).ToListAsync();
            };
        }

        public async Task<int?> BuscaHorasEstimadasTarefas( int idProjeto)
        {
            using (NetBContext netbContext = new NetBContext())
            {
              return await netbContext.Tarefas
               .Join(netbContext.Projetos,
               tarefa => tarefa.projetos_id,
               projeto => projeto.id,
               (tarefa, projeto) => new { tarefa, projeto })
               .Where(x => x.projeto.id == idProjeto)
               .Select(x => x).SumAsync(x => x.tarefa.horas_estimadas);
            }    
        }

        public async Task<int?> BuscaHorasTrabalhadasTarefas(int idProjeto)
        {
            using (NetBContext netbContext = new NetBContext())
            {
                return await netbContext.Tarefas
                 .Join(netbContext.Projetos,
                 tarefa => tarefa.projetos_id,
                 projeto => projeto.id,
                 (tarefa, projeto) => new { tarefa, projeto })
                 .Where(x => x.projeto.id == idProjeto)
                 .Select(x => x).SumAsync(x => x.tarefa.horas_trabalhadas);
            }
        }

        public async Task<IEnumerable<TarefasUsuariosDTO>> BuscarTodasTarefas()
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Tarefas
                    .Join(netBContext.Responsavel,
                    tarefas => tarefas.responsavel_id,
                    responsavel => responsavel.id,
                    (tarefas, responsavel) => new { tarefas, responsavel }
                    )
                    .Join(netBContext.Projetos,
                    join => join.tarefas.projetos_id,
                    projetos => projetos.id,
                    (join, projetos) => new { join, projetos })
                    .Select(x => new TarefasUsuariosDTO
                    {
                        Tarefa = x.join.tarefas.nome,
                        Projeto = x.projetos.nome,
                        Previsao = x.join.tarefas.previsao,
                        Observacoes = x.join.tarefas.observacoes,
                        UsuarioId = x.join.responsavel.id
                    }).ToListAsync();

            };
        }

        public async Task<TarefaCalendarioDTO> BuscaTarefaDetalhe(int idTarefa)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Tarefas
                    .Join(netBContext.Responsavel,
                    tarefas => tarefas.responsavel_id,
                    responsavel => responsavel.id,
                    (tarefas, responsavel) => new { tarefas, responsavel }
                    )
                    .Join(netBContext.Projetos,
                    join => join.tarefas.projetos_id,
                    projetos => projetos.id,
                    (join, projetos) => new { join, projetos })
                    .Where(x => x.join.tarefas.id == idTarefa && x.join.tarefas.status == true)
                    .Select(x => new TarefaCalendarioDTO
                    {
                        id = x.join.tarefas.id,
                        nome = x.join.tarefas.nome,
                        descricao = x.join.tarefas.descricao,
                        projeto = x.projetos.nome,
                        previsao = x.join.tarefas.previsao.ToString(),
                        observacoes = x.join.tarefas.observacoes,
                        responsavel_id = x.join.responsavel.id
                    }).FirstOrDefaultAsync();
            };
        }

        public async Task<IEnumerable<TarefasDTO>> TarefasPorProjeto(int idProjeto)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Tarefas
                    .Join(netBContext.Projetos,
                    tarefas => tarefas.projetos_id,
                    projetos => projetos.id,
                    (tarefas, projetos) => new { tarefas, projetos })
                    .Join(netBContext.Responsavel,
                    join => join.tarefas.responsavel_id,
                    responsavel => responsavel.id,
                    (join, responsavel) => new { join, responsavel })
                    .Where(x => x.join.projetos.id == idProjeto && x.join.tarefas.status == true)
                    .Select(x => new TarefasDTO
                    {
                        nome = x.join.tarefas.nome,
                        projeto = x.join.projetos.nome,
                        previsao = x.join.tarefas.previsao.ToString(),
                        observacoes = x.join.tarefas.observacoes
                    }).ToListAsync();
            };
        }

        public async Task<IEnumerable<Tarefas>> TarefasPorProjetoGrafico(int idProjeto)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Tarefas
                    .Where(x => x.projetos_id == idProjeto && x.status == true)
                    .Select(x => x).ToListAsync();
            };
        }
        public async Task<List<TarefaEvento>> BuscaTarefasCalendario()
        {
            using (NetBContext netBContext = new NetBContext())
            {
                try
                {
                    return await netBContext.Tarefas
                        .Join(netBContext.Responsavel,
                        tarefas => tarefas.responsavel_id,
                        responsavel => responsavel.id,
                        (tarefas, responsavel) => new { tarefas, responsavel }
                        )
                        .Join(netBContext.Projetos,
                        join => join.tarefas.projetos_id,
                        projetos => projetos.id,
                        (join, projetos) => new { join, projetos })
                        .Select(x => new TarefaEvento
                        {
                            id = x.join.tarefas.id,
                            title = x.join.tarefas.nome,
                            projeto = x.projetos.nome,
                            start = x.join.tarefas.inicio,
                            end = x.join.tarefas.previsao,
                            descricao = x.join.tarefas.observacoes,
                            responsavel = x.join.responsavel.nome,
                        }).ToListAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            };
        }

        public async Task<int> AtualizaTarefa(TarefaCalendarioDTO tarefaDTO)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                var tarefa = await netBContext.Tarefas.Where(x => x.id == tarefaDTO.id).Select(x => x).FirstOrDefaultAsync();
                tarefa.previsao = Convert.ToDateTime(tarefaDTO.previsao, CultureInfo.CurrentCulture);
                tarefa.responsavel_id = tarefaDTO.responsavel_id;
                return await netBContext.SaveChangesAsync();
            }
        }
            
    }
}
