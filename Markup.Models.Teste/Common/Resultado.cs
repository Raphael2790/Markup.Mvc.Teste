namespace Markup.Models.Teste.Common
{
    public class Resultado<T>
    {
        private Resultado(T dados)
        {
            Sucesso = true;
            Dados = dados;
        }

        private Resultado(string mensagem)
        {
            Sucesso = false;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public T Dados { get; set; }
        public string Mensagem { get; set; }

        public static Resultado<T> CriarSucesso(T dados)
            => new Resultado<T>(dados);

        public static Resultado<T> CriarFalha(string mensagem)
            => new Resultado<T>(mensagem);
    }

    public class Resultado
    {
        public Resultado(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
