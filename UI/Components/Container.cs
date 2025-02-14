using ConsoleUI.UI.Components.Infrastructure;

namespace ConsoleUI.UI.Components;

public abstract class Container : Component
{
    public List<Component> SubComponents { get; init; } = [];
    
    public override void Render(int parentLeft, int parentTop)
    {
        foreach (var component in SubComponents)
        {
            component.Render(Left + parentLeft, Top + parentTop);
        }
    }

    protected List<IFocusableComponent> GetFocusableComponents()
    {
        var focusableComponents = new List<IFocusableComponent>();
        foreach (var subComponent in SubComponents)
        {
            switch (subComponent)
            {
                case Container container:
                {
                    var focusableSubComponents = container.GetFocusableComponents();
                    focusableComponents.AddRange(focusableSubComponents);
                    break;
                }
                case IFocusableComponent focusableComponent:
                    focusableComponents.Add(focusableComponent);
                    break;
            }
        }

        return focusableComponents;
    }
}