using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class SignInViewModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
