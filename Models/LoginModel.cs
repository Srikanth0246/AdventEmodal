using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class LoginModel
{
    [Required]
    public string username { get; set; }
    
    [Required]
    public string password { get; set; }
}
