using Supero.Teste.Repository.Contexto;
using Supero.Teste.Repository.Interface;
using Supero.Teste.Repository.Interface.RepositorioBase;
using Supero.Teste.Repository.Interface.UnitOfWork;
using Supero.Teste.Repository.RepositorioBase;
using System;
using System.Collections.Generic;

namespace Supero.Teste.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoBD context;
        private readonly Dictionary<Type, object> repositories;

        public UnitOfWork(ContextoBD context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepositorioBase<TEntidade> RetornaRepositorioDe<TEntidade>() where TEntidade : EntidadeBase
        {
            var type = typeof(TEntidade);
            if (!repositories.ContainsKey(type))
            {
                repositories.Add(typeof(TEntidade),
                    new RepositorioBase<TEntidade>(context));
            }
            return repositories[type] as IRepositorioBase<TEntidade>;
        }
    }
}
