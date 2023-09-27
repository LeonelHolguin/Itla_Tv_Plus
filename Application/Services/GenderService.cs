using Application.Repositories;
using Application.ViewModels;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenderService
    {
        private readonly GenderRepository _genderRepository;

        public GenderService(GenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task Add(GenderViewModel genderToSave)
        {
            Gender gender = new();
            gender.GenderName = genderToSave.GenderName;

            await _genderRepository.AddAsync(gender);
        }

        public async Task Update(GenderViewModel genderToSave)
        {
            Gender gender = new();
            gender.GenderId = genderToSave.GenderId;
            gender.GenderName = genderToSave.GenderName;


            await _genderRepository.UpdateAsync(gender);
        }

        public async Task Delete(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);
            await _genderRepository.DeleteAsync(gender);
        }

        public async Task<List<GenderViewModel>> GetAllViewModel()
        {
            var genderList = await _genderRepository.GetAllAsync();

            return genderList.Select(gender => new GenderViewModel
            {
                GenderId = gender.GenderId,
                GenderName = gender.GenderName

            }).ToList();
        }

        public async Task<GenderViewModel> GetById(int id)
        {
            var Gender = await _genderRepository.GetByIdAsync(id);

            GenderViewModel genderVM = new();
            genderVM.GenderId = Gender.GenderId;
            genderVM.GenderName = Gender.GenderName;

            return genderVM;
        }
    }
}
