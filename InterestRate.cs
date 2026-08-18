namespace PracticingObjectCalisthenics;

public sealed record InterestRate
{
    public decimal Value { get; }

    public InterestRate(decimal value)
    {
        if (value < 0 || value > 100)
            throw new DomainException("Interest rate must be between 0 and 100.");

        Value = value;
    }
}