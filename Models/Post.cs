using System;
using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Post
    {
        public int PostID {get; set;}


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title {get; set;}

        [Required]
        public string Description {get; set;}

        public double Price {get; set;}

    }
}