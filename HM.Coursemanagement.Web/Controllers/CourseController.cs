using HM.CourseManagement.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HM.CourseManagement.Web.Controllers
{
    public class CourseController : Controller
    {
        public ApplicationDbContext _dbContext { get; }

        public CourseController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var courses = this._dbContext.Course;
            return View(courses);
        }
        
        public IActionResult Details(int Id)
        {
            var course = this._dbContext.Find<Course>(Id);
            return View(course);
        }
    }
}