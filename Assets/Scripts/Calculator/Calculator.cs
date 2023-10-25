using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine.UIElements;

public class Calculator
{
    private char _lastSymbolOpertaion;

    private readonly BaseOperation[] _operations =
    {
        new AddOperation(), new MultiOperation(), new SubOperation(),
        new DivisionOperation(), new ClearOperation(), new PersentOperation()
    };

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

    public void Initialization(UIDocument canvas)
    {
        var containerOfButtons = canvas.rootVisualElement.Q("Buttons");
        var output = canvas.rootVisualElement.Q<Label>("OutputField");
        int index = 0;
        RecursiveButtonBinding(containerOfButtons, output, ref index);
    }

    private void RecursiveButtonBinding(VisualElement containerOfButtons, Label label, ref int index)
    {
        foreach (var row in containerOfButtons.Children())
        {

            if (row.Children().Count() != 0)
                RecursiveButtonBinding(row, label, ref index);

            if (row is not Label uiButton) continue;
            var button = _buttons[index];
            uiButton.AddToClassList(button is IActionButton ? "button--action" : "button--number");
            uiButton.text = button.Name;
            uiButton.RegisterCallback<ClickEvent>((callback)=>ButtonOnClicked(button, label));
            index++;
        }
    }

    private void ButtonOnClicked(CalculatorButton calcButton, Label label)
    {
        if ((label.text == string.Empty || label.text.StartsWith(calcButton.Name)) && calcButton.Name == "0"
            || (calcButton.Name == "," && ((_lastSymbolOpertaion != '\0' && label.text.Count(x => x == ',') == 2)
                                           || (_lastSymbolOpertaion == '\0') && label.text.Contains(calcButton.Name) ||
                                           label.text == string.Empty)))
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

            if (!TryGetOperation(_lastSymbolOpertaion, out IOperation operation))
                throw new Exception("operation not found");

            string result = resultButton.Result(numOne, numTwo, operation);
            resultButton.Print(label, result);
            _lastSymbolOpertaion = '\0';

            return;

        }

        if (calcButton is IActionButton actionButton)
            _lastSymbolOpertaion = actionButton.GetSymbolOperation();

        calcButton.Print(label, label.text + calcButton.Name);

    }

    private bool TryGetOperation(char lastOp, out IOperation operation)
    {
        operation = _operations.FirstOrDefault(x => x.SymbolOfOperation == lastOp);

        return operation != null;
    }

}