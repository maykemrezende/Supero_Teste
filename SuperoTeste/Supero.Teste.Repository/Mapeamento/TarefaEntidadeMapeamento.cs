using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supero.Teste.Entidades;

namespace Supero.Teste.Repository.Mapeamento
{
    internal class TarefaEntidadeMapeamento : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> entidade)
        {
            entidade.ToTable("Tarefas");
            entidade.HasKey(e => e.Id);
            entidade.Property(e => e.Id).ForSqlServerUseSequenceHiLo();
            entidade.Property(e => e.Titulo).IsRequired();
        }
    }
}
