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
                        end = x.end.Value.ToString("yyyy-MM-dd 18:00:00"),
                        descricao = x.descricao,
                        color = retornaStatus(x.end.Value),
                        textColor = "black"                        
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
            if (DateTime.Now.Date <= previsao.Date  && previsao.Date >= DateTime.Now.AddDays(-7))
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
            var resposta = await repositorio.AtualizaTarefa(tarefaDTO);
            if (resposta > 0)
                await EnviaEmailJustificativa(tarefaDTO);
            return resposta;
        }

        private async Task EnviaEmailJustificativa(TarefaCalendarioDTO tarefaDTO)
        {
            var responsavel = await new ResponsavelRepositorio().BuscaEmailResponsaveis(tarefaDTO.responsavel_id);
            var lstEmailUsuarios = await new UsuariosRepositorio().BuscaUsuarioTarefa(tarefaDTO.id);
            var assunto = string.Format("Data de Previsão Alterada - {0} - {1} ", tarefaDTO.nome, tarefaDTO.projeto);
            var corpo = string.Empty;

            corpo = new StringBuilder().Append("Data de previsão alterada para :"+ tarefaDTO.previsao)
            .AppendLine("Tarefa: " + tarefaDTO.nome)
            .AppendLine("Projeto: " + tarefaDTO.projeto)
            .AppendLine("Responsavel"+ responsavel.nome)
            .AppendLine("-------------------------------------------------------------------------------------")
            .AppendLine()
            .AppendLine("JUSTIFICATIVA")
            .AppendLine()
            .AppendLine(tarefaDTO.justificativa).ToString();
            await new Email().EnviarEmail( responsavel.email , lstEmailUsuarios, assunto, corpo);

        }
    }
}
