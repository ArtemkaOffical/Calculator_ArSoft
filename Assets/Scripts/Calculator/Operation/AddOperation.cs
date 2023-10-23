using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOperation : IOperation
{
    public string Operation(float x, float y)
    {
        return (x + y).ToString();
    }
}
