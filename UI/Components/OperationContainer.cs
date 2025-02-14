namespace ConsoleUI.UI.Components;

public class OperationContainer : Container
{
    private IService Service { get; }
    private MNForm MNForm { get; }
    
    public OperationContainer(int left, int top, IService service)
    {
        Service = service;
        Left = left;
        Top = top;
        
        MNForm = new MNForm(0, 0);
        
        SubComponents = [MNForm];
        
        MNForm.Submit += MNFormOnSubmit;
    }

    private void MNFormOnSubmit(int m, int n)
    {
        //var result = Service.Merge(MNForm.M, MNForm.N);
    }
}