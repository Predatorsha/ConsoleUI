using ConsoleUI.UI.Components.Infrastructure;

namespace ConsoleUI.UI.Components;

public class MNForm : Container
{
    public delegate void SubmitMNFormEventHandler(double m, double n);
    public event SubmitMNFormEventHandler? Submit;
    
    private Numberbox MNumberbox { get; }
    private Numberbox NNumberbox { get; }
    private Label AttentionLabel { get; }
    private double M { get; set; }
    private double N { get; set; }

    public MNForm(int left, int top)
    {
        Left = left;
        Top = top;
        
        AttentionLabel = new Label(0, 0, "");
        var mLabel = new Label(0, 2, "Введите m = ");
        var nLabel = new Label(0, 4, "Введите n = ");

        MNumberbox = new Numberbox(mLabel.Width, 2, NumberConstraint.Positive);
        NNumberbox = new Numberbox(nLabel.Width, 4, NumberConstraint.Positive);

        SubComponents =
        [
            AttentionLabel, mLabel, nLabel,
            MNumberbox, NNumberbox
        ];

        MNumberbox.Enter += NumberboxOnEnter;
        NNumberbox.Enter += NumberboxOnEnter;
    }

    private void NumberboxOnEnter(object? sender, EventArgs e)
    {
        M = MNumberbox.Value;
        N = MNumberbox.Value;

        if (!ValidateNumberOfArrayElements(M, "m") || !ValidateNumberOfArrayElements(N, "n")) return;
        if (!Validate()) return;
        
        Submit?.Invoke(M, N);
    }
    
    private bool ValidateNumberOfArrayElements(double parameter, string parameterName)
    {
        if (parameter is < 0 or > 200)
        {
            AttentionLabel.Text = $"{{{parameterName}}} должен быть в диапозоне от 0 до 200";
            return false;
        }
            
        return true;
    }

    private bool Validate()
    {
        var sum = M + N;
        if (sum is < 1 or > 200)
        {
            AttentionLabel.Text = "Сумма m и n должна быть в диапозоне от 1 до 200";
            return false;
        }
            
        return true;
    }
}