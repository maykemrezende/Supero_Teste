using System;

namespace Supero.Teste.Repository.Interface
{
    public class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
