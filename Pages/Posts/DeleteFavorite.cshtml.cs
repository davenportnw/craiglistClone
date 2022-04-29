using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Final.Models;

namespace Final.Pages.Posts
{
    public class DeleteFavoriteModel : PageModel
    { 
        private readonly Final.Models.PostContext _context;
        private readonly ILogger<DeleteFavoriteModel> _logger;

        public DeleteFavoriteModel(ILogger<DeleteFavoriteModel> logger, Final.Models.PostContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; }
        
        public Post PostToFavorite {get; set;} // Post you want to favorite
        public Favorite Favorite {get; set;}

       public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts.FirstOrDefaultAsync(m => m.PostID == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            PostToFavorite = await _context.Posts.FindAsync(id); // Find Post To Favorite
            
            if (PostToFavorite != null)
            {
                Favorite = _context.Favorites.First(); // Get your favorites
                if (Favorite.Posts == null) {
                    Favorite.Posts = new List<Post>();
                }
                Favorite.Posts.Remove(PostToFavorite); // Add this post to your favorites
                // _context.Favorites.Add(Favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Favorites");
        }
    }
}
