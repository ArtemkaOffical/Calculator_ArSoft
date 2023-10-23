using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class CalculatorButton: IButton
{
    public  string Name { get; private set; }
    protected CalculatorButton(string name)
    {
        Name = name;
    }

    public void Print(Label label,string text)
    {
        label.text = text;
    }
}
