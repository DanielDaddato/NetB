using NetB.Models;
using NetB.Models.DTO;
using NetB.Models.Entidades;
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
        public async Task<List<GraficoDataSet>> BuscaHoras(int idProjeto)
        {
            var Lista = new List<List<int?>>();
            var repositorio = new TarefasRepositorio();
            var horas = await repositorio.BuscaHorasTarefas(idProjeto);
            for (int i = 0; i < horas.Count; i++)
            {
                horas[i].Cor = listaCores[i];
            }
            return horas;
        }
        List<string> listaCores = new List<string>
        {
                "rgba(255, 99, 132, 0.2)",
                "rgba(54, 162, 235, 0.2)",
                "rgba(255, 206, 86, 0.2)",
                "rgba(75, 192, 192, 0.2)",
                "rgba(153, 102, 255, 0.2)",
                "rgba(255, 159, 64, 0.2)",
                "rgba(255, 99, 132, 0.2)",
                "rgba(54, 162, 235, 0.2)",
                "rgba(255, 206, 86, 0.2)",
                "rgba(75, 192, 192, 0.2)",
                "rgba(153, 102, 255, 0.2)",
                "rgba(255, 159, 64, 0.2)",
                "rgba(255, 99, 132, 0.2)",
                "rgba(54, 162, 235, 0.2)",
                "rgba(255, 206, 86, 0.2)",
                "rgba(75, 192, 192, 0.2)",
                "rgba(153, 102, 255, 0.2)",
                "rgba(255, 159, 64, 0.2)",
                "rgba(255, 99, 132, 0.2)",
                "rgba(54, 162, 235, 0.2)",
                "rgba(255, 206, 86, 0.2)",
                "rgba(75, 192, 192, 0.2)",
                "rgba(153, 102, 255, 0.2)",
                "rgba(255, 159, 64, 0.2)",

        };
        public async Task<List<GraficoDataSet>> BuscaCusto(int idProjeto)
        {
            var valores = new List<double?>();
            var repositorio = new TarefasRepositorio();
            var custo = await repositorio.BuscaCustoTarefas(idProjeto);
            for (int i = 0; i < custo.Count; i++)
            {
                custo[i].Cor = listaCores[i];
            }
            return custo;
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

        public async Task<GraficoGeralDTO> BuscaHorasGeral()
        {
            var listaDataset = new List<GraficoGeralDataset>();
            var projetos = await new ProjetosRepositorio().BuscaProjetos();
            List<List<Tarefas>> projetoTarefas = new List<List<Tarefas>>();
            var tarefas = await new TarefasRepositorio().BuscarTodasTarefasOrdenadoPorPrevisao();
            var listaProjetos = new List<string>();
            foreach (var item in projetos)
            {
                listaProjetos.Add(item.nome);
                projetoTarefas.Add(tarefas.Where(x => x.projetos_id == item.id).OrderBy(x => x.previsao).ToList());
            }
           
            for (int i = 0; i <= 17; i++)
            {
                var graficoGeralDataset = new GraficoGeralDataset();
                
                foreach (var item in projetoTarefas)
                {
                    
                    if (item.Count > i)
                    {
                        graficoGeralDataset.Nome = item[i].nome ?? "";
                        graficoGeralDataset.Estimado.Add(item[i].dias_estimados);
                        graficoGeralDataset.Realizado.Add(item[i].dias_trabalhados);
                    }
                    else
                    {
                        graficoGeralDataset.Nome = "";
                        graficoGeralDataset.Estimado.Add(0);
                        graficoGeralDataset.Realizado.Add(0);
                    }
                }
                
                graficoGeralDataset.Cor = listaCores[i];
                listaDataset.Add(graficoGeralDataset);
            }

            return new GraficoGeralDTO { Projetos = listaProjetos, ListaDataset = listaDataset };
        }
    }
}
