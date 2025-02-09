namespace ConsoleUI;

public class Service : IService
{
    public string Merge(double[] nums1, int m, double[] nums2, int n)
    {
        var lastIndexNums1 = m - 1;
        var lastIndexNums2 = n - 1;
        var mergePosition = m + n - 1;

        while (lastIndexNums2 >= 0)
        {
            if (lastIndexNums1 >= 0 && nums1[lastIndexNums1] > nums2[lastIndexNums2])
            {
                nums1[mergePosition] = nums1[lastIndexNums1];
                lastIndexNums1--;
            }
            else
            {
                nums1[mergePosition] = nums2[lastIndexNums2];
                lastIndexNums2--;
            }
            mergePosition--;
        }

        return "Итоговый массив: ";                                     
        //+ Helper.ConvertArrayToString(nums1);
    }
}