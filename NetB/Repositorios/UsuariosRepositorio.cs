using NetB.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NetB.Repositorios
{
    public class UsuariosRepositorio
    { 
        public async Task<IEnumerable<Usuarios>> PegarUsuarios()
        {
            using (NetBContext netBContext = new NetBContext())
            {
                
                var usuarios = netBContext.Usuarios.Include("departamentos").Include("permissoes");
              return await usuarios.ToListAsync();
            };
        }

        public async Task<Usuarios> PegarUsuario(string login)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Usuarios.Include("departamentos").Include("permissoes").Where(x => x.email == login).Select(x => x).FirstOrDefaultAsync();
            };
        }
    }
        
}
