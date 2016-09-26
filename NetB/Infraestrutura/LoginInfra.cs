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
    public class LoginInfra
    {
        public async Task<Usuarios> ValidaLogin(LoginDTO login)
        {
            return await new UsuariosRepositorio().PegarUsuario(login.Email);
        }
    }
}
