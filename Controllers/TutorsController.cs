using Microsoft.AspNetCore.Mvc;
using UniSys.Service.Interface;

namespace UniSys.Controllers
{
    public class TutorsController : Controller
    {
        private readonly ITutorsService _tutorsService;

        public TutorsController(ITutorsService tutorsService)
        {
            _tutorsService = tutorsService;
        }

        // GET: Tutors
        public async Task<IActionResult> Index()
        {
            IEnumerable<Tutor> result = await _tutorsService.GetAllTutors();
            return View(result);
        }

        // GET: Tutors/Details/5
        public IActionResult Details(int id)
        {
            Tutor result = _tutorsService.GetTutorByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Tutor not found.";
                return RedirectToAction("Index", "Tutors");
            }
            return View(result);
        }

        // GET: Tutors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tutors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                await _tutorsService.CreateTutor(tutor);
                TempData["SuccessMessage"] = "Tutor record created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(tutor);
        }

        // GET: Tutors/Edit/5
        public IActionResult Edit(int id)
        {
            Tutor result = _tutorsService.GetTutorByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Tutor record not found.";
                return RedirectToAction("Index", "Tutors");
            }
            return View(result);
        }

        // POST: Tutors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tutor tutor)
        {
            if (id != tutor.Tutor_ID)
            {
                return RedirectToAction("Index", "Tutors");
            }
            if (ModelState.IsValid)
            {
                await _tutorsService.UpdateTutor(tutor);
                TempData["SuccessMessage"] = "Tutor record updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(tutor);
        }

        // GET: Tutors/Delete/5
        public IActionResult Delete(int id)
        {
            Tutor result = _tutorsService.GetTutorByID(id);
            if (result == null)
            {
                TempData["ErrorMessage"] = "Tutor record not found.";
                return RedirectToAction("Index", "Tutors");
            }
            return View(result);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tutorsService.SoftDeleteTutor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
