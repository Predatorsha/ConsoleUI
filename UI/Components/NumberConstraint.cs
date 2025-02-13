namespace ConsoleUI.UI.Components;

public enum NumberConstraint
{
    None,
    Positive,
}

public static class NumberConstraintExtension
{
    public static bool IsPositive(this NumberConstraint x)
    {
        return NumberConstraint.Positive == x;
    }
}