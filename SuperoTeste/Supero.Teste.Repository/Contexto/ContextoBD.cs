using Microsoft.EntityFrameworkCore;
using Supero.Teste.Entidades;
using Supero.Teste.Repository.Mapeamento;

namespace Supero.Teste.Repository.Contexto
{
    public class ContextoBD : DbContext
    {        
        public DbSet<Tarefa> Tarefas { get; set; }

        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaEntidadeMapeamento());
        }
    }
}
