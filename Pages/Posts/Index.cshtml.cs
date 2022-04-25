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
    public class IndexModel : PageModel
    {
        private readonly Final.Models.PostContext _context;

        public IndexModel(Final.Models.PostContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }
        public string CurrentFilter{get; set;}

        // public async Task OnGetAsync()
        // {
        //     Post = await _context.Posts.ToListAsync();
        // }
        public async Task OnGetAsync(string stringOrder, string searchString)
        {
            CurrentFilter = searchString;

            IQueryable<Post> posts = from p in _context.Posts   
                                    select p;

            if(!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(p => p.Title.Contains(searchString) ||
                                    p.Description.Contains(searchString));
            }
            Post = await posts.AsNoTracking().ToListAsync();
        }


    }
}
