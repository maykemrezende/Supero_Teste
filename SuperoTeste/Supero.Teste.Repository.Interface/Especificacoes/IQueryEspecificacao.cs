using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Supero.Teste.Repository.Interface.Especificacoes
{
    public interface IQueryEspecificacao<T>
    {
        Expression<Func<T, bool>> CriterioDaQuery { get; }
    }
}
