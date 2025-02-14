using ConsoleUI.UI.Components;
using ConsoleUI.UI.Components.Infrastructure;

namespace ConsoleUI.UI;

public class Screen : Container
{
    private IFocusableComponent? ActiveComponent { get; set; }

    public void Run()
    {
        Render();
        
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key is ConsoleKey.Escape)
            {
                break;
            }
            
            Listen(key);
            Render();
        }
    }
    
    private void Render()
    {
        Console.Clear();
        var focusableComponents = GetFocusableComponents();

        if (focusableComponents.Count > 0 && ActiveComponent == null)
        {
            ActiveComponent = focusableComponents[0];
        }
        
        foreach (var focusableComponent in focusableComponents)
        {
            focusableComponent.IsActive = focusableComponent == ActiveComponent;
        }
        
        base.Render(0, 0);
        ActiveComponent?.SetCursor();
    }

    private void Listen(ConsoleKeyInfo keyInfo)
    {
        var key = keyInfo.Key;
        var focusableComponents = GetFocusableComponents();
        var focusableComponentsCount = focusableComponents.Count; 
        
        if (key == ConsoleKey.Tab || 
            key == ConsoleKey.Enter && focusableComponentsCount > 1 && ActiveComponent != focusableComponents.Last())
        {
            if (focusableComponentsCount == 0)
            {
                return;
            }

            if (ActiveComponent == null)
            {
                ActiveComponent = focusableComponents[0];
                return;
            }
            
            var index = focusableComponents.IndexOf(ActiveComponent);
            
            if (index + 1 == focusableComponentsCount || index == -1)
            {
                ActiveComponent = focusableComponents[0];
                return;
            }
            
            ActiveComponent = focusableComponents[index + 1];
            return;
        }
        
        ActiveComponent?.Listen(keyInfo);
    }
}