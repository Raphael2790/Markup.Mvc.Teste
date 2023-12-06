using Markup.Models.Teste.Entities;
using Markup.Models.Teste.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Markup.Data.Teste.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly MarkupContext _context;

        public ContatoRepository(MarkupContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Contato contato) 
            => await _context.SaveChangesAsync();

        public async Task Excluir(Contato contato)
        {
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
        }

        public async Task<Contato> ObterContato(int id) 
            => await _context.Contatos.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<List<Contato>> ObterContatos() 
            => await _context.Contatos.ToListAsync();

        public async Task Salvar(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
        }
    }
}
