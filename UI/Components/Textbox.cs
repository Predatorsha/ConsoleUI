using System.Text;

namespace ConsoleUI.UI.Components;

public class Textbox : IFocusableComponent 
{
    public bool IsActive { get; set; }
    
    private int Left { get; }
    private int Top { get; }
    private int CursorPosition { get; set; }
    private int MaxLenght => 12;
    private StringBuilder SB { get; set; } = new();

    public string Value => SB.ToString();

    public event EventHandler Enter;
    

    public Textbox(int left, int top)
    {
        Left = left;
        Top = top;
    }

    public void Render()
    {
        Console.SetCursorPosition(Left, Top);

        if (IsActive)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
        }
        
        Console.Write(SB.ToString());
        Console.Write(new string(' ', MaxLenght - SB.Length + 1));
        Console.ResetColor();
    }
    
    public void SetCursor()
    {
        Console.SetCursorPosition(Left + CursorPosition, Top);
    }

    public void Listen(ConsoleKeyInfo keyInfo)
    {
        var key = keyInfo.Key;
        if (key is ConsoleKey.A or ConsoleKey.LeftArrow)
        {
            if (CursorPosition == 0)
            {
                return;
            }

            CursorPosition -= 1;
        }
        
        if (key is ConsoleKey.D or ConsoleKey.RightArrow)
        {
            if (CursorPosition == SB.Length)
            {
                return;
            }

            CursorPosition += 1;
        }

        if (char.IsDigit(keyInfo.KeyChar))
        {
            if (SB.Length == MaxLenght)
            {
                return;
            }
            
            SB.Insert(CursorPosition, keyInfo.KeyChar);
            CursorPosition += 1;
        }

        if (key is ConsoleKey.Enter)
        {
            Enter?.Invoke(this, EventArgs.Empty);
        }
    }
}