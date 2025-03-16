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
        [HttpPost]
        public async Task<IActionResult> Create(int ArticleId, string Auteur, string Contenu)
        {
            Console.WriteLine($"Reçu : ArticleId={ArticleId}, Auteur={Auteur}, Contenu={Contenu}");

            // 1️⃣ Vérifie si l'article existe AVANT d'ajouter un commentaire
            var article = await _context.Articles.FindAsync(ArticleId);
            if (article == null)
            {
                TempData["Error"] = "L'article auquel vous essayez d'ajouter un commentaire n'existe pas.";
                return RedirectToAction("Index", "Articles");
            }

            if (string.IsNullOrEmpty(Auteur) || string.IsNullOrEmpty(Contenu))
            {
                TempData["Error"] = "Veuillez remplir tous les champs.";
                return RedirectToAction("Details", "Articles", new { id = ArticleId });
            }

            // 2️⃣ Lier explicitement l'article au commentaire
            var commentaire = new Commentaire
            {
                ArticleId = ArticleId,
                Auteur = Auteur,
                Contenu = Contenu,
                DatePublication = DateTime.Now,
                Article = article // C'est cette ligne qui assure la liaison
            };

            _context.Commentaires.Add(commentaire);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Articles", new { id = ArticleId });
        }



        // Test : Vérifier si la route existe en GET
        [HttpGet]
        public IActionResult Test()
        {
            return Content("Le contrôleur fonctionne !");
        }
    }
}
