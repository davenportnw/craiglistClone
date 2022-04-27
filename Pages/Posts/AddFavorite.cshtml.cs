using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final.Models;

namespace Final.Pages.Posts
{
    public class AddFavoriteModel : PageModel
    {
        private readonly Final.Models.PostContext _context;

        public AddFavoriteModel(Final.Models.PostContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; }
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

            Favorite = await _context.Favorites.FindAsync(id);

            if (Favorite != null)
            {
                _context.Favorites.Add(Favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Favorites");
        }
    }
}
