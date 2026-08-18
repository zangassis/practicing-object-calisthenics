namespace PracticingObjectCalisthenics
{
    public sealed class Installment
    {
        public int Number { get; }

        public decimal Amount { get; }

        public DateOnly DueDate { get; }

        public Installment(
            int number,
            decimal amount,
            DateOnly dueDate)
        {
            if (number <= 0)
                throw new DomainException(
                    "Installment number must be greater than zero.");

            if (amount <= 0)
                throw new DomainException(
                    "Installment amount must be greater than zero.");

            Number = number;
            Amount = amount;
            DueDate = dueDate;
        }
    }
}