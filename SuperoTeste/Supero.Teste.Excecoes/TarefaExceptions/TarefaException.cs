using System;

namespace Supero.Teste.Excecoes.TarefaExceptions
{
    public class TarefaException : Exception
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }

        public TarefaException(int codigo, string mensagem) : base(mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }
}
