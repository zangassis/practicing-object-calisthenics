namespace PracticingObjectCalisthenics;

public class Customer
{
    public bool IsActive { get; set; }
    public int CreditScore { get; internal set; }
    public string Id { get; internal set; }
    public string Email { get; internal set; }
    public Address Address { get; internal set; }
}