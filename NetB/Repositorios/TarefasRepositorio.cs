using NetB.Models;
using NetB.Models.DTO;
using NetB.Models.Entidades;
using System;
using System.Data.Entity.SqlServer;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
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
                    (join2, usuarios) => new { join2, usuarios }).
                    Join(netBContext.Responsavel,
                    join3 => join3.join2.join.tarefas.responsavel_id,
                    responsavel => responsavel.id,
                    (join3, responsavel) => new {join3, responsavel })
                    .Where(x => x.join3.usuarios.id == idUsuario && x.join3.join2.join.projetos.status == true)
                    .Select(x => new TarefasDTO
                    {
                        nome = x.join3.join2.join.tarefas.nome,
                        projeto = x.join3.join2.join.projetos.nome,
                        observacoes = x.join3.join2.join.tarefas.observacoes,
                        previsao = x.join3.join2.join.tarefas.previsao,
                        descricao = x.join3.join2.join.tarefas.descricao,
                        inicio  = x.join3.join2.join.tarefas.inicio,
                        conclusao = x.join3.join2.join.tarefas.conclusao,
                        responsavel_id = x.responsavel.nome,
                        dias_estimados = x.join3.join2.join.tarefas.dias_estimados,
                        dias_trabalhados = x.join3.join2.join.tarefas.dias_trabalhados,
                        valor_estimado = x.join3.join2.join.tarefas.valor_estimado,
                        valor_utilizado = x.join3.join2.join.tarefas.valor_utilizado,
                    }).ToListAsync();
            };
        }

        public async Task<Tarefas> BuscaTarefa(int id)
        {
            using (NetBContext netbContext = new NetBContext())
            {
                return await netbContext.Tarefas.Where(x => x.id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<int> AtualizaTarefas(List<Tarefas> listaTarefas)
        {
            using (NetBContext netbContext = new NetBContext())
            {
                listaTarefas.ForEach(async x => 
                {
                    var tarefa = await netbContext.Tarefas.Where(t => t.id == x.id).FirstOrDefaultAsync();
                    tarefa.previsao = x.previsao;
                    tarefa.dias_estimados = x.dias_estimados;
                    tarefa.valor_estimado = x.valor_estimado; 
                });
                return await netbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Tarefas>> ListaTarefasProjeto(int idProjeto)
        {
            using (NetBContext netbContext = new NetBContext())
            {
                return await netbContext.Tarefas.Where(x => x.projetos_id == idProjeto).ToListAsync();
            }
        }

        public async Task<List<GraficoDataSet>> BuscaHorasTarefas( int idProjeto)
        {
            try
            {
                using (NetBContext netbContext = new NetBContext())
                {
                    return await netbContext.Tarefas
                     .Join(netbContext.Projetos,
                     tarefa => tarefa.projetos_id,
                     projeto => projeto.id,
                     (tarefa, projeto) => new { tarefa, projeto })
                     .Where(x => x.projeto.id == idProjeto)
                     .Select(x => new GraficoDataSet
                     {
                         Nome = x.tarefa.nome,
                         Estimado = x.tarefa.dias_estimados,
                         Real = x.tarefa.dias_trabalhados

                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public async Task<List<GraficoDataSet>> BuscaCustoTarefas(int idProjeto)
        {
            try
            {
                using (NetBContext netbContext = new NetBContext())
                {
                    return await netbContext.Tarefas
                     .Join(netbContext.Projetos,
                     tarefa => tarefa.projetos_id,
                     projeto => projeto.id,
                     (tarefa, projeto) => new { tarefa, projeto })
                     .Where(x => x.projeto.id == idProjeto)
                     .Select(x => new GraficoDataSet
                     {
                         Nome = x.tarefa.nome,
                         Estimado = x.tarefa.valor_estimado,
                         Real = x.tarefa.valor_utilizado
                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }


        public async Task<IEnumerable<TarefasResponsavelDTO>> BuscarTodasTarefas()
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
                    .Select(x => new TarefasResponsavelDTO
                    {
                        Tarefa = x.join.tarefas.nome,
                        Projeto = x.projetos.nome,
                        Inicio = x.join.tarefas.inicio,
                        Previsao = x.join.tarefas.previsao,
                        Conclusao = x.join.tarefas.conclusao,
                        Observacoes = x.join.tarefas.observacoes,
                        responsavel_id = x.join.responsavel.id
                    }).ToListAsync();

            };
        }

        public async Task<IEnumerable<Tarefas>> BuscarTodasTarefasOrdenadoPorPrevisao()
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Tarefas.OrderBy(x => x.previsao).ToListAsync();
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

        public async Task<IEnumerable<TarefasProjetoDTO>> TarefasPorProjeto(int idProjeto)
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
                    .Select(x => new TarefasProjetoDTO
                    {
                        nome = x.join.tarefas.nome,
                        projeto = x.join.projetos.nome,
                        responsavel_id = x.responsavel.nome,
                        inicio = x.join.tarefas.inicio.Value.ToString() ?? "",
                        previsao = x.join.tarefas.previsao.Value.ToString() ?? "",
                        conclusao = x.join.tarefas.conclusao.Value.ToString() ?? "",
                        observacoes = x.join.tarefas.observacoes
                    }).OrderBy(x => x.previsao).OrderBy(x => x.previsao).ToListAsync();
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
                        .Where(x => x.join.tarefas.status == true && x.join.tarefas.conclusao == null)
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
                tarefa.previsao = DateTime.ParseExact(tarefaDTO.previsao, "dd/MM/yyyy",CultureInfo.InvariantCulture);
                tarefa.responsavel_id = tarefaDTO.responsavel_id;
                var justificativa = new Justificativas
                {
                    tarefas_id = tarefaDTO.id,
                    descricao = tarefaDTO.justificativa,
                    data = DateTime.Now
                };
                netBContext.Justificativas.Add(justificativa);
                return await netBContext.SaveChangesAsync();
            }
        }

        public async Task<List<TarefasAgendamentoDTO>> TarefasAgendamento()
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
                    (join2, usuarios) => new { join2, usuarios }).
                    Join(netBContext.Responsavel,
                    join3 => join3.join2.join.tarefas.responsavel_id,
                    responsavel => responsavel.id,
                    (join3, responsavel) => new { join3, responsavel })
                    .Where(x => x.join3.join2.join.tarefas.status == true && x.join3.join2.join.tarefas.conclusao == null && x.join3.join2.join.projetos.status == true)
                    .Select(x => new TarefasAgendamentoDTO
                    {
                        id = x.join3.join2.join.tarefas.id,
                        nome = x.join3.join2.join.tarefas.nome,
                        projeto = x.join3.join2.join.projetos.nome,
                        observacoes = x.join3.join2.join.tarefas.observacoes,
                        previsao = x.join3.join2.join.tarefas.previsao,
                        descricao = x.join3.join2.join.tarefas.descricao,
                        responsavel_email = x.responsavel.email,
                    }).ToListAsync();
            };
        }
        public async Task<int> GravaTarefa(TarefaDTO tarefa)
        {
            using (NetBContext netbContext = new NetBContext())
            {
                var _tarefa = await netbContext.Tarefas.Where(x => x.id == tarefa.id).FirstOrDefaultAsync();
                _tarefa.previsao = DateTime.ParseExact(tarefa.previsao,"dd/MM/yyyy",CultureInfo.InvariantCulture);
                _tarefa.responsavel_id = tarefa.responsavel_id;
                _tarefa.inicio = DateTime.ParseExact(tarefa.inicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                _tarefa.valor_estimado = tarefa.valor_estimado;
                _tarefa.dias_estimados = tarefa.dias_estimados;
                return await netbContext.SaveChangesAsync();
            }
        }

    }
}
