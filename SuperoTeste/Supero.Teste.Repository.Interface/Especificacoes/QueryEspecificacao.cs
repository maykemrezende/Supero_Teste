using System;
using System.Linq.Expressions;

namespace Supero.Teste.Repository.Interface.Especificacoes
{
    public abstract class QueryEspecificacao<T> : IQueryEspecificacao<T>
    {
        public Expression<Func<T, bool>> CriterioDaQuery { get; }

        public QueryEspecificacao(Expression<Func<T, bool>> criterioDaQuery) =>
            CriterioDaQuery = criterioDaQuery;
    }
}
