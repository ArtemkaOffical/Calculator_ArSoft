using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class UI
{
    public VisualElement RowOfButtons { get; set; }
    public VisualElement ContainerOfButtons { get; private set; }
    public Label Output { get; private set; }
    public void Initialization(UIDocument _mainCanvas)
    {
        var canvas = _mainCanvas.rootVisualElement.Q("canvas");
        canvas.AddToClassList("container");
        
        var containerOfCalculator = canvas.Q("calculator");
        containerOfCalculator.AddToClassList("container");
        
        ContainerOfButtons = containerOfCalculator.contentContainer.Q("buttons");
        ContainerOfButtons.AddToClassList("block__buttons");
        
        var containerOfOutput = containerOfCalculator.contentContainer.Q("output");
        Output = containerOfOutput.Q<Label>("outputField");
        Output.text = string.Empty;
        containerOfOutput.AddToClassList("block__output");
        Output.AddToClassList("output--field");
        
        RowOfButtons = new VisualElement();
        RowOfButtons.AddToClassList("buttons--row");

    }
}
