using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Clé étrangère vers l'article
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        // Clé étrangère pour gérer les réponses (imbriquer les commentaires)
        public int? ParentId { get; set; } 
        [ForeignKey("ParentId")]
        public virtual Commentaire? Parent { get; set; }

        // Liste des réponses associées à un commentaire
        public virtual ICollection<Commentaire>? Replies { get; set; } = new List<Commentaire>();
    }
}
