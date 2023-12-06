using Markup.Models.Teste.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Markup.Models.Teste.Interfaces.Repositories
{
    public interface IContatoRepository
    {
        Task<List<Contato>> ObterContatos();
        Task<Contato> ObterContato(int id);

        Task Salvar(Contato contato);
        Task Atualizar(Contato contato);
        Task Excluir(Contato contato);
    }
}
