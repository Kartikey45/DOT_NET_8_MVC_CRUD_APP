using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models.Students;
using StudentPortal.Models.ViewModels;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult Add(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var Id = new Guid(id);
                var students = StudentList.StudentsList.Where(x => x.Id == Id).FirstOrDefault();
                var viewModel = new AddStudentViewModel()
                {
                    Id = students.Id,
                    Name = students.Name,
                    Email = students.Email,
                    PhoneNumber = students.PhoneNumber,
                    Subscribed = students.Subscribed
                };
                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddStudentViewModel viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var student = new Student()
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Subscribed = viewModel.Subscribed
            };
            if (viewModel.Id == null)
            {
                student.Id = Guid.NewGuid();
                // add
                StudentList.StudentsList.Add(student);
            }
            else
            {
                student.Id = viewModel.Id;
                var index = StudentList.StudentsList.FindIndex(x => x.Id == student.Id);
                // update
                if (index >= 0) {
                    StudentList.StudentsList.RemoveAt(index);
                    StudentList.StudentsList.Add(student);
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var students = StudentList.StudentsList
            .Select(s => new AddStudentViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Subscribed = s.Subscribed
            })
            .ToList();
            ViewData["StudentList"] = students;
            return View();
        }


    }
}
