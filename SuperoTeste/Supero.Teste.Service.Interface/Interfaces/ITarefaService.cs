using Supero.Teste.Entidades;
using System.Collections.Generic;

namespace Supero.Teste.Service.Interface.Interfaces
{
    public interface ITarefaService
    {
        bool Salva(Tarefa tarefa);
        bool Atualiza(Tarefa tarefa);
        bool Exclui(int id);
        IReadOnlyList<Tarefa> RetornaTodasTarefas();
        Tarefa PesquisaTarefaPor(int id);
        bool AlteraStatusTarefa(int id, bool status);
    }
}
