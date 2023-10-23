using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionOperation : IOperation
{
    public string Operation(float x, float y)
    {
        return (x / y).ToString();
    }
}
