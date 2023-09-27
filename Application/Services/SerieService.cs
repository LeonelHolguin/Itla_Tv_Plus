using Application.Repositories;
using Application.ViewModels;
using Database.Models;
using Database.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SerieService
    {
        private readonly SerieRepository _serieRepository;

        public SerieService(SerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }
        public async Task Add(SaveSerieViewModel serieToSave)
        {
            Serie serie = new();
            serie.SerieName = serieToSave.SerieName;
            serie.ImagePath = serieToSave.ImagePath;
            serie.VideoPath = serieToSave.VideoPath;
            serie.ProducerId = serieToSave.ProducerId;
            serie.PrimaryGenderId = serieToSave.PrimaryGenderId;
            serie.SecondaryGenderId = serieToSave.SecondaryGenderId == 0 ? null : serieToSave.SecondaryGenderId;

            await _serieRepository.AddAsync(serie);
        }

        public async Task Update(SaveSerieViewModel serieToSave)
        {
            Serie serie = new();
            serie.SerieId = serieToSave.SerieId;
            serie.SerieName = serieToSave.SerieName;
            serie.ImagePath = serieToSave.ImagePath;
            serie.VideoPath = serieToSave.VideoPath;
            serie.ProducerId = serieToSave.ProducerId;
            serie.PrimaryGenderId = serieToSave.PrimaryGenderId;
            serie.SecondaryGenderId = serieToSave.SecondaryGenderId == 0 ? null : serieToSave.SecondaryGenderId;

            await _serieRepository.UpdateAsync(serie);
        }

        public async Task Delete(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            await _serieRepository.DeleteAsync(serie);
        }

        public async Task UpdateSecondaryGender(int serieId, int? secondaryGenderId)
        {
            var serieEntity = await _serieRepository.GetByIdAsync(serieId);
            serieEntity.SecondaryGenderId = secondaryGenderId;

            await _serieRepository.UpdateAsync(serieEntity);
        }

        public async Task<List<SerieViewModel>> GetAllViewModel(string serieName = null/*, string producer = null*/)
        {
            var serieList = await _serieRepository.GetAllAsync();
            /*
            if (!string.IsNullOrEmpty(producer))
            {
                serieList = serieList.Where(serie => serie.Producer!.ProducerName == producer).ToList();
            }*/
            
            if (!string.IsNullOrEmpty(serieName))
            {
                serieList = serieList.Where(serie => serie.SerieName.ToLower().Contains(serieName.ToLower())).ToList();
            }

            return serieList.Select(serie => new SerieViewModel
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
        }

        public async Task<SerieViewModel> GetById(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);

            SerieViewModel serieVW = new();
            serieVW.SerieId = serie.SerieId;
            serieVW.SerieName = serie.SerieName;
            serieVW.ImagePath = serie.ImagePath;
            serieVW.VideoPath = serie.VideoPath;
            serieVW.Producer = new ProducerViewModel
            {
                ProducerId = serie.Producer!.ProducerId,
                ProducerName = serie.Producer.ProducerName
            };
            serieVW.PrimaryGender = new GenderViewModel
            {
                GenderId = serie.PrimaryGender!.GenderId,
                GenderName = serie.PrimaryGender.GenderName
            };
            serieVW.SecondaryGender = serie.SecondaryGender == null ? null : new GenderViewModel
            {
                GenderId = serie.SecondaryGender.GenderId,
                GenderName = serie.SecondaryGender.GenderName
            };

            return serieVW;
        }

        public async Task<SaveSerieViewModel> GetByIdSaveSerieViewModel(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);

            SaveSerieViewModel saveSerieVM = new();
            saveSerieVM.SerieId = serie.SerieId;
            saveSerieVM.SerieName = serie.SerieName;
            saveSerieVM.ImagePath = serie.ImagePath;
            saveSerieVM.VideoPath = serie.VideoPath;
            saveSerieVM.ProducerId = serie.ProducerId;
            saveSerieVM.PrimaryGenderId = serie.PrimaryGenderId;
            saveSerieVM.SecondaryGenderId = serie.SecondaryGenderId ?? 0;

            return saveSerieVM;
        }

    }
}
