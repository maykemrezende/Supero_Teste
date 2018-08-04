namespace Supero.Teste.Entidades.Enum
{
    public class BaseEnum<T, Y> where T : BaseEnum<T, Y>
    {
        public int Codigo { get; protected set; }
        public Y Valor { get; protected set; }

        protected BaseEnum(int codigo, Y valor)
        {
            Codigo = codigo;
            Valor = valor;
        }

    }
}
