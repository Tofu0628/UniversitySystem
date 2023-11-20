using Microsoft.AspNetCore.Mvc;
using UniSys.Service.Interface;

namespace UniSys.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _studentsService;
        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> result = await _studentsService.GetAllStudents();
            return View(result);
        }

        // GET: Students/Details/5
        public IActionResult Details(int id)
        {
            Student result = _studentsService.GetStudentByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Student record not found.";
                return RedirectToAction("Index", "Students");
            }
            return View(result);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentsService.CreateStudent(student);
                TempData["SuccessMessage"] = "Student record created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            Student result = _studentsService.GetStudentByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Student record not found.";
                return RedirectToAction("Index", "Students");
            }
            return View(result);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Student_ID)
            {
                return RedirectToAction("Index", "Students");
            }

            if (ModelState.IsValid)
            {
                await _studentsService.UpdateStudent(id, student);
                TempData["SuccessMessage"] = "Student record updated successfully.";
                return RedirectToAction(nameof(Index));
             }
            return View(student);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            Student result = _studentsService.GetStudentByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Student record not found.";
                return RedirectToAction("Index", "Students");
            }
            return View(result);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentsService.SoftDeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
