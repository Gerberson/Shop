using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    [Table ("Categoria")]
    public class Category
    {
        [Key]
        [Column ("Cat_Id")]
        public int Id { get; set; }

        [Column ("Titulo")]
        [DataType ("nvarchar")]
        [Required (ErrorMessage = "Este campo é obrigatório")]
        [MaxLength (60, ErrorMessage = "Este campo deve conter entre 3 a 60 caracateres")]
        [MinLength (3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracateres")]
        public string Title { get; set; }
    }
}