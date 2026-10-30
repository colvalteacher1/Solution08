
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution08.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom de la catégorie est obligatoire")]
        [MaxLength(100, ErrorMessage ="La taille du nom de la catégorie ne peut excéder 100 caractères")]
        public string Name { get; set; } = string.Empty;

        //Navigation property
        public virtual List<Item> Items { get; set; } = new();
    }
}
