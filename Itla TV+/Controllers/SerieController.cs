using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itla_TV_.Controllers
{
    public class SerieController : Controller
    {

        private readonly SerieService _serieService;
        private readonly ProducerService _producerService;
        private readonly GenderService _genderService;

        public SerieController(SerieService serieService, ProducerService producerService, GenderService genderService)
        {
            _serieService = serieService;
            _producerService = producerService;
            _genderService = genderService;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _serieService.GetAllViewModel());
        }

        public async Task<IActionResult> Details(int id) 
        {
            return View(await _serieService.GetById(id));
        }

        public async Task<IActionResult> Create()
        {
            SaveSerieViewModel SaveSerieVM = new SaveSerieViewModel();

            var producerList = await _producerService.GetAllViewModel();
            var genderList = await _genderService.GetAllViewModel();

            SaveSerieVM.Producers = producerList;
            SaveSerieVM.Genders = genderList;

            return View("SaveSerie", SaveSerieVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel SaveSerieVM)
        {
            if (!ModelState.IsValid)
            {
                var producerList = await _producerService.GetAllViewModel();
                var genderList = await _genderService.GetAllViewModel();

                SaveSerieVM.Producers = producerList;
                SaveSerieVM.Genders = genderList;

                return View("SaveSerie", SaveSerieVM);

            }

            await _serieService.Add(SaveSerieVM);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var SaveSerieVM = await _serieService.GetByIdSaveSerieViewModel(id);

            var producerList = await _producerService.GetAllViewModel();
            var genderList = await _genderService.GetAllViewModel();

            SaveSerieVM.Producers = producerList;
            SaveSerieVM.Genders = genderList;

            return View("SaveSerie", SaveSerieVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel SaveSerieVM)
        {
            if (!ModelState.IsValid)
            {
                var producerList = await _producerService.GetAllViewModel();
                var genderList = await _genderService.GetAllViewModel();

                SaveSerieVM.Producers = producerList;
                SaveSerieVM.Genders = genderList;

                return View("SaveSerie", SaveSerieVM);
            }

            await _serieService.Update(SaveSerieVM);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {

            return View(await _serieService.GetByIdSaveSerieViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int SerieId)
        {
            await _serieService.Delete(SerieId);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }
    }
}
