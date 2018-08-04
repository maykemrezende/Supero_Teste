using Supero.Teste.Repository.Interface.Especificacoes;
using System.Collections.Generic;

namespace Supero.Teste.Repository.Interface.RepositorioBase
{
    public interface IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        bool Salva(TEntidade entidade);
        bool Atualiza(TEntidade entidade);
        bool Exclui(TEntidade entidade);
        IReadOnlyList<TEntidade> RetornaTodosRegistros();
        IReadOnlyList<TEntidade> PesquisaPor(IQueryEspecificacao<TEntidade> especificacao);
    }
}
