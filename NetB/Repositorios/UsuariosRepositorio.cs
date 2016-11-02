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
                
                var usuarios = netBContext.Usuarios;
              return await usuarios.ToListAsync();
            };
        }

        public async Task<Usuarios> PegarUsuario(string login)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Usuarios.Where(x => x.email == login).Select(x => x).FirstOrDefaultAsync();
            };
        }

        public async Task<Usuarios> BuscaUsuario(int id)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Usuarios.Where(x => x.id == id).Select(x => x).FirstOrDefaultAsync();
            };
        }

        public async Task<int> AdicionarUsuario(Usuarios usuario)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                usuario.data_cadastro = DateTime.Now;
                netBContext.Usuarios.Add(usuario);
                return await netBContext.SaveChangesAsync();
            };
        }

        public async Task<int> EditarUsuario(Usuarios usuario)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                var registo = await netBContext.Usuarios.Where(x => x.id == usuario.id).FirstOrDefaultAsync();
                registo.nome = usuario.nome;
                registo.senha = usuario.senha;
                registo.email = usuario.email;
                registo.departamento_id = usuario.departamento_id;
                return await netBContext.SaveChangesAsync();
            };
        }

        public async Task<int> DeletarUsuario(int id)
        {
            using (NetBContext netbContext = new NetBContext())
            {
                var usuario = await netbContext.Usuarios.Where(x => x.id == id).FirstOrDefaultAsync();
                netbContext.Usuarios.Remove(usuario);
                return await netbContext.SaveChangesAsync();
            }

        }

        public async Task<List<string>> BuscaUsuarioTarefa(int TarefaId)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Usuarios
                    .Join(netBContext.ProjetosUsuarios,
                    usuarios => usuarios.id,
                    projetosUsuarios => projetosUsuarios.usuarios_id,
                    (usuarios, projetosUsuarios) => new { usuarios, projetosUsuarios })
                    .Join(netBContext.Projetos,
                    join => join.projetosUsuarios.projetos_id,
                    projetos => projetos.id,
                    (join, projetos) => new { join, projetos })
                    .Join(netBContext.Tarefas,
                    join2 => join2.projetos.id,
                    tarefas => tarefas.projetos_id,
                    (join2, tarefas) => new { join2, tarefas })
                    .Where(x => x.tarefas.id == TarefaId).Select(x => x.join2.join.usuarios.email).ToListAsync();
            };
        }
    }
        
}
