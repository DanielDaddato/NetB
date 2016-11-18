﻿using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Infraestrutura
{
    public class Agendamento
    {
        public async Task RoboAgendamento()
        {
            try
            {
                var horaExecução = "08:00:00";
                var tempo = horaExecução.Split(new char[1] { ':' });

                var dataAtual = DateTime.Now;
                var date = new DateTime(dataAtual.Year, dataAtual.Month, dataAtual.Day,
                           int.Parse(tempo[0]), int.Parse(tempo[1]), int.Parse(tempo[2]));
                TimeSpan espera;
                if (date > dataAtual)
                    espera = date - dataAtual;
                else
                {
                    date = date.AddDays(1);
                    espera = date - dataAtual;
                }
                await Task.Delay(espera).ContinueWith(async x =>
                            {
                                await NotificaUsuario();
                            });
            }
            catch (Exception)
            {

            }
            finally
            {
                RoboAgendamento();
            }
        }

        public async Task NotificaUsuario()
        {
            var tarefas = await new TarefasRepositorio().TarefasAgendamento();
            tarefas.ForEach(async x =>
           {
               var assunto = string.Empty;
               var corpo = string.Empty;
               x.lstEmailUsuarios = await new UsuariosRepositorio().BuscaUsuarioTarefa(x.id);
               if(DateTime.Now >= x.previsao.Value.AddDays(- 7) && DateTime.Now <= x.previsao)
               {
                   assunto = string.Format("Tarefa Próxima da Data Limite - {0} - {1} ", x.nome, x.projeto);
                   corpo = new StringBuilder().Append("ATENÇÃO: Tarefa próxima da data limite!")
                   .AppendLine("Tarefa: " + x.nome)
                   .AppendLine("Projeto: " + x.projeto)
                   .AppendLine()
                   .AppendLine()
                   .AppendLine("Esta tarefa está se aproximando da data de previsão!")
                   .AppendLine("Esta é uma mensagem com o intuito de prevenir o atraso na entrega da tarefa!").ToString();
                   await new Email().EnviarEmail(x.responsavel_email, x.lstEmailUsuarios, assunto, corpo);
               }
               else if (DateTime.Now > x.previsao)
               {
                   assunto = string.Format("Tarefa Atrasada! - {0} - {1} ", x.nome, x.projeto);
                   corpo = new StringBuilder().Append("ATENÇÃO: Tarefa está em atraso!")
                   .AppendLine("Tarefa: " + x.nome)
                   .AppendLine("Projeto: " + x.projeto)
                   .AppendLine()
                   .AppendLine()
                   .AppendLine("Esta tarefa está em atraso!")
                   .AppendLine("Por favor dar maxima atenção a esta tarefa!").ToString();
                   await new Email().EnviarEmail(x.responsavel_email, x.lstEmailUsuarios, assunto, corpo);
               }              
           });
        }

    }
}