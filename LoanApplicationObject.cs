namespace PracticingObjectCalisthenics
{
    public class LoanApplicationObject
    {
        private readonly Installments _installments = new();

        public IReadOnlyCollection<Installment> Installments =>
            _installments.Items;

        public void AddInstallment(Installment installment)
        {
            _installments.Add(installment);
        }
    }
}
