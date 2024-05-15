namespace FluentValidationApp.Web.Models;

public class Address
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public virtual Customer Customer { get; set; }


}
