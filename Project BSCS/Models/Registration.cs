using System.ComponentModel.DataAnnotations;

namespace Project_BSCS.Models
{
    public class Registration
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Your First Name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name.")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't match with Comfirm Password")]
        public string ConfirmPassword { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
