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
    public class ProducerService
    {
        private readonly ProducerRepository _producerRepository;

        public ProducerService(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public async Task Add(ProducerViewModel producerToSave)
        {
            Producer producer = new();
            producer.ProducerName = producerToSave.ProducerName;

            await _producerRepository.AddAsync(producer);
        }

        public async Task Update(ProducerViewModel producerToSave)
        {
            Producer producer = new();
            producer.ProducerId = producerToSave.ProducerId;
            producer.ProducerName = producerToSave.ProducerName;
            

            await _producerRepository.UpdateAsync(producer);
        }

        public async Task Delete(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            await _producerRepository.DeleteAsync(producer);
        }

        public async Task<List<ProducerViewModel>> GetAllViewModel()
        {
            var producerList = await _producerRepository.GetAllAsync();

            return producerList.Select(producer => new ProducerViewModel
            {
                ProducerId = producer.ProducerId,
                ProducerName = producer.ProducerName

            }).ToList();
        }

        public async Task<ProducerViewModel> GetById(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);

            ProducerViewModel producerVM = new();
            producerVM.ProducerId = producer.ProducerId;
            producerVM.ProducerName = producer.ProducerName;

            return producerVM;
        }
    }
}
