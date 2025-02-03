﻿namespace ConsoleUI.UI.Components;

public abstract class Container : IComponent
{
    public IComponent[] SubComponents { get; set; } = [];

    public virtual void Render()
    {
        foreach (var component in SubComponents)
        {
            component.Render();
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