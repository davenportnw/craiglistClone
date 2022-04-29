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
    public class FavoritesModel : PageModel
    {
        private readonly Final.Models.PostContext _context;

        public FavoritesModel(Final.Models.PostContext context)
        {
            _context = context;
        }

        public IList<Favorite> Favorites { get;set; }
        public string CurrentFilter{get; set;}

        public async Task OnGetAsync()
        {
            Favorites = await _context.Favorites.Include(f => f.Posts).ToListAsync();
        }
        // public async Task OnGetAsync(string stringOrder, string searchString)
        // {
        //     CurrentFilter = searchString;

        //     IQueryable<Post> posts = from p in _context.Posts   
        //                             select p;

        //     if(!String.IsNullOrEmpty(searchString))
        //     {
        //         posts = posts.Where(p => p.Title.Contains(searchString) ||
        //                             p.Description.Contains(searchString));
        //     }
        //     Post = await posts.AsNoTracking().ToListAsync();
        // }


    }
}
