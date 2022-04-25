using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Final.Models
{
    public class Favorite
    {
        
        [Key]
        public int PostID {get; set;} //foreign key back to post table
        public string FavoriteName {get; set;}

        public List<Post> Posts{get; set;} // a user can have MANY posts in their favorite
        //  public Post Post {get;set;} //Navigation property to a post

        public override string ToString()
        {
            return $"{FavoriteName}";
        }

    }
}