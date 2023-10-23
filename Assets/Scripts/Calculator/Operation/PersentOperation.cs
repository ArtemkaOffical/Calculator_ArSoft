namespace DefaultNamespace
{
    public class PersentOperation: IOperation
    {
        public string Operation(float x, float y)
        {
            return (x / 100).ToString();
        }
    }
}