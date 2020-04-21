using System.ComponentModel.DataAnnotations;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
       public string Username { get; set; }  
        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="Düzgün Parola girin!!")]
       public string Password { get; set; }
    }
}