using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsiteMovie.Models
{
    public class Actor
    {
        [Key]
        public int Id{ get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public  string Bio { get; set; }
        public List<Actor_Movie> Actor_Movie {  get; set; }  

    }
}
