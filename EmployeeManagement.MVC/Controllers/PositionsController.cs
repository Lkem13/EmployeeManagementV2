using EmployeeManagement.MVC.Contracts;
using EmployeeManagement.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmployeeManagement.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PositionsController : Controller
    {
        private readonly IPositionService _positionRepository;

        public PositionsController(IPositionService positionRepository)
        {
            _positionRepository = positionRepository;
        }

        // GET: PositionsController
        public async Task<ActionResult> Index()
        {
            var model = await _positionRepository.GetPositions();
            return View(model);
        }

        // GET: PositionsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _positionRepository.GetPositionDetails(id);

            return View(model);
        }

        // GET: PositionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PositionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePositionVM position)
        {
            try
            {
                var response = await _positionRepository.CreatePosition(position);
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
            return View(position);
        }

        // GET: PositionsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _positionRepository.GetPositionDetails(id);
            return View(model);
        }

        // POST: PositionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PositionVM position)
        {
            try
            {
                var response = await _positionRepository.UpdatePosition(id, position);
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
            return View(position);
        }

        // POST: PositionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _positionRepository.DeletePosition(id);
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
