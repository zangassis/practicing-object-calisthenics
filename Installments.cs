namespace PracticingObjectCalisthenics
{
    public sealed class Installments
    {
        private readonly List<Installment> _items = [];

        public IReadOnlyCollection<Installment> Items =>
            _items.AsReadOnly();

        public void Add(Installment installment)
        {
            if (_items.Count >= 120)
                throw new DomainException(
                    "A loan cannot have more than 120 installments.");

            _items.Add(installment);
        }

        public decimal TotalAmount()
        {
            return _items.Sum(x => x.Amount);
        }
    }
}