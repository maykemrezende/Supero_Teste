using Supero.Teste.Repository.Interface;

namespace Supero.Teste.Entidades
{
    public class Tarefa : EntidadeBase
    {
        public string Titulo { get; set; }
        public bool EstaConcluida { get; set; }
    }
}
