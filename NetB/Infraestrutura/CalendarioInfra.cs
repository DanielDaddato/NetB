using NetB.Models;
using NetB.Models.DTO;
using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Infraestrutura
{
    public class CalendarioInfra
    {
        public async Task<List<Evento>>BuscaEventos()
        {
            var tarefas = await new TarefasRepositorio().BuscaTarefasCalendario();
            var eventos = new List<Evento>();
            tarefas.ForEach(x =>
                {
                    eventos.Add(new Evento
                    {
                        id = x.id,
                        title = x.title,
                        projeto = x.projeto,
                        responsavel = x.responsavel,
                        start = x.start.Value.ToString("yyyy-MM-dd"),
                        end = x.end.Value.ToString("yyyy-MM-dd"),
                        descricao = x.descricao,
                        color = retornaStatus(x.end.Value)
                });

            });

            //eventos.Add(new Evento
            //{
            //    id = 293,
            //    title = "This is warning",
            //    start = "2016-10-10",
            //    end = "2016-10-12",
            //    descricao = "teste de tarefa",
            //    projeto = "teste",
            //    responsavel = "daniel",
            //    color = "yellow"
            //});
           return eventos;
        }

        public string retornaStatus(DateTime previsao)
        {
            if (previsao.Date == DateTime.Now.Date)
            {
                return "Yellow";
            }
            else if (previsao.Date < DateTime.Now.Date)
            {
                return "Red";
            }
            else
            {
                return "Green";
            }

        }

        public async Task<int> AtualizaTarefa(TarefaCalendarioDTO tarefaDTO)
        {
            var repositorio = new TarefasRepositorio();           
            return await repositorio.AtualizaTarefa(tarefaDTO);
        }
    }
}
