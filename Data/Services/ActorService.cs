using EcommerceWebsiteMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EcommerceWebsiteMovie.Data.Services
{
    public class ActorService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorService(AppDbContext context)
        {
            _context = context;
        }
        //async Task AddAsync(Actors actor)
        //{   
        //    await _context.Actors.Add(actor);
        //    await _context.SaveChanges();
            
        //}

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
             _context.Actors.Remove(result) ;
            await _context.SaveChangesAsync();
        }
        //public void Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Actors>> GetAll()
        //{
        //    var result = await _context.Actors.ToListAsync();

        //    return result;
        //}

        //public Actors GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}


        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        //public Actors Update(int id, Actors newActor)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }

    }


}
