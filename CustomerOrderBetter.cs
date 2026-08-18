namespace PracticingObjectCalisthenics
{
    public class CustomerOrderBetter
    {
        private readonly List<OrderItem> _items = [];

        public IReadOnlyCollection<OrderItem> Items => _items;

        public decimal CalculateTotal()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        public void AddItem(OrderItem item)
        {
            ArgumentNullException.ThrowIfNull(item);

            _items.Add(item);
        }
    }
}
