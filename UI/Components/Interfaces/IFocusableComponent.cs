namespace ConsoleUI.UI.Components.Interfaces;

public interface IFocusableComponent : IComponent
{
    bool IsActive { get; set; }
    
    void SetCursor();
    void Listen(ConsoleKeyInfo key);
}