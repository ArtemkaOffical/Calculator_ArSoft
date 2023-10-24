namespace DefaultNamespace
{
    public class ClearOperation : BaseOperation
    {
        public override char SymbolOfOperation { get; protected set; } = 'C';
        public override string Operation(float x, float y)
        {
            return string.Empty;
        }
    }
}