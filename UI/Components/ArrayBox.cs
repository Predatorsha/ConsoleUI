using System.Text;
using ConsoleUI.UI.Components.Infrastructure;

namespace ConsoleUI.UI.Components;

public class ArrayBox : Container
{
    public event EventHandler? Submit;
    
    private int M { get; set; }
    private int N { get; set; }
    private Numberbox TriggerComponent { get; set; }
    private Label AttentionLabel { get; set; }

    public ArrayBox(int left, int top, int m, int n)
    {
        Left = left;
        Top = top;
        
        AttentionLabel = new Label(0, 0, "");
        
        var starLabel = new Label(0, 2, "[");
        SubComponents.Add(starLabel);

        var lengthOfArrayBox = starLabel.Width;

        for (var i = 0; i < m; i++)
        {
            var numberBox = new Numberbox(lengthOfArrayBox, 0, NumberConstraint.None);
            SubComponents.Add(numberBox);
            
            var label = new Label(lengthOfArrayBox, 2, ", ");
            SubComponents.Add(label);
            
            lengthOfArrayBox += numberBox.Width + label.Width;
        }

        for (var i = 0; i < n; i++)
        {
            var label = new Label(lengthOfArrayBox, 2, "0");
            SubComponents.Add(label);
            
            if (i != n - 1)
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
        (M, N) = Validate();
        Submit?.Invoke(this, EventArgs.Empty);
    }

    private double[] Validate(string parameterName)
    {
        var outOfRangeWarning = $"Элемент массива {parameterName} должен быть в диапозоне от -10\u2079 до 10\u2079";
        
        var array =  new double[M + N];

        for (var i = 0; i < M; i++)
        {
            Double elementOfArray;
            while (true)
            {
                elementOfArray = InputElements(parameterName, false);
                if (elementOfArray is < -1e9 or > 1e9)
                {
                    AttentionLine.Render(outOfRangeWarning);
                    continue;
                }
                if (i > 0 && array[i - 1] > elementOfArray)
                {
                    AttentionLine.Render($"Следующий элемент массива должен быть больше {array[i - 1]}");
                    continue;
                }
                break;
            }

            AttentionLine.Clear();
            array[i] = elementOfArray;
            
            AttentionLine.Render(Helper.ConvertArrayToString(array));
        }
        
        var finishedArray = Helper.ConvertArrayToString(array);
        switch (parameterName)
        {
            case "nums1":
                Nums1Line.Render("nums1 = " + finishedArray);
                break;
            case "nums2":
                Nums2Line.Render("nums2 = " + finishedArray);
                break;
        }
        
        return array;
    }
    
    private double GetValidElementOfArray(string parameter, string parameterName)
    {
        while (true)
        {
            var numberOfArrayElements = int.Parse(parameter);
            if (numberOfArrayElements is < 0 or > 200)
            {
                AttentionLabel.Text = $"{{{parameterName}}} должен быть в диапозоне от 0 до 200";
                continue;
            }
            
            return numberOfArrayElements;
        }
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