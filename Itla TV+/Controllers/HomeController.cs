using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Itla_TV_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Itla_TV_.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieService _serieService;
        private readonly ProducerService _producerService;

        public HomeController(SerieService serieService, ProducerService producerService)
        {
            _serieService = serieService;
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var homeList = new HomeViewModel();

            var serieList = await _serieService.GetAllViewModel();
            var producerList = await  _producerService.GetAllViewModel();

            homeList.Series = serieList.Select(serie => new SerieViewModel
            {
                SerieId = serie.SerieId,
                SerieName = serie.SerieName,
                ImagePath = serie.ImagePath,
                VideoPath = serie.VideoPath,
                Producer = new ProducerViewModel
                {
                    ProducerId = serie.Producer!.ProducerId,
                    ProducerName = serie.Producer.ProducerName
                },
                PrimaryGender = new GenderViewModel
                {
                    GenderId = serie.PrimaryGender!.GenderId,
                    GenderName = serie.PrimaryGender.GenderName
                },
                SecondaryGender = serie.SecondaryGender == null ? null : new GenderViewModel
                {
                    GenderId = serie.SecondaryGender.GenderId,
                    GenderName = serie.SecondaryGender.GenderName
                }

            }).ToList();

            homeList.Producers = producerList.Select(producer => new ProducerViewModel
            {
                ProducerId = producer.ProducerId,
                ProducerName = producer.ProducerName

            }).ToList();

            return View(homeList);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string serieName)
        {
            var homeList = new HomeViewModel();

            var serieList = await _serieService.GetAllViewModel(serieName);
            var producerList = await _producerService.GetAllViewModel();

            homeList.Series = serieList.Select(serie => new SerieViewModel
            {
                SerieId = serie.SerieId,
                SerieName = serie.SerieName,
                ImagePath = serie.ImagePath,
                VideoPath = serie.VideoPath,
                Producer = new ProducerViewModel
                {
                    ProducerId = serie.Producer!.ProducerId,
                    ProducerName = serie.Producer.ProducerName
                },
                PrimaryGender = new GenderViewModel
                {
                    GenderId = serie.PrimaryGender!.GenderId,
                    GenderName = serie.PrimaryGender.GenderName
                },
                SecondaryGender = serie.SecondaryGender == null ? null : new GenderViewModel
                {
                    GenderId = serie.SecondaryGender.GenderId,
                    GenderName = serie.SecondaryGender.GenderName
                }

            }).ToList();

            homeList.Producers = producerList.Select(producer => new ProducerViewModel
            {
                ProducerId = producer.ProducerId,
                ProducerName = producer.ProducerName

            }).ToList();

            return View(homeList);
        }
    }
}