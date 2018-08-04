using Supero.Teste.Repository.Interface.RepositorioBase;

namespace Supero.Teste.Repository.Interface.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepositorioBase<TEntidade> RetornaRepositorioDe<TEntidade>() where TEntidade : EntidadeBase;
    }
}
