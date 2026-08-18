namespace PracticingObjectCalisthenics
{
    public class OrderValidator
    {
        public void Validate(CustomerOrderBetter order)
        {
            if (order.Items.Count == 0)
            {
                throw new DomainException("Order must have at least one item.");
            }
        }
    }
}
