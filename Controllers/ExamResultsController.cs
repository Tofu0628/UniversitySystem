using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSys.Service.Interface;

namespace UniSys.Controllers
{
    public class ExamResultsController : Controller
    {
        private readonly IExamResultsService _examResultsService;
        private readonly IStudentsService _studentsService;
        private readonly ISubjectsService _subjectsService;

        public ExamResultsController(IStudentsService studentsService,IExamResultsService examResultsService, ISubjectsService subjectsService)
        {
            _studentsService = studentsService;
            _examResultsService = examResultsService;
            _subjectsService = subjectsService;
        }

        // GET: ExamResults
        public async Task<IActionResult> Index()
        {
            IEnumerable<ExamResult> result = await _examResultsService.GetAllExamResults();
            return View(result);
        }

        // GET: ExamResults/Create
        public async Task<IActionResult> Create()
        {
            IEnumerable<Student> students = await _studentsService.GetAllStudents();
            ViewBag.Students = students;
            // Empty list initially
            ViewBag.Subjects = new SelectList(new List<Subject>(), "Subject_ID", "Title"); 
            return View();
        }

        // POST: ExamResults/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Student_ID, int Subject_ID, decimal mark, DateTime ExamDate)
        {
            IEnumerable<Student> students = await _studentsService.GetAllStudents();
            ViewBag.Students = students;
            if (ModelState.IsValid)
            {
                try
                {
                    if (Subject_ID == 0 && mark == 0)
                    {
                        ModelState.AddModelError(string.Empty, "No subject avaliable for this student to create exam result.");
                        return View();
                    }
                    int status = await _examResultsService.CreateExamResult(Student_ID, Subject_ID, mark, ExamDate);

                    switch (status)
                    {
                        case 1:
                            ModelState.AddModelError(string.Empty, "Student is not enrolled in this subject.");
                            break;
                        case 2:
                            ModelState.AddModelError(string.Empty, "Exam result exam result already exists");
                            break;
                        case 3:
                            TempData["SuccessMessage"] = "Exam result record created successfully.";
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

        // GET: ExamResults/Details/5
        public IActionResult Details(int id)
        {
            ExamResult result = _examResultsService.GetExamResultByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Exam Result record not found.";
                return RedirectToAction("Index", "ExamResults");
            }
            return View(result);
        }

        // GET: ExamResults/Edit/5
        public IActionResult Edit(int id)
        {
            ExamResult result = _examResultsService.GetExamResultByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Exam Result record not found.";
                return RedirectToAction("Index", "ExamResults");
            }
            return View(result);
        }

        // POST: ExamResults/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, decimal mark, DateTime ExamDate)
        {
            if (ModelState.IsValid)
            {
                await _examResultsService.UpdateExamResult(id,mark,ExamDate);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: ExamResults/Delete/5
        public IActionResult Delete(int id)
        {
            ExamResult result = _examResultsService.GetExamResultByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Exam Result record not found.";
                return RedirectToAction("Index", "ExamResults");
            }
            return View(result);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _examResultsService.SoftDeleteExamResult(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetSubjectsForStudent(int id)
        {
            IEnumerable<Subject> subjects = _subjectsService.GetSubjectsForStudent(id);
            SelectList subjectList = new(subjects, "Subject_ID", "Title");
            return Json(subjectList);
        }
    }
}
