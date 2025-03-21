using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly AppDbContext _context;

        public ArticlesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var article = await _context.Articles
                .Include(a => a.Commentaires)
                    .ThenInclude(c => c.Replies) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }


    }
}
