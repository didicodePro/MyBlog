using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le titre ne peut pas dépasser 100 caractères.")]
        public required string Titre { get; set; }

        [Required(ErrorMessage = "Le contenu est obligatoire.")]
        public required string Contenu { get; set; }

        public DateTime DatePublication { get; set; } = DateTime.Now;
        public virtual ICollection<Commentaire> Commentaires { get; set; } = [];


    }
}
