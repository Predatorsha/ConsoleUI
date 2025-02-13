using ConsoleUI;
using ConsoleUI.UI;
using ConsoleUI.UI.Components;

public partial class Program
{
    private static void Main()
    {
        var service = new Service();
        var operationContainer = new OperationContainer(0, 0, service);

        var screen = new Screen { SubComponents = [operationContainer] };
        
        screen.Run();
    }
}