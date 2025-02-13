using System.Text;

namespace ConsoleUI.UI.Components;

public class ArrayBox : Container
{
    private readonly int m;
    private readonly int n;
    private StringBuilder SB { get; set; } = new();

    public ArrayBox(int left, int top, int m, int n)
    {
        this.m = m;
        this.n = n;
        Left = left;
        Top = top;
        
        var starLabel = new Label(Left, Top, "[");
        SubComponents.Add(starLabel);
        
        var lengthOfArrayBox = starLabel.Width;

        for (var i = 0; i < m; i++)
        {
            var numberBox = new Numberbox(lengthOfArrayBox, Top, false);
            SubComponents.Add(numberBox);
            
            var label = new Label(lengthOfArrayBox, Top, ", ");
            SubComponents.Add(label);
            
            lengthOfArrayBox += numberBox.Width + label.Width;
        }

        for (int i = 0; i < n; i++)
        {
            var label = new Label(lengthOfArrayBox, Top, "0");
            SubComponents.Add(label);
            
            if (i != n - 1)
            {
                var commaLabel = new Label(lengthOfArrayBox, Top, ", ");
                SubComponents.Add(commaLabel);
                lengthOfArrayBox += label.Width;
            }
        }
        var endLabel = new Label(lengthOfArrayBox, Top, "]");
        SubComponents.Add(endLabel);
    }

    public override void Render()
    {
        var lengthOfArrayBox = 0;
        
        for (var i = 1; i < SubComponents.Count; i++)
        {
            if (SubComponents[i] is Numberbox numberBox)
            {
                numberBox
                lengthOfArrayBox += numberBox.Width;
            }

            var numberBox = (Numberbox)SubComponents[i];
             
             if
             
            var label = new Label(LengthOfArrayBox, 0, ",");
            SubComponents.Add(label);
            
            LengthOfArrayBox += numberBox.Value.Length + label.Text.Length;
        }

        for (int i = 0; i < N; i++)
        {
            var label = new Label(LengthOfArrayBox, 0, "0,");
            SubComponents.Add(label);
            
            if (i != N - 1)
            {
                var commaLabel = new Label(LengthOfArrayBox, 0, ",");
                SubComponents.Add(commaLabel);
                LengthOfArrayBox += label.Text.Length;
            }
        }
        var endLabel = new Label(0, 0, "]");
        SubComponents.Add(endLabel);
        
        LengthOfArrayBox += endLabel.Text.Length;
        
        base.Render();
    }

    public bool IsActive { get; set; }

    public void Listen(ConsoleKeyInfo key)
    {
        throw new NotImplementedException();
    }
}