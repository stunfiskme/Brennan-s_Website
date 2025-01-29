using System.ComponentModel.DataAnnotations;
namespace BrennansWebsite.Components.Pages.ViewModels;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter a Username")]
    public string? UserName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter a Password")]
    public string? Password { get; set; }
}