using ConsoleUI.UI.Components.Infrastructure;

namespace ConsoleUI.UI.Components;

public class Label : Component, IHasWidth
{
    public string Text { get; set; }
    public int Width => Text.Length;

    public Label(int left, int top, string text)
    {
        Left = left;
        Top = top;
        Text = text;
    }

    public override void Render(int parentLeft, int parentTop)
    {
        Console.SetCursorPosition(Left + parentLeft, Top + parentTop);
        Console.Write(Text);
    }
}