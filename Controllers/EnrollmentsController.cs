using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSys.Service.Interface;

namespace UniSys.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentsService _enrollmentsService;
        private readonly IStudentsService _studentsService;
        private readonly ISubjectsService _subjectsService;

        public EnrollmentsController(IEnrollmentsService enrollmentsService, IStudentsService studentsService, ISubjectsService subjectsService)
        {
            _enrollmentsService = enrollmentsService;
            _studentsService = studentsService;
            _subjectsService = subjectsService;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            IEnumerable<Enrollment> result = await _enrollmentsService.GetAllEnrollments();
            return View(result);
        }

        // GET: Enrollments/Details/5
        public IActionResult Details(int id)
        {
            Enrollment result = _enrollmentsService.GetEnrollmentByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Enrollment record not found.";
                return RedirectToAction("Index", "Enrollments");
            }

            return View(result);
        }

        // GET: Enrollments/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(new List<Student>(), "Student_ID", "Name");
            IEnumerable<Student> students = await _studentsService.GetAllStudents();
            if (students != null)
            {
                ViewBag.Students = students;
            }
            // Empty list initially
            ViewBag.Subjects = new SelectList(new List<Subject>(), "Subject_ID", "Title");
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Student_ID, int Subject_ID)
        {
            ViewBag.Students = new SelectList(new List<Student>(), "Student_ID", "Name");
            IEnumerable<Student> students = await _studentsService.GetAllStudents();
            if (students != null)
            {
                ViewBag.Students = students;
            }
            int remainingSlots = await _enrollmentsService.GetRemainingEnrollmentSlots(Student_ID);

            if (remainingSlots > 0)
            {
                if (ModelState.IsValid)
                {
                    if(Subject_ID == 0)
                    {
                        ModelState.AddModelError(string.Empty, "NO available subject to enroll.");
                    }
                    else
                    {
                        int result = await _enrollmentsService.CreateEnrollment(Student_ID, Subject_ID);
                        if (result == -1)
                        {
                            TempData["ErrorMessage"] = "Enrollment record is already exist.";
                        }
                        else
                        {
                            TempData["SuccessMessage"] = "Enrollment record created successfully.";
                        }
                        return RedirectToAction(nameof(Index));
                    } 
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Student have enroll 10 subject and NO avaliable slot to enroll new subject.");
            }
            return View();
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Enrollment enrollment = _enrollmentsService.GetEnrollmentByID(id);
            IEnumerable<Student> students = await _studentsService.GetAllStudents();
            ViewBag.Students = students;
            IEnumerable<Subject> subject = await _subjectsService.GetAllSubjects();
            ViewBag.subjects = new SelectList(subject, "Subject_ID", "Title");
            if (enrollment == null)
            {
                TempData["ErrorMessage"] = "Enrollment record not found.";
                return RedirectToAction("Index", "Enrollments");
            }
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int Student_ID, int Subject_ID)
        {
            IEnumerable<Student> students = await _studentsService.GetAllStudents();
            ViewBag.Students = students;
            IEnumerable<Subject> subject = await _subjectsService.GetAvailableSubject(id);
            ViewBag.subjects = new SelectList(subject, "Subject_ID", "Title");
            if (ModelState.IsValid)
            {
                int result = await _enrollmentsService.UpdateEnrollment(id, Student_ID, Subject_ID);
                try
                {
                    switch (result)
                    {
                        case 1:
                            TempData["SuccessMessage"] = "Enrollment update successfully.";
                            return RedirectToAction(nameof(Index));
                        case 2:
                            TempData["ErrorMessage"] = "Enrollment record is already exist.";
                            return RedirectToAction(nameof(Index));
                        default:
                            ModelState.AddModelError(string.Empty, "Unknown error occurred.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the exam result.");
                    Console.WriteLine(ex.ToString());
                }
            }
            return View();
        }

        public async Task<IActionResult> GetAvailableSubject(int id)
        {
            IEnumerable<Subject> subjects = await _subjectsService.GetAvailableSubject(id);
            SelectList subjectList = new(subjects, "Subject_ID", "Title");
            return Json(subjectList);
        }
    }
}
