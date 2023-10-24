using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MultiOperation : BaseOperation
{
    public override char SymbolOfOperation { get; protected set; } = '*';
    public override  string Operation(float x, float y)
    {
        return (x * y).ToString();
    }
}
