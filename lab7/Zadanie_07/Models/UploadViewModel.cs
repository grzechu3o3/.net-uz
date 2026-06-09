using System.ComponentModel.DataAnnotations;

namespace Zadanie_07.Models;

public class UploadViewModel
{
    [Required(ErrorMessage = "Wybierz przynajmniej jeden plik")]
    [Display(Name = "Pliki")]
    public List<IFormFile> Files { get; set; } = new();
}