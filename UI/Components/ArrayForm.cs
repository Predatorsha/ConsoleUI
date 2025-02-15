namespace ConsoleUI.UI.Components;

public class ArrayForm : Container
{
    public delegate void SubmitArrayFormEventHandler(double[] nums1, double[] nums2);
    public event SubmitArrayFormEventHandler? Submit;

    private Arraybox Nums1Arraybox { get; }
    private Arraybox Nums2Arraybox { get; }
    
    private double[] Nums1 { get; set; }
    private double[] Nums2 { get; set; }
    private bool IsNums1Ready;
    private bool IsNums2Ready;

    public ArrayForm(int left, int top, double m, double n)
    {
        Left = left;
        Top = top;
        
        var nums1Label = new Label(0, 0, "Введите nums1 = ");
        var nums2Label = new Label(0, 2, "Введите nums2 = ");
        
        Nums1Arraybox = new Arraybox(0, 0, m, n);
        Nums2Arraybox = new Arraybox(0, 0, m);
        
        SubComponents =
        [
            nums1Label, nums2Label,
            Nums1Arraybox, Nums2Arraybox
        ];

        Nums1Arraybox.Submit += ArrayboxOnSubmitNums1;
        Nums2Arraybox.Submit += ArrayboxOnSubmitNums2;
    }
    
    private void ArrayboxOnSubmitNums1(double[] nums1)
    {
        IsNums1Ready = true;
        Nums1 = nums1;
        
        if (!IsNums2Ready) return;
        
        Submit?.Invoke(Nums1, Nums2);
    }

    private void ArrayboxOnSubmitNums2(double[] nums2)
    {
        IsNums2Ready = true;
        Nums2 = nums2;
        
        if (!IsNums1Ready) return;
        
        Submit?.Invoke(Nums1, Nums2);
    }
}