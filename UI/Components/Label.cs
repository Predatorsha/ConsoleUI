using ConsoleUI.UI.Components.Interfaces;

namespace ConsoleUI.UI.Components;

public class Label : IComponent
{
    private int Left { get; }
    private int Top { get; }
    
    public string Text { get; set; }
    public int Width => Text.Length;

    public Label(int left, int top, string text)
    {
        Left = left;
        Top = top;
        Text = text;
    }

    public void Render(int parentLeft, int parentTop)
    {
        Console.SetCursorPosition(Left + parentLeft, Top + parentTop);
        Console.Write(Text);
    }
}