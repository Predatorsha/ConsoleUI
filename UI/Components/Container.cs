using ConsoleUI.UI.Components.Interfaces;

namespace ConsoleUI.UI.Components;

public abstract class Container : IComponent
{
    public List<IComponent> SubComponents { get; set; } = [];

    protected int Left { get; set; }
    protected int Top { get; set; }

    public virtual void Render(int parentLeft, int parentTop)
    {
        foreach (var component in SubComponents)
        {
            component.Render(Left + parentLeft, Top + parentTop);
        }
    }

    public List<IFocusableComponent> GetFocusableComponents()
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