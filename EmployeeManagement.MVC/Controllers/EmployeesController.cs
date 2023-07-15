using AutoMapper;
using EmployeeManagement.MVC.Contracts;
using EmployeeManagement.MVC.Models;
using EmployeeManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;

namespace EmployeeManagement.MVC.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IPositionService _positionService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public EmployeesController(ILocationService locationService, IPositionService positionService, IUserService userService, IMapper mapper)
        {
            this._locationService = locationService;
            this._positionService = positionService;
            this._mapper = mapper;
            this._userService = userService;
        }

        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            var model = await _userService.GetAdminUserList();
            return View(model);
        }

        // GET: EmployeesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _userService.GetEmployeeDetails(id);
            return View(model);
        }

        // GET: EmployeesController/Create
        public async Task<ActionResult> Create()
        {
            var locations = await _locationService.GetLocations();
            var locationItems = new SelectList(locations, "Id", "Address");
            var positions = await _positionService.GetPositions();
            var positionItems = new SelectList(positions, "Id", "Name");
            var model = new CreateEmployeeVM
            {
                Locations = locationItems,
                Positions = positionItems
            };

            return View(model);
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeVM employee)
        {
                var response = await _userService.CreateEmployee(employee);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);

            var positions = await _positionService.GetPositions();
            var positionsItems = new SelectList(positions, "Id", "Name");
            employee.Positions = positionsItems;
            var locations = await _locationService.GetLocations();
            var locationsItems = new SelectList(locations, "Id", "Town", "Street");
            employee.Locations = locationsItems;


            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _userService.DeleteEmployee(id);
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
            return RedirectToAction(nameof(Index));
        }
    }
}
