using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Models;

public class CommentairesController : Controller
{
    private readonly AppDbContext _context;

    public CommentairesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("ArticleId,Auteur,Contenu")] Commentaire commentaire)
    {
        if (ModelState.IsValid)
        {
            commentaire.DatePublication = DateTime.Now;
            _context.Commentaires.Add(commentaire);
            _context.SaveChanges();
            return RedirectToAction("Details", "Articles", new { id = commentaire.ArticleId });
        }

        // Si problème de validation, on revient sur l'article d'origine
        return RedirectToAction("Details", "Articles", new { id = commentaire.ArticleId });
    }
}
