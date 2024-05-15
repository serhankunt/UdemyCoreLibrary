namespace FluentValidationApp.Web.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateTime? BirthDay { get; set; }
    public IList<Address> Addresses { get; set; }
    public Gender Gender { get; set; }
}
