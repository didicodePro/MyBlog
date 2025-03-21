using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class CommentaireController : Controller
    {
        private readonly AppDbContext _context;

        public CommentaireController(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Create([Bind("Id,Titre,Contenu,DatePublication")] Article article)

        [HttpPost]
        public async Task<IActionResult> Create(int articleId, string auteur, string contenu, int? parentId)
        {
            if (string.IsNullOrEmpty(auteur) || string.IsNullOrEmpty(contenu))
            {
                TempData["Error"] = "Veuillez remplir tous les champs.";
                return RedirectToAction("Details", "Articles", new { id = articleId });
            }

            var commentaire = new Commentaire
            {
                ArticleId = articleId,
                Auteur = auteur,
                Contenu = contenu,
                DatePublication = DateTime.Now,
                ParentId = parentId  
            };

            _context.Commentaires.Add(commentaire);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Articles", new { id = articleId });
        }

    }
}
