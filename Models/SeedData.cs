using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Final.Models
{
    public static class SeedData
    {
     public static void Initialize(IServiceProvider serviceProvider) 
     {
         using(var context = new PostContext(
             serviceProvider.GetRequiredService<DbContextOptions<PostContext>>()))
        {
            //Look for any movies
            if(context.Posts.Any())
            {
                return; //DB has been seeded.
            }

            context.Posts.AddRange(
                new Post
                {
                    Title = "For sale: Lawn Mower",
                    Description = "Only used twice. Wife ended up getting me a nicer one. In great shape!",
                    Price = 50.00
                },
                new Post
                {
                    Title = "For sale: Couch",
                    Description = "This couch has been loved on but is in great shape! Had a couple of dogs, but vaccummed and shampooed it! ",
                    Price = 80.00
                },
                new Post 
                {
                    Title = "In need: Pet Sitter",
                    Description = "Will be out of town in a couple of months. Need a petsitter to watch over my two german shepherds. Dolly and Macie are very nice!"
                },

                new Post
                {
                    Title = "Puppies for sale!!",
                    Description = "My laberdoodle just had puppies two months ago. Ready for new forever homes.",
                    Price = 150.00
                }
               
            );
            context.SaveChanges();
        }
     }   
    }
}