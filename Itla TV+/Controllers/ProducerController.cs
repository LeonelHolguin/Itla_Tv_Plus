using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Itla_TV_.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ProducerService _producerService;

        public ProducerController(ProducerService producerService) 
        { 
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _producerService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            ProducerViewModel producerVM = new ProducerViewModel();

            return View("SaveProducer", producerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProducerViewModel producerVM)
        {
            if (!ModelState.IsValid)
                return View("SaveProducer", producerVM);

            await _producerService.Add(producerVM);
            return RedirectToRoute(new { controller = "Producer", action = "Index"});
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveProducer", await _producerService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProducerViewModel producerVM)
        {
            if (!ModelState.IsValid)
                return View("SaveProducer", producerVM);

            await _producerService.Update(producerVM);
            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _producerService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int ProducerId)
        {
            await _producerService.Delete(ProducerId);
            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }
    }
}
