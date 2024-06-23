using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Data.Dtos
{
	public class UserRegistrerDto
	{
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }

    }
}
