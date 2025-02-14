namespace ConsoleUI.UI.Components.Infrastructure;

public abstract class Component
{
    protected int Left { get; set; }
    protected int Top { get; set; }
    
    public void Move(int left, int top)
    {
        Left = left;
        Top = top;
    }
    
    public abstract void Render(int parentLeft, int parentTop);
}