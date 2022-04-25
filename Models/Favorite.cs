using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Final.Models
{
    public class Favorite
    {
        public int FavoriteID {get; set;}

        public int PostID {get; set;} //foreign key back to post table

        public List<Post> FavoritePosts {get; set;} // a user can have MANY posts in their favorite

        public override string ToString()
        {
            return $"{FavoritePosts}";
        }

    }
}