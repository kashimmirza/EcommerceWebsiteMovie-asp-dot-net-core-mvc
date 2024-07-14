using EcommerceWebsiteMovie.Data;
using Microsoft.AspNetCore.Mvc;
using EcommerceWebsiteMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsiteMovie.Data.Services;
using EcommerceWebsiteMovie.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcommerceWebsiteMovie.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _Service;
        public ActorsController(IActorsService Service)
        {
            _Service = Service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _Service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl,Bio")]Actor actor)
        {

            actor.Actor_Movies ??= new List<Actor_Movie>();

            // Exclude Actor_Movies from model state validation
            ModelState.Remove(nameof(actor.Actor_Movies));
            if (!ModelState.IsValid)
            {

                var errors = ModelState.Values.SelectMany(v => v.Errors);

                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }


                return View(actor);
            }
            
            await _Service.AddAsync(actor);
            return View(actor);
            
        }
        //Get: Actors/Detaisl
        public async Task<IActionResult>Details(int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);
            if(actorDetails == null)
            {
                return View("Empty");
            }
            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("Empty");
            }
            return View(actorDetails);
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName, ProfilePictureUrl,Bio")] Actor actor)
        {
            actor.Actor_Movies ??= new List<Actor_Movie>();

            // Exclude Actor_Movies from model state validation
            ModelState.Remove(nameof(actor.Actor_Movies));
            
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }


                return View(actor);
            }
            await _Service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("Not found");
            }
            return View(actorDetails);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> deleteConfirm(int id)
        {
            var actorDetails = _Service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("Not found");
            }
            await _Service.DeleteAsync(id);

            // Exclude Actor_Movies from model state validation
           
          
            return RedirectToAction(nameof(Index));
        }
    }
}
