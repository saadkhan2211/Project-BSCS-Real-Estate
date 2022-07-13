using System.ComponentModel.DataAnnotations;

namespace Project_BSCS.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Log_email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Log_pass { get; set; }
        [Display(Name = "Remember Me")]
        public bool Log_Rem { get; set; }
    }
}
