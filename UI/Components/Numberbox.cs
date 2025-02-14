using System.Text;
using ConsoleUI.UI.Components.Infrastructure;

namespace ConsoleUI.UI.Components;

public class Numberbox : Component, IFocusableComponent 
{
    public bool IsActive { get; set; }
    public string Value => SB.ToString();
    public int Width => Value.Length;

    public event EventHandler? Enter;
    
    private NumberConstraint NumberConstraint { get; set; }
    private int MaxLenght => 12;
    private int CursorPosition { get; set; }
    private StringBuilder SB { get; } = new();
    
    public Numberbox(int left, int top, NumberConstraint numberConstraint)
    {
        Left = left;
        Top = top;
        NumberConstraint = numberConstraint;
    }

    public override void Render(int parentLeft, int parentTop)
    {
        Console.SetCursorPosition(Left + parentLeft, Top + parentTop);

        if (IsActive)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
        }

        Console.Write(SB.ToString());
        Console.ResetColor();
    }

    public void SetCursor()
    {
        Console.SetCursorPosition(Left + CursorPosition, Top);
    }

    public void Listen(ConsoleKeyInfo keyInfo)
    {
        var key = keyInfo.Key;
        
        switch (key)
        {
            case ConsoleKey.A or ConsoleKey.LeftArrow when CursorPosition == 0:
                return;
            case ConsoleKey.A or ConsoleKey.LeftArrow:
                CursorPosition -= 1;
                break;
            
            case ConsoleKey.D or ConsoleKey.RightArrow when CursorPosition == SB.Length:
                return;
            case ConsoleKey.D or ConsoleKey.RightArrow:
                CursorPosition += 1;
                break;
            
            case ConsoleKey.Delete when CursorPosition == SB.Length:
                return;
            case ConsoleKey.Delete:
                SB.Remove(CursorPosition, 1);
                break;
            
            case ConsoleKey.Backspace when CursorPosition == 0:
                return;
            case ConsoleKey.Backspace:
                SB.Remove(CursorPosition - 1, 1);
                CursorPosition -= 1;
                break;
            
            case ConsoleKey.OemMinus when NumberConstraint.IsPositive():
            case ConsoleKey.OemMinus when CursorPosition != 0:
                return;
            case ConsoleKey.OemMinus:
                SB.Insert(CursorPosition, keyInfo.KeyChar);
                CursorPosition += 1;
                break;
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