using Microsoft.AspNetCore.Mvc;
using Féléves_Szerveroldali.Models;
using Féléves_Szerveroldali.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Féléves_Szerveroldali.Controllers
{
    [Route("[controller]")]
    public class FeladatController : Controller
    {
        IFeladatRepository feladatRepository;
        ICsapatRepository csapatRepository;
        IEmberRepository emberRepository;
        private readonly UserManager<SiteUser> userManager;
        public FeladatController(IFeladatRepository feladatRepository, ICsapatRepository csapatRepository, IEmberRepository emberRepository, UserManager<SiteUser> userManager)
        {
            this.feladatRepository = feladatRepository;
            this.csapatRepository = csapatRepository;
            this.emberRepository = emberRepository;
            this.userManager = userManager;
        }

        [Authorize]
		[HttpGet("Index")]
		public async Task<IActionResult> Index()
        {
            FeladatIndexViewModell taskIndexViewModell = new FeladatIndexViewModell
            {
                Feladatok = this.feladatRepository.Read().ToList(),
                Csapatok = this.csapatRepository.Read().ToList()
            };
            var principar = this.User;
            var users = await userManager.GetUserAsync(principar);
            return View(taskIndexViewModell);
        }
		[HttpGet("GetImage")]
		public async Task<IActionResult> GetImage(string userid)
        {
            //var principal = this.User;
            var user = userManager.Users.FirstOrDefault(x => x.Id == userid);
            return new FileContentResult(user.Data, user.ContentType);
        }

		[HttpGet("Create")]
		public IActionResult Create()
        {
            return View();
        }

		[HttpPost("Create")]
		public IActionResult Create(Feladat feladat)
        {
            if (!ModelState.IsValid)
            {
                return View(feladat);
            }

            feladat.OwnerId = userManager.GetUserId(this.User);

            feladatRepository.Create(feladat);
            return RedirectToAction(nameof(Index));
        }
		[HttpGet("Delete")]
		public IActionResult Delete(int id)
        {
            feladatRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
		[HttpGet("Update")]
		public IActionResult Update(int id)
        {
            var feladat = feladatRepository.Read(id);
            return View(feladat);
        }
		[HttpPost("Update")]
		public IActionResult Update(Feladat feladat)
        {
            feladatRepository.Update(feladat);
            return RedirectToAction(nameof(Index));
        }
		[HttpGet("GetData")]
		public IActionResult GetData()
		{
            var data = new List<Csapat>();

            data = this.csapatRepository.Read().ToList();
			
			return Ok(data);
		}
	}
}
