using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        [MaxLength (60, ErrorMessage = "Este campo deve conter entre 3 a 60 caracateres")]
        [MinLength (3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracateres")]
        public string Title { get; set; }

        [MaxLength (1024, ErrorMessage = "Este campo deve conter 1024 caracateres")]
        public string Description { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        [Range (1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        [Range (1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}