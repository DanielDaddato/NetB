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
    public class DepartamentoRepositorio
    {
        public async Task<IEnumerable<Departamentos>> BuscaDepartamentos()
        {
            using (NetBContext netbContext = new NetBContext())
            {
                return await netbContext.Departamentos.ToListAsync();
            }

        } 
    }
}
