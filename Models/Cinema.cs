using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsiteMovie.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Cinema Logo")]
        public string  Logo { get; set; }
        [Display(Name="Cinema Name")]
        public string  Name { get; set; }
        [Display(Name = "Cinema Descriptions")]
        public string Description { get; set; }
        //relations
        public List<Movie> Movies { get; set; } 
    }
}
