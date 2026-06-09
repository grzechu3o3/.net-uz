using System.ComponentModel.DataAnnotations;

namespace Zadanie_04.Validators;

public class NoNumbersAttribute : ValidationAttribute
{
    public NoNumbersAttribute()
    {
        ErrorMessage = "Pole nie może zawierać cyfr";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string str && str.Any(char.IsDigit))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}