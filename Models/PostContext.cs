using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    public class PostContext : DbContext
    {
        public PostContext (DbContextOptions<PostContext>options)
            :base(options)
        {

        }

        public DbSet<Post> Posts {get; set;}
        public DbSet<Favorite> Favorites {get; set;}
        

    }


}