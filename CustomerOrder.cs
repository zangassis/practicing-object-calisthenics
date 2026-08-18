namespace PracticingObjectCalisthenics
{
    public class CustomerOrder
    {
        public int Id { get; set; }

        public List<OrderItem> Items { get; set; } = [];

        public decimal CalculateTotal()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

        public void Validate()
        {
            if (Items.Count == 0)
                throw new DomainException("Order must have at least one item.");

            if (Items.Any(item => item.Quantity <= 0))
                throw new DomainException("Invalid item quantity.");
        }

        public void SendConfirmationEmail()
        {
            // Send email...
        }

        public void ExportToCsv()
        {
            // Generate CSV...
        }

        public void Save()
        {
            // Save to database...
        }
    }
}
