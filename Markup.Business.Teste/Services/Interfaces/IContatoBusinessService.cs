using Markup.Models.Teste.Common;
using Markup.Models.Teste.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Markup.Business.Teste.Services.Interfaces
{
    public interface IContatoBusinessService
    {
        Task<Resultado<List<Contato>>> ObterTodosContatosSalvos();
        Task<Resultado<Contato>> ObterContato(int id);

        Task<Resultado> CriarNovoContato(Contato contato);
        Task<Resultado> AtualizarContato(Contato contato);
        Task<Resultado> ExcluirContato(Contato contato);
    }
}
