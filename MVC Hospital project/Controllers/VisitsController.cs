using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.DbContextAndBuilders.ApiDbContext;
using MVC_Hospital_project.Entities;
using Hospital.Controllers;
using MVC_Hospital_project.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MVC_Hospital_project.Areas.Identity.Data;
using System.Security.Claims;
using MVC_Hospital_project.Subject;
using MVC_Hospital_project.Notification;

namespace MVC_Hospital_project.Controllers
{
    [Authorize]
    public class VisitsController : BaseController
    {

        private readonly HospitalDbContext _context;
        private readonly IVisitEdited _editedVisit;
        private readonly INotificationHandler _notificationHandler;

        public VisitsController(HospitalDbContext context, IVisitEdited editedVisit, INotificationHandler notificationHandler)
        {
            _context = context;
            _editedVisit = editedVisit;
            _notificationHandler = notificationHandler;
        }

        
        public async Task<IActionResult> Index()
        {
           
            var visits =  (await Mediator.Send(new GetVisits.Query())).Value;
            return View(visits);
        }

       
        public async Task<IActionResult> Details(int id)
        {
            
            var visit = Mediator.Send(new GetSingleVisit.Query {Id = id}).Result.Value;

            return View(visit);
        }

        
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfVisit,DoctorId,PatientId")] Visit visit)
        {

            await Mediator.Send(new CreateVisit.Query { visit=visit});
            return RedirectToAction(nameof(Index));
            
        }
       

        // GET: Visits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Visits == null)
            {
                return NotFound();
            }

            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name", visit.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name", visit.PatientId);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfVisit,DoctorId,PatientId")] Visit visit)
        {
            
            if (id != visit.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    await Mediator.Send(new UpdateVisit.Query { visit = visit });
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitExists(visit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _editedVisit.NotifyObserver(visit);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name", visit.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name", visit.PatientId);
            
            return View(visit);
        }

        // GET: Visits/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Visits == null)
            {
                return NotFound();
            }

            var visit = Mediator.Send(new GetSingleVisit.Query{Id=id}).Result.Value;
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Mediator.Send(new DeleteVisit.Query { Id=id});
            return RedirectToAction(nameof(Index));
        }

        private bool VisitExists(int id)
        {
          return _context.Visits.Any(e => e.Id == id);
        }
    }
}
