
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution08.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de l'item est obligatoire")]
        [MaxLength(100, ErrorMessage = "La taille du nom de l'item ne peut excéder 100 caractères")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "La taille de la description ne peut excéder 500 caractères")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int? PageCount { get; set; }

        [Range(0, float.MaxValue)]
        public float? Price { get; set; }

        [Range(1500, 3000)]
        public int? PublicationYear { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }
    }
}
