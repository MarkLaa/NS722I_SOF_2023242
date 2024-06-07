using Microsoft.AspNetCore.Mvc;
using Féléves_Szerveroldali.Models;
using Féléves_Szerveroldali.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Féléves_Szerveroldali.Controllers
{
    public class CsapatController : Controller
    {
        IEmberRepository ember_repository;
        ICsapatRepository csapat_repository;
        IFeladatRepository feladatRepository;
        private readonly UserManager<SiteUser> userManager;
        public CsapatController(IEmberRepository repository, ICsapatRepository csrepo, IFeladatRepository feladatRepository, UserManager<SiteUser> userManager)
        {
            ember_repository = repository;
            csapat_repository = csrepo;
            this.feladatRepository = feladatRepository;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            TaskIndexViewModell taskIndexViewModell = new TaskIndexViewModell
            {
                Emberek = this.ember_repository.Read().ToList(),
                Csapatok = this.csapat_repository.Read().ToList()
            };
			var principar = this.User;
			var users = await userManager.GetUserAsync(principar);
			return View(taskIndexViewModell);
        }
		public async Task<IActionResult> GetImage(string userid)
		{
			//var principal = this.User;
			var user = userManager.Users.FirstOrDefault(x => x.Id == userid);
			return new FileContentResult(user.Data, user.ContentType);
		}
		[HttpGet]//ide is combiner
        public IActionResult Create()
        {
            TaskIndexViewModell taskIndexViewModell = new TaskIndexViewModell
            {
                Emberek = this.ember_repository.Read().ToList(),
                Csapatok = this.csapat_repository.Read().ToList()
            };
            return View(taskIndexViewModell);
        }

        [HttpPost]
        public IActionResult Create(Ember ember)
        {
            if (!ModelState.IsValid)
            {
                return View(ember);
            }
            ember.OwnerId = userManager.GetUserId(this.User);
            ember_repository.Create(ember);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ember_repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var ember = ember_repository.Read(id);
            TaskUpdateViewModell da = new TaskUpdateViewModell
            {
                ember = this.ember_repository.Read(id),
                repo2 = this.csapat_repository.Read().ToList(),
            };
            return View(da);
        }
        [HttpPost]
        public IActionResult Update(Ember ember)
        {
            ember_repository.Update(ember);
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]//ide is combiner
        public IActionResult CreateCsapat()
        {
            TaskIndexViewModell taskIndexViewModell = new TaskIndexViewModell
            {
                Emberek = this.ember_repository.Read().ToList(),
                Csapatok = this.csapat_repository.Read().ToList()
            };
            return View(taskIndexViewModell);
        }

        [HttpPost]
        public IActionResult CreateCsapat(Csapat csapat)
        {
            if (!ModelState.IsValid)
            {
                return View(csapat);
            }
            csapat.OwnerId = userManager.GetUserId(this.User);
            csapat_repository.Create(csapat);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeleteCsapat(int id)
        {
            csapat_repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UpdateCsapat(int id)
        {
            TaskFeladatUpdateViewModel da = new TaskFeladatUpdateViewModel
            {
                Csapat = csapat_repository.Read(id),
                Emberek = this.ember_repository.Read().ToList(),
                Feladatok = this.feladatRepository.Read().ToList(),
            };
            return View(da);
        }
        [HttpPost]
        public IActionResult UpdateCsapat(Csapat csapat)
        {

            csapat_repository.Update(csapat);
            return RedirectToAction(nameof(Index));
        }








    }
}
