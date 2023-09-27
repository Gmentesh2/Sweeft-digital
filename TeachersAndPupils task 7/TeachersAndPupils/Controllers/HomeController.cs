using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeachersAndPupils.Models;

namespace TeachersAndPupils.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var result = GetTeachersByStudent("გიორგი");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private Teacher[] GetTeachersByStudent(string name)
        {
            var result = _context.TeacherPupils
                .Include("Teacher")
                .Include("Pupil")
                .Where(tp => tp.Pupil.FirstName.Contains(name))
                .Select(tp => tp.Teacher)
                .ToArray();

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}