namespace DefaultNamespace
{
    public class PersentOperation: BaseOperation
    {
        public override char SymbolOfOperation { get; protected set; } = '%';
        public override string Operation(float x, float y)
        {
            return (x / 100).ToString();
        }
    }
}