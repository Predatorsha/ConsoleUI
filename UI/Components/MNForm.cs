namespace ConsoleUI.UI.Components;

public class MNForm : Container
{
    private int Left { get; }
    private int Top { get; }
    private Numberbox MNumberbox { get; }
    private Numberbox NNumberbox { get; }
    private Label AttentionLabel { get; set; }

    public int M { get; private set; }
    public int N { get; private set; }

    public event EventHandler Submit;

    public MNForm(int left, int top)
    {
        Left = left;
        Top = top;
        
        AttentionLabel = new Label(Left, Top, "");
        var mLabel = new Label(Left, Top + 2, "Введите m = ");
        var nLabel = new Label(Left, Top + 4, "Введите n = ");

        MNumberbox = new Numberbox(Left + mLabel.Width, Top + 2, true);
        NNumberbox = new Numberbox(Left + nLabel.Width, Top + 4, true);

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
        (M, N) = Validate();
        Submit(this, EventArgs.Empty);
    }

    private (int m, int n) Validate()
    {
        while (true)
        {
            var m = GetValidNumberOfArrayElementsInput(MNumberbox.Value, "m");
            
            var n = GetValidNumberOfArrayElementsInput(NNumberbox.Value, "n");
            
            var sum = m + n;
            if (sum is < 1 or > 200)
            {
                AttentionLabel.Text = "Сумма m и n должна быть в диапозоне от 1 до 200";
                continue;
            }
            
            return (m, n);
        }
    }

    private int GetValidNumberOfArrayElementsInput(string parameter, string parameterName)
    {
        while (true)
        {
            var numberOfArrayElements = int.Parse(parameter);
            if (numberOfArrayElements is < 0 or > 200)
            {
                AttentionLabel.Text = $"{{{parameterName}}} должен быть в диапозоне от 0 до 200";;
                continue;
            }
            
            return numberOfArrayElements;
        }
    }
}