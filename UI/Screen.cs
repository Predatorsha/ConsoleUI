using ConsoleUI.UI.Components;
using ConsoleUI.UI.Components.Interfaces;

namespace ConsoleUI.UI;

public class Screen : Container
{
    public IFocusableComponent? ActiveComponent { get; set; }

    public override void Render()
    {
        Console.Clear();
        var focusableComponents = GetFocusableComponents();

        if (focusableComponents.Count >0 && ActiveComponent == null)
        {
            ActiveComponent = focusableComponents[0];
        }
        
        foreach (var focusableComponent in focusableComponents)
        {
            focusableComponent.IsActive = focusableComponent == ActiveComponent;
        }
        base.Render();
        ActiveComponent?.SetCursor();
    }

    public void Listen(ConsoleKeyInfo keyInfo)
    {
        var key = keyInfo.Key;
        var focusableComponents = GetFocusableComponents();
        var focusableComponentsCount = focusableComponents.Count; 
        
        if (key == ConsoleKey.Tab || 
            key == ConsoleKey.Enter && focusableComponentsCount > 1 && ActiveComponent != focusableComponents.Last() )
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