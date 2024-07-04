namespace EcommerceWebsiteMovie.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId {  get; set; }
        public Actor Actors { get; set; }
        
    }
}
