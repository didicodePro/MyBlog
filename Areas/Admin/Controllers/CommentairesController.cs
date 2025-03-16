using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;
using System.Threading.Tasks;

namespace MyBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentairesController : Controller
    {
        private readonly AppDbContext _context;

        public CommentairesController(AppDbContext context)
        {
            _context = context;
        }

        // Afficher tous les commentaires avec les articles associés
        public async Task<IActionResult> Index()
        {
            var commentaires = await _context.Commentaires
                .Include(c => c.Article) // Charger les articles liés
                .ToListAsync();

            return View(commentaires);
        }

        // Supprimer un commentaire
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"Tentative de suppression du commentaire avec ID : {id}");

            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                Console.WriteLine("Commentaire introuvable !");
                return NotFound();
            }

            _context.Commentaires.Remove(commentaire);
            await _context.SaveChangesAsync();

            Console.WriteLine("Commentaire supprimé avec succès !");

            return RedirectToAction("Index", "Commentaires");
        }

    }
}
