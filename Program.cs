using ConsoleUI;
using ConsoleUI.UI;
using ConsoleUI.UI.Components;

public partial class Program
{
    private static void Main()
    {
        
        var operationContainer = new OperationContainer(0, 0);

        var screen = new Screen { SubComponents = [operationContainer] };
        screen.Render();
        
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key is ConsoleKey.Escape)
            {
                break;
            }
            
            screen.Listen(key);
            screen.Render();
        }
    }
}