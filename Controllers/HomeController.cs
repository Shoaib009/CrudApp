using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CrudDatabase _database;

        public HomeController(ILogger<HomeController> logger, CrudDatabase database)
        {
            _logger = logger;
            _database = database;
        }
        public IActionResult Create(string Name, string Designation)
        {
            CrudApplications crud_one = new CrudApplications();
            crud_one.Name = Name;
            crud_one.Designation = Designation;
            _database.CrudApplication.Add(crud_one);
            _database.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int Id)
        {
            var crud_one = _database.CrudApplication.FirstOrDefault(x => x.Id == Id);
            if (crud_one != null)
            {
                _database.CrudApplication.Remove(crud_one);
                _database.SaveChanges();
            }
            else
            {
                Console.WriteLine("No value found");
            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Update(int id, string Name, string Designation)
        {
            //update the name and designation value in crudapplication table
            //step-1 take values from the user id, name, designation

            //step-2 match if id exits in the table or not
            var crud_two = _database.CrudApplication.FirstOrDefault(x => x.Id == id);

            //step-3 if match completed then change the name and desigantion value which user provided in the argument and save database
            if (crud_two != null)
            {
                crud_two.Name = Name;
                crud_two.Designation = Designation;
                _database.Update(crud_two);
                _database.SaveChanges();

            }
            //step-4 if match not completed then show a message box that requested data not found in the table and close the program.
            if (crud_two == null)
            {
                Console.WriteLine("No Values matched.");
            }
            return RedirectToAction("Index", "Home");


        }

        public List<CrudApplications> ShowData()
        {
            var crud_showdata = _database.CrudApplication.ToList();
            return crud_showdata;


        }
        public IActionResult Index()
        {
            var crud_showdata = _database.CrudApplication.ToList();
            return View(crud_showdata);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateRecord()
        {
            return View();
        }
        public IActionResult Updates(int id)
        {
            var pickValue = _database.CrudApplication.FirstOrDefault(x => x.Id == id);
            if (pickValue == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(pickValue);
            }
        }

        public IActionResult Deleted(int id)
        {
            var pickValue = _database.CrudApplication.FirstOrDefault(x => x.Id == id);
            if (pickValue == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(pickValue);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
