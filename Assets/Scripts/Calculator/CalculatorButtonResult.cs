internal class CalculatorButtonResult : CalculatorButtonAction, IResultButton
{
    public CalculatorButtonResult(string s) : base(s)
    {
      
    }

    public string Result(float x, float y, IOperation operation)
    {
        return operation.Operation(x, y);
    }

   
}