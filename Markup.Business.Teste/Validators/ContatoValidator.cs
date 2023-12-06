using Markup.Models.Teste.Entities;

namespace Markup.Business.Teste.Validators
{
    public static class ContatoValidator
    {
        private static bool ValidarNome(string nome) 
            => !string.IsNullOrEmpty(nome);

        private static bool ValidarTelefone(string telefone) 
            => !string.IsNullOrEmpty(telefone);

        public static bool Validar(Contato contato) 
            => ValidarNome(contato.Nome) && ValidarTelefone(contato.Telefone);
    }
}
