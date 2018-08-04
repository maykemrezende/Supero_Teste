using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Supero.Teste.Repository;
using Supero.Teste.Repository.Interface.UnitOfWork;
using Supero.Teste.Service.Interface.Interfaces;
using Supero.Teste.Service.Services;

namespace Supero.Teste.IoC
{
    public static class InjetorDependencia
    {
        public static void Register(IServiceCollection services)
        {
            RegistraServicos(services);
            RegistraUnitOfWork(services);
        }

        private static void RegistraUnitOfWork(IServiceCollection services) =>
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();

        private static void RegistraServicos(IServiceCollection services) =>
            services.TryAddScoped<ITarefaService, TarefaService>();
    }
}
