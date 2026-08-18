namespace PracticingObjectCalisthenics;

public sealed record Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value <= 0)
            throw new DomainException("Amount must be greater than zero.");

        Value = value;
    }
}