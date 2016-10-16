using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Infraestrutura
{
    public class GraficosInfra
    {
        public async Task<List<int?>> BuscaHoras(int idProjeto)
        {
            var horas = new List<int?>();
            var repositorio = new TarefasRepositorio();
            horas.Add(await repositorio.BuscaHorasEstimadasTarefas(idProjeto));
            horas.Add(await repositorio.BuscaHorasTrabalhadasTarefas(idProjeto));
            return horas;
        }

        public async Task<List<double?>> BuscaCusto(int idProjeto)
        {
            var valores = new List<double?>();
            var repositorio = new TarefasRepositorio();
            var valorHora = await new ProjetosRepositorio().BuscaValorProjeto(idProjeto);
            var valorEstimado = await repositorio.BuscaHorasEstimadasTarefas(idProjeto) * valorHora;
            valores.Add(valorEstimado);
            var valorReal = await repositorio.BuscaHorasTrabalhadasTarefas(idProjeto) * valorHora;
            valores.Add(valorReal);
            return valores;
        }

        public async Task<List<int>> BuscaTarefasProjeto(int idProjeto)
        {
            var contagemTarefas = new List<int>();
            var tarefasRepositorio = new TarefasRepositorio();
            var tarefas = await tarefasRepositorio.TarefasPorProjetoGrafico(idProjeto);
            var tarefasAgendadas = (tarefas.Where(x => x.previsao.Value > DateTime.Now.Date && x.conclusao == null)!= null) ? tarefas.Where(x => x.previsao.Value > DateTime.Now.Date && x.conclusao == null).Count() : 0;
            var tarefasAtrasadas = (tarefas.Where(x => x.previsao.Value < DateTime.Now.Date && x.conclusao == null) != null)? tarefas.Where(x => x.previsao.Value < DateTime.Now.Date && x.conclusao == null).Count() : 0;
            var tarefasConcluidas = (tarefas.Where(x => x.conclusao.Value != null) != null)? tarefas.Where(x => x.conclusao != null).Count() : 0;
            contagemTarefas.Add(tarefasAgendadas);
            contagemTarefas.Add(tarefasAtrasadas);
            contagemTarefas.Add(tarefasConcluidas);
            return contagemTarefas;
        }


    }
}
