using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Models;

public class Category : IValidatableObject
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public ICollection<Product> Products { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationConterxt)
    {
        if(!string.IsNullOrEmpty(this.Name))
        {
            var firstLetter = this.Name.ToString()[0].ToString();

            if (firstLetter != firstLetter.ToUpper())
            {
                yield return new ValidationResult("The first letter at product name must be capitalized", new[] { nameof(this.Name) });
            }
        }
    }
}
