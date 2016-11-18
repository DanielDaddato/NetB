using NetB.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Repositorios
{
    public class LogRepositorio
    {
        public async Task<int> RegistrarLogin(int IdUsuario)
        {
            using (NetBContext netBContext = new NetBContext())
            {
               var registro = new Log
               {
                   usuarios_id = IdUsuario,
                   login = DateTime.Now
               };
                var id = netBContext.Log.Add(registro);
                await netBContext.SaveChangesAsync();
                return registro.id;
            }
        }

        public async Task<int> RegistrarLogout(int idLog)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                var registro = await netBContext.Log.Where(x => x.id == idLog).FirstOrDefaultAsync();
                registro.logout = DateTime.Now;
                return await netBContext.SaveChangesAsync();
            }
        }
    }
}
