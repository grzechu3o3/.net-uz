using System.ComponentModel.DataAnnotations;
using Zadanie_04.Validators;

namespace Zadanie_04.Models;

public class UserFormModel
{
    [Required(ErrorMessage = "Imię jest wymagane")]
    [NoNumbers]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Imię musi mieć od 2 do 50 znaków")]
    [Display(Name = "Imię")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    [NoNumbers]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Nazwisko musi mieć od 2 do 50 znaków")]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email jest wymagany")]
    [EmailAddress(ErrorMessage = "Podaj poprawny adres email")]
    [Display(Name = "Adres e-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Wiek jest wymagany")]
    [Range(18, 120, ErrorMessage = "Wiek musi być między 18 a 120")]
    [Display(Name = "Wiek")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Hasło jest wymagane")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Hasło musi mieć min. 6 znaków")]
    [DataType(DataType.Password)]
    [Display(Name = "Hasło")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Potwierdź hasło")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Hasła nie są identyczne")]
    [Display(Name = "Powtórz hasło")]
    public string ConfirmPassword { get; set; } = string.Empty;
}