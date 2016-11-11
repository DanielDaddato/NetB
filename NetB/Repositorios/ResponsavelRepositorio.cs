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
        private Usuarios usuario;

        public async Task<IEnumerable<Responsavel>> BuscaResponsaveis()
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Responsavel.ToListAsync();
            }
        }

        public async Task<Responsavel> BuscaEmailResponsaveis(int id)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Responsavel.Where(x => x.id == id).Select(x => x).FirstOrDefaultAsync();
            }
        }

        public async Task<Responsavel> BuscaResponsavel(int id)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                return await netBContext.Responsavel.Where(x => x.id == id).Select(x => x).FirstOrDefaultAsync();
            }
        }

        public async Task<int> AdicionarResponsavel(Responsavel responsavel)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                responsavel.data_cadastro = DateTime.Now;
                netBContext.Responsavel.Add(responsavel);
                return await netBContext.SaveChangesAsync();
            }
        }

        public async Task<int> DeletarResponsavel(int id)
        {
            using (NetBContext netbContext = new NetBContext())
            {
                var responsavel = await netbContext.Responsavel.Where(x => x.id == id).FirstOrDefaultAsync();
                netbContext.Responsavel.Remove(responsavel);
                return await netbContext.SaveChangesAsync();
            }
        }

        public async Task<int> EditarResponsavel(Responsavel responsavel)
        {
            using (NetBContext netBContext = new NetBContext())
            {
                var registro = await netBContext.Responsavel.Where(x => x.id == responsavel.id).FirstOrDefaultAsync();
                registro.nome = responsavel.nome;
                registro.email = responsavel.email;
                registro.telefone = responsavel.telefone;
                registro.celular = responsavel.celular;
                return await netBContext.SaveChangesAsync();
            }
        }
    }
}
