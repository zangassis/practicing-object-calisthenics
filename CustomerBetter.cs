namespace PracticingObjectCalisthenics
{
    public class CustomerBetter
    {
        public Address Address { get; }
        public string CityName => Address.City.Name;
    }
}
