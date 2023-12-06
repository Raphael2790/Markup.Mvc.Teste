using Markup.Business.Teste.Services.Interfaces;
using Markup.Business.Teste.Validators;
using Markup.Models.Teste.Common;
using Markup.Models.Teste.Entities;
using Markup.Models.Teste.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Markup.Business.Teste.Services
{
    public class ContatoBusinessService : IContatoBusinessService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoBusinessService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Resultado> AtualizarContato(Contato contato)
        {
            try
            {
                if (!ContatoValidator.Validar(contato))
                    return new Resultado(false, "As informações do contato estão inválidas");

                var contatoExistente = await _contatoRepository.ObterContato(contato.Id);

                if (contatoExistente == null)
                    return new Resultado(false, "Contato não existe");

                contatoExistente.Nome = contato.Nome;
                contatoExistente.Telefone = contato.Telefone;
                contatoExistente.Data = DateTime.Now;

                await _contatoRepository.Atualizar(contatoExistente);

                return new Resultado(true, "Contato atualizado com sucesso");
            }
            catch (Exception)
            {
                return new Resultado(false, "Erro ao atualizar contato");
            }
        }

        public async Task<Resultado> CriarNovoContato(Contato contato)
        {
            try
            {
                if(!ContatoValidator.Validar(contato))
                    return new Resultado(false, "As informações do contato estão inválidas");

                contato.Data = DateTime.Now;

                await _contatoRepository.Salvar(contato);

                return new Resultado(true, "Contato salvo com sucesso");
            }
            catch (Exception)
            {
                return new Resultado(false, "Erro ao salvar contato");
            }
        }

        public async Task<Resultado> ExcluirContato(Contato contato)
        {
            try
            {
                var contatoExiste = await _contatoRepository.ObterContato(contato.Id);

                if(contatoExiste == null)
                    return new Resultado(false, "Contato não existe");

                await _contatoRepository.Excluir(contatoExiste);

                return new Resultado(true, "Contato excluído com sucesso");
            }
            catch (Exception)
            {
                return new Resultado(false, "Erro ao excluir contato");
            } 
        }

        public async Task<Resultado<Contato>> ObterContato(int id)
        {
            try
            {
                var contato = await _contatoRepository.ObterContato(id);

                if(contato == null)
                    return Resultado<Contato>.CriarFalha("Contato não existe");

                return Resultado<Contato>.CriarSucesso(contato);
            }
            catch (Exception)
            {
                return Resultado<Contato>.CriarFalha("Erro ao obter contato");
            }
        }

        public async Task<Resultado<List<Contato>>> ObterTodosContatosSalvos()
        {
            try
            {
                var contatos = await _contatoRepository.ObterContatos();

                return Resultado<List<Contato>>.CriarSucesso(contatos);
            }
            catch (Exception)
            {
                return Resultado<List<Contato>>.CriarFalha("Erro ao obter contatos");
            }
        }
    }
}
