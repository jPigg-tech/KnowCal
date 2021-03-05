using CalorieTracker.Data;
using CalorieTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalorieTracker.Controllers
{
    public class Health_EnthusiastController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Health_EnthusiastController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HomeController1
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var healthEnthusiast = _context.Health_Enthusiasts.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            if (healthEnthusiast == null)
            {
                return RedirectToAction(nameof(Create));
            }
            if (healthEnthusiast.InitialCalorieIntake == null)
            {
                return RedirectToAction("GetInitialCalorieIntake", new { id = healthEnthusiast.Id });
            }
            var healthEnthusiastGoalWeight = _context.Goals.Where(c => c.HealthEnthusiastId == healthEnthusiast.Id).SingleOrDefault();
            //ViewBag.Id = employer.EmpId;
            if (healthEnthusiastGoalWeight.GoalWeight == null)
            {
                return RedirectToAction("CreateGoals", new { id = healthEnthusiast.Id });
            }
            // return View(healthEnthusiastGoalWeight);
            return View();


            // Creating a Profile 
            // Setting goals 
            // Asking about initial eating habits
            // Ask about Activity 
            // Choosing Recomendations
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var healthEnthusiast = _context.Health_Enthusiasts.SingleOrDefault(m => m.Id == id);
            return View(healthEnthusiast);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Health_Enthusiast healthEnthusiast)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                healthEnthusiast.IdentityUserId = userId;
                _context.Add(healthEnthusiast);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(healthEnthusiast);
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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

        public IActionResult CreateGoals(int id)
        {
            // _context.Jobs.Where(c => c.EmployerId == id);            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateJob(Goals weightGoal, int id)
        {
            try
            {
                weightGoal.HealthEnthusiastId = id;

                _context.Goals.Add(weightGoal);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> GetInitialCalorieIntake(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var healthEnthusiast = await _context.Health_Enthusiasts.FindAsync(id);
            if (healthEnthusiast == null)
            {
                return NotFound();
            }
            return View(healthEnthusiast);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetInitialCalorieIntake(Health_Enthusiast healthEnthusiast)
        {
            try
            {
                var healthEnthusiastInDb = _context.Health_Enthusiasts.Single(m => m.Id == healthEnthusiast.Id);
                healthEnthusiastInDb.FirstName = healthEnthusiast.FirstName;
                healthEnthusiastInDb.LastName = healthEnthusiast.LastName;
                healthEnthusiastInDb.Height = healthEnthusiast.Height;
                healthEnthusiastInDb.StartingWeight = healthEnthusiast.StartingWeight;
                healthEnthusiastInDb.Sex = healthEnthusiast.Sex;
                healthEnthusiastInDb.Age = healthEnthusiast.Age;
                healthEnthusiastInDb.InitialCalorieIntake = healthEnthusiast.InitialCalorieIntake;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
