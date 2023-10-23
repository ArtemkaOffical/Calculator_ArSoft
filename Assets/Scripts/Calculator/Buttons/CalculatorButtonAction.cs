public class CalculatorButtonAction : CalculatorButton, IActionButton
{
    public CalculatorButtonAction(string s) : base(s)
    {
    }

    public char GetSymbolOperation()
    {
        var g= Name.ToCharArray()[0];
        return g;
    }
}