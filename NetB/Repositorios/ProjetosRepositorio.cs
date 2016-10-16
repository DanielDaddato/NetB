using NetB.Models.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NetB.Repositorios
{
    public class ProjetosRepositorio
    {
        public async Task<IEnumerable<Projetos>> BuscaProjetos()
        {
            using (NetBContext netBContext = new NetBContext())
            {
                try
                {
                    return await netBContext.Projetos.ToListAsync();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return null;
                }
            }
        }


        public async Task<double> BuscaValorProjeto(int idProjeto)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Projetos.Where(x => x.id == idProjeto)
                    .Select(x => x.orcamento).FirstOrDefaultAsync();
            }
        }
    }
}
