using NetB.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Repositorios
{
    public class UsuariosRepositorio
    {
        private readonly NetBContext _netBContext = new NetBContext();
        public IEnumerable<Usuarios> Usuarios
        {
            get { return _netBContext.Usuarios; }
        }
    }
}
