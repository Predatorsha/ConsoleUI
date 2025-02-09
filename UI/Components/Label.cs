using ConsoleUI.UI.Components.Interfaces;

namespace ConsoleUI.UI.Components;

public class Label : IComponent
{
    private int Left { get; set; }
    private int Top { get; set; }
    
    public string Text { get; set; }
    public int Width => Text.Length;

    public Label(int left, int top, string text)
    {
        Left = left;
        Top = top;
        Text = text;
    }

    public void Render()
    {
        Console.SetCursorPosition(Left, Top);
        Console.Write(Text);
    }
}