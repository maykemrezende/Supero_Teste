namespace Supero.Teste.Entidades.Enum
{
    public class TarefaExceptionEnum : BaseEnum<TarefaExceptionEnum, string>
    {
        public static readonly TarefaExceptionEnum TITULO_VAZIO = new TarefaExceptionEnum(1, "O título não pode ser vazio.");
        public static readonly TarefaExceptionEnum ERRO_SALVAR = new TarefaExceptionEnum(2, "Houve um problema ao salvar a tarefa.");
        public static readonly TarefaExceptionEnum ERRO_ALTERAR = new TarefaExceptionEnum(3, "Houve um problema ao alterar a tarefa.");
        public static readonly TarefaExceptionEnum ERRO_EXCLUIR = new TarefaExceptionEnum(4, "Houve um problema ao excluir a tarefa.");
        public static readonly TarefaExceptionEnum TAREFA_NULA = new TarefaExceptionEnum(5, "Tarefa inválida.");
        public static readonly TarefaExceptionEnum TAREFA_INEXISTENTE = new TarefaExceptionEnum(5, "A tarefa não existe.");

        protected TarefaExceptionEnum(int codigo, string mensagem) : base(codigo, mensagem) { }
    }
}
