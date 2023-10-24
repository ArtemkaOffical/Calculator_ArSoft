namespace DefaultNamespace
{
    public abstract class BaseOperation : IOperation
    {
        public abstract char SymbolOfOperation { get; protected set; }
        public abstract string Operation(float x, float y);
    }
}