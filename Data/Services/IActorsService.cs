using EcommerceWebsiteMovie.Models;

namespace EcommerceWebsiteMovie.Data.Services
{
    public interface IActorsService
    {
        //Task<IEnumerable<Actors> >GetAll();
        //Actors GetById(int id);
        //void Add(Actors actor);
        //Actors Update(int id, Actors newActor);
        //void Delete(int id);

        Task<IEnumerable<Actor>> GetAllAsync();
        Task AddAsync(Actor actor);
        Task<Actor> GetByIdAsync(int id);
        Task<Actor> UpdateAsync(int id, Actor newActor);
        Task DeleteAsync(int id);
    }
}
