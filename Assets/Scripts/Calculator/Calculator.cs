using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine.UIElements;

public class Calculator
{
    private char _lastSymbolOpertaion;
    private readonly string[] _buttonsAction = { "+", "-", "/", "*", "%", "C" };

    private readonly List<CalculatorButton> _buttons = new List<CalculatorButton>()
   {
      new CalculatorButtonResult("C"),
      new CalculatorButtonNumber(","),
      new CalculatorButtonResult("%"),
      new CalculatorButtonAction("/"),
      new CalculatorButtonNumber("7"),
      new CalculatorButtonNumber("8"),
      new CalculatorButtonNumber("9"),
      new CalculatorButtonAction("*"),
      new CalculatorButtonNumber("4"),
      new CalculatorButtonNumber("5"),
      new CalculatorButtonNumber("6"),
      new CalculatorButtonAction("-"),
      new CalculatorButtonNumber("1"),
      new CalculatorButtonNumber("2"),
      new CalculatorButtonNumber("3"),
      new CalculatorButtonAction("+"),
      new CalculatorButtonNumber("0"),
      new CalculatorButtonResult("="),
   };

    public void Initialization(UI ui, VisualTreeAsset buttonAsset)
    {

        int j = 1;
        for (int i = 0; i < _buttons.Count; i++)
        {

            var calcButton = _buttons[i];
            var button = buttonAsset.Instantiate().Q<Button>("button");

            button.AddToClassList("button");
            button.AddToClassList(_buttonsAction.Contains(calcButton.Name) ? "button--action" : "button--number");
            if (calcButton.Name == "=")
                button.AddToClassList("button--result");

            button.text = calcButton.Name;
            button.clicked += () => ButtonOnClicked(calcButton, ui.Output);

            ui.RowOfButtons.contentContainer.Add(button);

            if (j == 4)
            {
                ui.ContainerOfButtons.contentContainer.Add(ui.RowOfButtons);
                ui.RowOfButtons = new VisualElement();
                ui.RowOfButtons.AddToClassList("buttons--row");
                j = 0;
            }

            j++;

        }
        ui.ContainerOfButtons.contentContainer.Add(ui.RowOfButtons);
    }

    private void ButtonOnClicked(CalculatorButton calcButton, Label label)
    {
        if ((label.text == string.Empty || label.text.StartsWith(calcButton.Name)) && calcButton.Name == "0"
               || label.text.Contains(calcButton.Name) && calcButton.Name == ",")
            return;

        if (calcButton is IResultButton resultButton)
        {

            if (calcButton.Name != "=")
                _lastSymbolOpertaion = resultButton.GetSymbolOperation();

            var textValue = label.text.Split(_lastSymbolOpertaion);
            float numTwo = 0;
            float numOne = 0;

            if (float.TryParse(textValue[0], out float parsedNumOne))
                numOne = parsedNumOne;
            if (textValue.Length > 1 && float.TryParse(textValue[1], out float parsedNumTwo))
                numTwo = parsedNumTwo;

            IOperation operation = GetOperation(_lastSymbolOpertaion);
            string result = resultButton.Result(numOne, numTwo, operation);
            resultButton.Print(label, result);

            return;

        }

        if (calcButton is IActionButton actionButton)
            _lastSymbolOpertaion = actionButton.GetSymbolOperation();

        calcButton.Print(label, label.text + calcButton.Name);

    }

    private IOperation GetOperation(char lastOp)
    {

        switch (lastOp)
        {

            case '*':
                return new MultiOperation();
            case '-':
                return new SubOperation();
            case '+':
                return new AddOperation();
            case '/':
                return new DivisionOperation();
            case '%':
                return new PersentOperation();
            case 'C':
                return new ClearOperation();
            default:
                throw new Exception("operation not found");

        }

    }

}