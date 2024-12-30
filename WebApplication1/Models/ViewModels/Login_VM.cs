using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class Login_VM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
