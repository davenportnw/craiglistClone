using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public double Price {get; set;}

        public int? FavoriteID {get; set;} //foriegn key to favorite. Can be empty if not favorited
        public Favorite Favorite {get; set;}

    }
}