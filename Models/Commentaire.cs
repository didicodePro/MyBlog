using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Commentaire
    {
        public int Id { get; set; }

        [Required]
        public string Auteur { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Le commentaire ne peut pas dépasser 300 caractères.")]
        public string Contenu { get; set; }

        public DateTime DatePublication { get; set; } = DateTime.Now;

        // Clé étrangère vers Article
        public int ArticleId { get; set; }

        // Supprimer la contrainte obligatoire sur Article en ajoutant "?"
        public Article? Article { get; set; }

        // Add-Migration messageMigration
        // Update-Database
    }
}
