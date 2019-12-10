using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        [MaxLength (20, ErrorMessage = "Este campo deve conter entre 3 a 20 caracateres")]
        [MinLength (3, ErrorMessage = "Este campo deve conter entre 3 a 20 caracateres")]
        public string UserName { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        [MaxLength (200, ErrorMessage = "Este campo deve conter entre 3 a 20 caracateres")]
        [MinLength (3, ErrorMessage = "Este campo deve conter entre 3 a 20 caracateres")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}