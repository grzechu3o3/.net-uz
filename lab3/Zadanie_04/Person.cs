public class Person
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} - Tel: {PhoneNumber}";
    }
}