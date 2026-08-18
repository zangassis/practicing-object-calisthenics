namespace PracticingObjectCalisthenics;

public sealed record InstallmentCount
{
    public int Value { get; }

    public InstallmentCount(int value)
    {
        if (value < 1)
            throw new DomainException(
                "Installment count must be greater than zero.");

        if (value > 120)
            throw new DomainException(
                "Installment count cannot exceed 120.");

        Value = value;
    }
}