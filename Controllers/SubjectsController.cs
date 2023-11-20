using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSys.Service.Interface;

namespace UniSys.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectsService _subjectsService;
        private readonly ITutorsService _tutorService;

        public SubjectsController(ISubjectsService subjectsService, ITutorsService tutorsService)
        {
            _subjectsService = subjectsService;
            _tutorService = tutorsService;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            IEnumerable<Subject> subject = await _subjectsService.GetAllSubjects();
            await _tutorService.GetAllTutors();
            return View(subject);
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            await _tutorService.GetAllTutors();
            Subject result = _subjectsService.GetSubjectByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Subject record not found.";
                return RedirectToAction("Index","Subjects");
            }
            return View(result);
        }

        // GET: Subjects/Create
        public async Task<IActionResult> Create()
        {
            IEnumerable<Tutor> result = await _tutorService.GetAllTutors();
            ViewBag.tutors = new SelectList(result, "Tutor_ID", "Name");
            return View();
        }

        // POST: Subjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Title, int Tutor_ID)
        {
            IEnumerable<Tutor> result = await _tutorService.GetAllTutors();
            ViewBag.tutors = new SelectList(result, "Tutor_ID", "Name");
            if (ModelState.IsValid)
            {
                await _subjectsService.CreateSubject(Title, Tutor_ID);
                TempData["SuccessMessage"] = "Subject created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<Tutor> tutor = await _tutorService.GetAllTutors();
            ViewBag.tutors = new SelectList(tutor, "Tutor_ID", "Name");
            Subject result = _subjectsService.GetSubjectByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Subject record not found.";
                return RedirectToAction("Index", "Subjects");
            }
            return View(result);
        }

        // POST: Subjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Title, int Tutor_ID)
        {
            IEnumerable<Tutor> tutor = await _tutorService.GetAllTutors();
            ViewBag.tutors = new SelectList(tutor, "Tutor_ID", "Name");
            if (ModelState.IsValid)
            {
                await _subjectsService.UpdateSubject(id, Title, Tutor_ID);
                TempData["SuccessMessage"] =$"Subject ( ID: {id} )( {Title} ) update successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            IEnumerable<Tutor> tutor = await _tutorService.GetAllTutors();
            ViewBag.tutors = new SelectList(tutor, "Tutor_ID", "Name");
            Subject result = _subjectsService.GetSubjectByID(id);
            if(result == null)
            {
                TempData["ErrorMessage"] = "Subject record not found.";
                return RedirectToAction("Index", "Subject");
            }
            return View(result);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _subjectsService.SoftDeleteSubject(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
