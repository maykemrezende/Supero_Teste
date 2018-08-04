using FluentValidation;
using Supero.Teste.Entidades;
using Supero.Teste.Entidades.Enum;

namespace Supero.Teste.Validacoes.Tarefas
{
    public class TarefaValidacoes : AbstractValidator<Tarefa>
    {
        public TarefaValidacoes()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty()
                .WithErrorCode(TarefaExceptionEnum.TITULO_VAZIO.Codigo.ToString())
                .WithMessage(TarefaExceptionEnum.TITULO_VAZIO.Valor);
        }
    }
}
