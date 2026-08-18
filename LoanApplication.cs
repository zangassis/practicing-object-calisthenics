namespace PracticingObjectCalisthenics
{
    public class LoanApplication
    {
        public decimal Amount { get; private set; }

        public decimal InterestRate { get; private set; }

        public List<Installment> Installments { get; } = [];

        public void AddInstallment(Installment installment)
        {
            Installments.Add(installment);
        }

        public LoanApplication(
            decimal amount,
            decimal interestRate,
            List<Installment> installments)
        {
            Amount = amount;
            InterestRate = interestRate;
            Installments = installments;
        }

        public object Status { get; internal set; }
        public Customer Customer { get; internal set; }
        public CustomerBetter CustomerBetter { get; internal set; }
        public Exception? Id { get; internal set; }

        internal void Approve()
        {
            throw new NotImplementedException();
        }

        internal void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}