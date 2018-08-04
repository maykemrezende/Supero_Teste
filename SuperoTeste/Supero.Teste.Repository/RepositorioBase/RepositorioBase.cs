using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Supero.Teste.Repository.Contexto;
using Supero.Teste.Repository.Interface;
using Supero.Teste.Repository.Interface.Especificacoes;
using Supero.Teste.Repository.Interface.RepositorioBase;

namespace Supero.Teste.Repository.RepositorioBase
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        protected ContextoBD contexto;

        public RepositorioBase(ContextoBD context) : base() =>
            this.contexto = context;

        public bool Atualiza(TEntidade entidade)
        {
            entidade.DataAlteracao = DateTime.Now;
            contexto.Update(entidade);
            return contexto.SaveChanges() > 0;
        }

        public bool Exclui(TEntidade entidade)
        {
            contexto.Remove(entidade);
            return contexto.SaveChanges() > 0;
        }

        public IReadOnlyList<TEntidade> PesquisaPor(IQueryEspecificacao<TEntidade> especificacao) =>
            contexto.Set<TEntidade>().Where(especificacao.CriterioDaQuery).ToList();

        public IReadOnlyList<TEntidade> RetornaTodosRegistros()
        {
            return contexto.Set<TEntidade>().ToList();
        }

        public bool Salva(TEntidade entidade)
        {
            entidade.DataCriacao = DateTime.Now;
            contexto.Add(entidade);
            return contexto.SaveChanges() > 0;
        }
    }
}
