using Application.Repositories;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Itla_TV_.Controllers
{
    public class GenderController : Controller
    {
        private readonly GenderService _genderService;
        private readonly SerieService _serieService;

        public GenderController(GenderService genderService, SerieService serieService)
        {
            _genderService = genderService;
            _serieService = serieService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _genderService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            GenderViewModel genderVM = new GenderViewModel();

            return View("SaveGender", genderVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenderViewModel genderVM)
        {
            if (!ModelState.IsValid)
                return View("SaveGender", genderVM);

            await _genderService.Add(genderVM);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveGender", await _genderService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GenderViewModel genderVM)
        {
            if (!ModelState.IsValid)
                return View("SaveGender", genderVM);

            await _genderService.Update(genderVM);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _genderService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int GenderId)
        {
            var serieList = await _serieService.GetAllViewModel();
            var seriesWithThisAsSecondary = serieList.Where(s => s.SecondaryGender?.GenderId == GenderId).ToList();

            foreach (var serie in seriesWithThisAsSecondary)
            {
                await _serieService.UpdateSecondaryGender(serie.SerieId, null);
            }

            await _genderService.Delete(GenderId);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }
    }
}
