using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetB.Models.Entidades;
using System.Data.Entity;

namespace NetB.Repositorios
{
    public class ResponsavelRepositorio
    {
        public async Task<IEnumerable<Responsavel>> BuscaResponsaveis()
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Responsavel.ToListAsync();
            }
        }
    }
}
