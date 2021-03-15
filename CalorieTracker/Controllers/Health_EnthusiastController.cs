using CalorieTracker.Data;
using CalorieTracker.Models;
using CalorieTracker.Models.Example;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalorieTracker.Controllers
{
    public class Health_EnthusiastController : Controller
    {
        private readonly NutritionixService _nutritionixService;
        private readonly ApplicationDbContext _context;

        public Health_EnthusiastController(ApplicationDbContext context, NutritionixService nutritionixService)
        {
            _context = context;
            _nutritionixService = nutritionixService;
        }

        // GET: HomeController1
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var healthEnthusiast = _context.Health_Enthusiasts.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            if (healthEnthusiast == null)
            {
                return RedirectToAction(nameof(Create));
            }
            ViewBag.Id = healthEnthusiast.Id;
            if (healthEnthusiast.InitialCalorieIntake == 0)
            {
                return RedirectToAction("GetInitialCalorieIntake", new { id = healthEnthusiast.Id });
            }
            if (healthEnthusiast.Activity == null)
            {
                return RedirectToAction("GetActivity", new { id = healthEnthusiast.Id });
            }
            if (healthEnthusiast.GoalCalories == null)
            {
                return RedirectToAction("Recomendations", new { id = healthEnthusiast.Id });
            }
            var healthEnthusiastFoodDiary = _context.FoodDiaries.Where(c => c.HealthEnthusiastId == healthEnthusiast.Id).ToList();
            ViewBag.Id = healthEnthusiast.Id;
            if (healthEnthusiastFoodDiary.Count == 0)
            {
                return RedirectToAction("Details", new { id = healthEnthusiast.Id });
            }
            return View(healthEnthusiastFoodDiary);

            // Creating a Profile 
            // Setting goals 
            // Asking about initial eating habits
            // Ask about Activity 
            // Choosing Recomendations
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var healthEnthusiast = _context.Health_Enthusiasts.Where(c => c.IdentityUserId ==
            userId).FirstOrDefault();

            // var healthEnthusiast = _context.Health_Enthusiasts.SingleOrDefault(m => m.Id == id);
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
                healthEnthusiast.InitialCalorieIntake = 0;
                _context.Add(healthEnthusiast);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Health_Enthusiast healthEnthusiast)
        {
            try
            {
                var healthEnthusiastInDb = _context.Health_Enthusiasts.Single(m => m.Id == healthEnthusiast.Id);
                healthEnthusiastInDb.FirstName = healthEnthusiast.FirstName;
                healthEnthusiastInDb.LastName = healthEnthusiast.LastName;
                healthEnthusiastInDb.Height = healthEnthusiast.Height;
                healthEnthusiastInDb.StartingWeight = healthEnthusiast.StartingWeight;
                healthEnthusiastInDb.GoalWeight = healthEnthusiast.GoalWeight;
                healthEnthusiastInDb.Sex = healthEnthusiast.Sex;
                healthEnthusiastInDb.Age = healthEnthusiast.Age;
                healthEnthusiastInDb.Email = healthEnthusiast.Email;
                healthEnthusiastInDb.InitialCalorieIntake = healthEnthusiast.InitialCalorieIntake;
                healthEnthusiastInDb.GoalCalories = healthEnthusiast.GoalCalories;
                healthEnthusiastInDb.WeeklyWeightLoss = healthEnthusiast.WeeklyWeightLoss;
                healthEnthusiastInDb.Activity = healthEnthusiast.Activity;

                _context.SaveChanges();

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

        public IActionResult GetInitialCalorieIntake(int id)
        {
            var initialCals = _context.InitialCalorieIntakeLists.ToList();
            
            return View(initialCals);            
        }
        public IActionResult AddInitialCalorieIntake(int id)
        {
            
            return View();            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInitialCalorieIntake(InitialCalorieIntakeList initialCals, int id)
        {
            try
            {                
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var healthEnthusiast = _context.Health_Enthusiasts.Where(c => c.IdentityUserId ==
                userId).FirstOrDefault();

                var caloriesInDb = _context.InitialCalorieIntakeLists.Single(m => m.Id == initialCals.Id);

                var calorieInput = caloriesInDb.Calories;
                healthEnthusiast.InitialCalorieIntake += calorieInput;
                _context.SaveChanges();
                return RedirectToAction(nameof(GetInitialCalorieIntake));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult GetActivity(int id)
        {
            // On a scale 1-3 how active are you? One being not very active and 3 being active 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetActivity(Health_Enthusiast healthEnthusiastActivity, int id)
        {
            try
            {
                //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var healthEnthusiast = _context.Goals.Where(c => c.HealthEnthusiastId ==
                //int.Parse(userId)).FirstOrDefault();

                healthEnthusiastActivity.Id = id;
                var healthEnthusiastInDb = _context.Health_Enthusiasts.Single(m => m.Id == healthEnthusiastActivity.Id);
            
                healthEnthusiastInDb.Activity = healthEnthusiastActivity.Activity;
                
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Recomendations(int id)
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Recomendations(Health_Enthusiast healthEnthusiast, int id)
        {
            try
            {
                // Getting Recomendations
                healthEnthusiast.Id = id;
                var healthEnthusiastInDb = _context.Health_Enthusiasts.Single(m => m.Id == healthEnthusiast.Id);

                if (healthEnthusiastInDb.Activity == 1)
                {
                    if (healthEnthusiastInDb.Age > 15 && healthEnthusiastInDb.Age <= 21)
                    {
                        healthEnthusiastInDb.GoalCalories = 2600;
                        healthEnthusiastInDb.WeeklyWeightLoss = .5;
                    }
                    if (healthEnthusiastInDb.Age > 21 && healthEnthusiastInDb.Age <= 30)
                    {
                        healthEnthusiastInDb.GoalCalories = 2400;
                        healthEnthusiastInDb.WeeklyWeightLoss = .5;
                    }
                    if (healthEnthusiastInDb.Age > 30 && healthEnthusiastInDb.Age <= 40)
                    {
                        healthEnthusiastInDb.GoalCalories = 2400;
                        healthEnthusiastInDb.WeeklyWeightLoss = .5;
                    }
                    if (healthEnthusiastInDb.Age > 40 && healthEnthusiastInDb.Age <= 50)
                    {
                        healthEnthusiastInDb.GoalCalories = 2400;
                        healthEnthusiastInDb.WeeklyWeightLoss = .5;
                    }
                    if (healthEnthusiastInDb.Age < 50 && healthEnthusiastInDb.Age <= 60)
                    {
                        healthEnthusiastInDb.GoalCalories = 2200;
                        healthEnthusiastInDb.WeeklyWeightLoss = .5;
                    }
                    if (healthEnthusiastInDb.Age >= 60)
                    {
                        healthEnthusiastInDb.GoalCalories = 2000;
                        healthEnthusiastInDb.WeeklyWeightLoss = .5;
                    }

                }
                else if (healthEnthusiastInDb.Activity == 2)
                {
                    if (healthEnthusiastInDb.Age > 15 && healthEnthusiastInDb.Age <= 21)
                    {
                        healthEnthusiast.GoalCalories = 2800;
                        healthEnthusiast.WeeklyWeightLoss = 1;
                    }
                    if (healthEnthusiastInDb.Age > 21 && healthEnthusiastInDb.Age <= 30)
                    {
                        healthEnthusiastInDb.GoalCalories = 2800;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1;
                    }
                    if (healthEnthusiastInDb.Age > 30 && healthEnthusiastInDb.Age <= 40)
                    {
                        healthEnthusiastInDb.GoalCalories = 2600;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1;
                    }
                    if (healthEnthusiastInDb.Age > 40 && healthEnthusiastInDb.Age <= 50)
                    {
                        healthEnthusiastInDb.GoalCalories = 2400;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1;
                    }
                    if (healthEnthusiastInDb.Age > 50 && healthEnthusiastInDb.Age <= 60)
                    {
                        healthEnthusiastInDb.GoalCalories = 2400;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1;
                    }
                    if (healthEnthusiastInDb.Age >= 60)
                    {
                        healthEnthusiastInDb.GoalCalories = 2200;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1;
                    }
                }
                else
                {
                    if (healthEnthusiastInDb.Age > 15 && healthEnthusiastInDb.Age <= 21)
                    {
                        healthEnthusiastInDb.GoalCalories = 3200;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1.5;
                    }
                    if (healthEnthusiastInDb.Age > 21 && healthEnthusiast.Age <= 30)
                    {
                        healthEnthusiastInDb.GoalCalories = 3000;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1.5;
                    }
                    if (healthEnthusiastInDb.Age > 30 && healthEnthusiastInDb.Age <= 40)
                    {
                        healthEnthusiastInDb.GoalCalories = 2800;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1.5;
                    }
                    if (healthEnthusiastInDb.Age > 40 && healthEnthusiastInDb.Age <= 50)
                    {
                        healthEnthusiastInDb.GoalCalories = 2800;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1.5;
                    }
                    if (healthEnthusiastInDb.Age > 50 && healthEnthusiastInDb.Age <= 60)
                    {
                        healthEnthusiastInDb.GoalCalories = 2600;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1.5;
                    }
                    if (healthEnthusiastInDb.Age >= 60)
                    {
                        healthEnthusiastInDb.GoalCalories = 2600;
                        healthEnthusiastInDb.WeeklyWeightLoss = 1.5;
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("RecomendationDetails", new { id = healthEnthusiastInDb.Id });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult RecomendationDetails(int id)
        {
            var recomendedCals = _context.Health_Enthusiasts.SingleOrDefault(m => m.Id == id);
            return View(recomendedCals);
        }

        public ActionResult CreateFoodDiary()
        {
            var meals = _context.Meals.ToList();
            FoodDiary foodDiary = new FoodDiary()
            {
                Meals = new SelectList(meals, "Id", "Name")
            };
            return View(foodDiary);
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoodDiary(FoodDiary foodDiary)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var healthEnthusiast = _context.Health_Enthusiasts.Where(c => c.IdentityUserId ==
                userId).FirstOrDefault();                

                foodDiary.HealthEnthusiastId = healthEnthusiast.Id;                
                foodDiary.Meal = _context.Meals.Where(m => m.Id == foodDiary.MealId).FirstOrDefault();
                foodDiary.Meal.Name = foodDiary.Meal.Name;

                foodDiary.CalorieAmmount *= foodDiary.ServingSize;
                foodDiary.FatAmount *= foodDiary.ServingSize;
                foodDiary.ProteinAmount *= foodDiary.ServingSize;
                foodDiary.TodaysDate = foodDiary.TodaysDate.Date;
                
                _context.Add(foodDiary);                
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var meals = _context.Meals.ToList();
                FoodDiary foodDiaryRetry = new FoodDiary()
                {
                    Meals = new SelectList(meals, "Id", "Name")
                };
                return View(foodDiaryRetry);
            }
        }
        public ActionResult ViewProgress(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var healthEnthusiast = _context.Health_Enthusiasts.Where(c => c.IdentityUserId ==
            userId).FirstOrDefault();

            ViewBag.Initial = healthEnthusiast.InitialCalorieIntake;
            ViewBag.Goal = healthEnthusiast.GoalCalories;

            var healthEnthusiastFoodDiary = _context.FoodDiaries.Where(c => c.HealthEnthusiastId == healthEnthusiast.Id).ToList();
            int mealOneCalories = 0;
            int mealTwoCalories = 0;
            int mealThreeCalories = 0;
            int mealFourCalories = 0;
            int caloriesAccumulated = 0;
            List<string> dates = new List<string>();
            string stringifiedDates = " ";
            List<string> datesString = new List<string>();
            //Array array = new Array[datesString.Count];
            int dayOneCals = 0;
            int dayTwoCals = 0;
            int dayThreeCals = 0;
            foreach (var item in healthEnthusiastFoodDiary)
            {                
                if (item.MealId == 1 && item.TodaysDate == DateTime.Today)
                {
                    mealOneCalories += item.CalorieAmmount;                    
                    ViewBag.One = mealOneCalories;
                }
                if (item.MealId == 2 && item.TodaysDate == DateTime.Today)
                {
                    mealTwoCalories += item.CalorieAmmount;
                    ViewBag.Two = mealTwoCalories;
                }
                if (item.MealId == 3 && item.TodaysDate == DateTime.Today)
                {
                    mealThreeCalories += item.CalorieAmmount;
                    ViewBag.Three = mealThreeCalories;
                }
                if (item.MealId == 4 && item.TodaysDate == DateTime.Today)
                {
                    mealFourCalories += item.CalorieAmmount;
                    ViewBag.Four = mealFourCalories;                    
                }
                if (item.TodaysDate == DateTime.Today)
                {
                    caloriesAccumulated += item.CalorieAmmount;
                    ViewBag.Five = caloriesAccumulated;
                }
                stringifiedDates = item.TodaysDate.ToShortDateString();
                dates.Add(stringifiedDates);
                datesString = dates.Distinct().ToList();
                var array = datesString.ToArray();
                ViewBag.dates = array;

                foreach (var date in datesString)
                {
                    if (item.TodaysDate.ToShortDateString() == datesString[0])
                    {
                        dayOneCals += item.CalorieAmmount;
                        ViewBag.Day1 = dayOneCals;
                        continue;
                    }
                    if (item.TodaysDate.ToShortDateString() == datesString[1])
                    {
                        dayTwoCals += item.CalorieAmmount;
                        ViewBag.Day2 = dayTwoCals / 2;
                        continue;
                    }
                    if (item.TodaysDate.ToShortDateString() == datesString[2])
                    {
                        dayThreeCals += item.CalorieAmmount;
                        ViewBag.Day3 = dayThreeCals / 3;
                    }
                }
            }
            return View();
        }
        public IActionResult DeleteFood(int id)
        {
            var food = _context.FoodDiaries.SingleOrDefault(m => m.Id == id);
            _context.FoodDiaries.Remove(food);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult SendgridEmailSubmit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendgridEmailSubmit(Emailmodel emailmodel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var healthEnthusiast = _context.Health_Enthusiasts.Where(c => c.IdentityUserId ==
            userId).FirstOrDefault();
            emailmodel.To = healthEnthusiast.Email;
            _context.Emails.Add(emailmodel);
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendgridEmailSubmit2(Emailmodel emailmodel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var healthEnthusiast = _context.Health_Enthusiasts.Where(c => c.IdentityUserId ==
            userId).FirstOrDefault();
            emailmodel.To = healthEnthusiast.Email;

            ViewData["Message"] = "Email Sent!!!...";
            Example emailexample = new Example();
            await emailexample.Execute(emailmodel.To);

            return RedirectToAction(nameof(Index));
        }

        //public IActionResult FindNutritionItem(string SearchString)
        //{            
        //    return View();
        //}
        //[HttpPost]
        public async Task<IActionResult> FindNutritionItem([FromServices] NutritionixService nutritionixService, string SearchString)
        {
            
            NutritionixFoodItem nutritionixFoodItem = await nutritionixService.GetSearchedNutritionItem(SearchString);
            return View(nutritionixFoodItem);
        }
    }
}
