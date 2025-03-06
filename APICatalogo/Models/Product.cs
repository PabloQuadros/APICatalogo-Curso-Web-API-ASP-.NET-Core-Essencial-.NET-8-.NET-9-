using APICatalogo.Validations;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

public class Product
{
    public int ProductId { get; set; }
    [FirstLetterCapitalized]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public float Stock { get; set; }
    public DateTime CreateDate { get; set; }
    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category Category { get; set; }
}
