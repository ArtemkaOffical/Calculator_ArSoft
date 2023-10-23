using UnityEngine;
using UnityEngine.UIElements;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private UIDocument _mainCanvas;
    [SerializeField] private VisualTreeAsset _button;
    
    
    void Start()
    {
        UI ui = new UI();
        Calculator calculator = new Calculator();
        ui.Initialization(_mainCanvas);
        calculator.Initialization(ui,_button);
    }

}
