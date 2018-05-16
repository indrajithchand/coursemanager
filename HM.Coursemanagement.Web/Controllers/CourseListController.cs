using HM.CourseManagement.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HM.CourseManagement.Web.Controllers
{
    public class CourseListController : Controller
    {
        public ApplicationDbContext _dbContext { get; }

        public CourseListController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var courses = this._dbContext.CourseList
               .Include(p => p.Course)
               .Include(p => p.Faculty);

            return View(courses);
        }

        public IActionResult Details(int Id)
        {
            var course = this._dbContext.CourseList
               .Include(p => p.Course)
               .Include(p => p.Faculty).FirstOrDefault(x => x.Id == Id);

            return View(course);
        }
    }
}