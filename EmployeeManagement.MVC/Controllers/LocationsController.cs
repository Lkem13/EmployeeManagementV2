using EmployeeManagement.MVC.Contracts;
using EmployeeManagement.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmployeeManagement.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationRepository;

        public LocationsController(ILocationService locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET: LocationsController
        public async Task<ActionResult> Index()
        {
            var model = await _locationRepository.GetLocations();
            return View(model);
        }

        // GET: LocationsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _locationRepository.GetLocationDetails(id);

            return View(model);
        }

        // GET: LocationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLocationVM location)
        {
            try
            {
                var response = await _locationRepository.CreateLocation(location);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(location);
        }

        // GET: LocationsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _locationRepository.GetLocationDetails(id);
            return View(model);
        }

        // POST: LocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LocationVM location)
        {
            try
            {
                var response = await _locationRepository.UpdateLocation(id, location);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(location);
        }

        // POST: LocationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _locationRepository.DeleteLocation(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }
    }
}
