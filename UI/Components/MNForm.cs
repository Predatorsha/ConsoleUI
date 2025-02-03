namespace ConsoleUI.UI.Components;

public class MNForm : Container
{
    private Textbox MTextbox { get; }
    private Textbox NTextbox { get; }

    public e
    public MNForm()
    {
        var mLabel = new Label(0, 2, "Введите m = ");
        var nLabel = new Label(0, 4, "Введите n = ");

        MTextbox = new Textbox(12, 2);
        NTextbox = new Textbox(12, 4);

        SubComponents =
        [
            mLabel, nLabel,
            MTextbox, NTextbox
        ];

        MTextbox.Enter += TextboxOnEnter;
        NTextbox.Enter += TextboxOnEnter;
    }

    private void TextboxOnEnter(object? sender, EventArgs e)
    {
        // int.Parse(NTextbox.Value)
    }
}