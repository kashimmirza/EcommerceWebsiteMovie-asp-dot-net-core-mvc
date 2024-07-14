using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsiteMovie.Models
{
    public class Actor
    {
        [Key]
        public int Id{ get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="profile picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength=3,ErrorMessage ="Full Name must be 3 and 50 chars ")]
        public string FullName { get; set; }
        [Display(Name ="Bio")]
        [Required(ErrorMessage = "Bio is Required")]
        public  string Bio { get; set; }
        public List<Actor_Movie> Actor_Movies {  get; set; }  

    }
}
