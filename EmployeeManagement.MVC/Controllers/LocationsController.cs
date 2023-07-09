using EmployeeManagement.MVC.Contracts;
using EmployeeManagement.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.MVC.Controllers
{
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
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
