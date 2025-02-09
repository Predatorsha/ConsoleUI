namespace ConsoleUI.UI.Components;

public class OperationContainer : Container
{
    private int Left { get; }
    private int Top { get; }
    private IService Service { get; }
    private MNForm MNForm { get; }
    
    public OperationContainer(int left, int top)
    {
        Left = left;
        Top = top;
        
        MNForm = new MNForm(Left, Top);
        
        SubComponents = [MNForm];
        
        MNForm.Submit += MNFormOnSubmit;
    }

    private void MNFormOnSubmit(object? sender, EventArgs e)
    {
        //var result = Service.Merge(MNForm.M, MNForm.N);
    }
}