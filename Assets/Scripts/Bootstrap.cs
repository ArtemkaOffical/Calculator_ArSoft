using UnityEngine;
using UnityEngine.UIElements;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private UIDocument _canvas;
    
    void Start()
    {
        Calculator calculator = new Calculator();
        calculator.Initialization(_canvas);
    }

}
