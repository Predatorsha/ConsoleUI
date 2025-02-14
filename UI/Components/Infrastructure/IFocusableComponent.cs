namespace ConsoleUI.UI.Components.Infrastructure;

public interface IFocusableComponent
{
    bool IsActive { get; set; }
    
    void SetCursor();
    void Listen(ConsoleKeyInfo key);
}