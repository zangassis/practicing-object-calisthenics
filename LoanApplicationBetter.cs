namespace PracticingObjectCalisthenics;

public class LoanApplicationBetter
{
    public Money Amount { get; }

    public InterestRate InterestRate { get; }

    public InstallmentCount Installments { get; }

    public LoanApplicationBetter(Money amount, InterestRate interestRate, InstallmentCount installments)
    {
        Amount = amount;
        InterestRate = interestRate;
        Installments = installments;
    }
}