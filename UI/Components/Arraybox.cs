using ConsoleUI.UI.Components.Infrastructure;

namespace ConsoleUI.UI.Components;

public class Arraybox : Container
{
    public delegate void SubmitArrayBoxEventHandler(double[] nums);
    public event SubmitArrayBoxEventHandler? Submit;
    public List<double> ResultingArray { get; private set; } = new();

    private double M { get; }
    private List<Numberbox> NumberboxList { get; }
    private Numberbox TriggerComponent { get; }
    private Label AttentionLabel { get; }

    public Arraybox(int left, int top, double m, double n  = 0)
    {
        Left = left;
        Top = top;
        M = m;

        var validCount = Convert.ToInt32(M);
        NumberboxList = new List<Numberbox>(validCount);
        
        AttentionLabel = new Label(0, 0, "");
        
        var starLabel = new Label(0, 2, "[");
        SubComponents.Add(starLabel);

        var lengthOfArrayBox = starLabel.Width;

        for (var i = 0; i < m; i++)
        {
            var numberBox = new Numberbox(lengthOfArrayBox, 0, NumberConstraint.None);
            SubComponents.Add(numberBox);
            NumberboxList.Add(numberBox);
            
            var label = new Label(lengthOfArrayBox, 2, ", ");
            SubComponents.Add(label);
            
            lengthOfArrayBox += numberBox.Width + label.Width;
        }

        for (var i = 0; i < n; i++)
        {
            var label = new Label(lengthOfArrayBox, 2, "0");
            SubComponents.Add(label);
            
            var zeroCount = Convert.ToInt32(n);
            if (i != zeroCount - 1)
            {
                var commaLabel = new Label(lengthOfArrayBox, 2, ", ");
                SubComponents.Add(commaLabel);
                lengthOfArrayBox += label.Width;
            }
        }
        var endLabel = new Label(lengthOfArrayBox, 2, "]");
        SubComponents.Add(endLabel);

        foreach (var component in SubComponents)
        {
            if (component is Numberbox numberBox)
            {
                numberBox.Enter += NumberboxOnEnter;
                TriggerComponent = numberBox;
            }
        }
    }

    private void NumberboxOnEnter(object? sender, EventArgs e)
    {
        if (!ValidateElementOfArray()) return;
        ResultingArray.Add(TriggerComponent.Value);
        
        var validCount = Convert.ToInt32(M);
        if (ResultingArray.Count < validCount) return;
        
        
        Submit?.Invoke(ResultingArray.ToArray());
    }
    
    private bool ValidateElementOfArray()
    {
        if (TriggerComponent.Value is < -1e9 or > 1e9)
        {
            AttentionLabel.Text = "Элемент массива должен быть в диапозоне от -10\u2079 до 10\u2079";
            return false;
        }

        var indexOfPreviousElement = NumberboxList.IndexOf(TriggerComponent);
        
        if (indexOfPreviousElement > 0 && NumberboxList[ indexOfPreviousElement - 1].Value > TriggerComponent.Value)
        {
            AttentionLabel.Text = $"Следующий элемент массива должен быть больше {TriggerComponent.Value}";
            return false;
        }
            
        return true;
    }
    
    public override void Render(int parentLeft, int parentTop)
    {
        var lengthOfArrayBox = 0;

        for (var i = 1; i < SubComponents.Count; i++)
        {
            if (SubComponents[i] is IHasWidth component)
            {
                lengthOfArrayBox += component.Width;
            }
            
            SubComponents[i + 1].Move(lengthOfArrayBox, 0); 
        }
        
        base.Render(parentLeft, parentTop);
    }
}