using Supero.Teste.Entidades;
using Supero.Teste.Repository.Interface.Especificacoes;

namespace Supero.Teste.QueryEspecificacoes.TarefaEspecificacoes
{
    public class EspecificacaoSelecionaTarefaPorId : QueryEspecificacao<Tarefa>
    {
        public EspecificacaoSelecionaTarefaPorId(int id)
            : base(e => e.Id == id)
        {
        }
    }
}
