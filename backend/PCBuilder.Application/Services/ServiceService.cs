using PCBuilder.Domain.Entities;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
namespace PCBuilder.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        public ServiceService(IServiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<ServiceDTO> CreateAsync(ServiceDTO serviceDTO)
        {
            var serviceToAdd = new Service
            {
                Id = Guid.NewGuid(),
                Name = serviceDTO.Name,
                Description = serviceDTO.Description,
                PriceFrom = serviceDTO.PriceFrom,
            };

            var createdService = await _repository.AddAsync(serviceToAdd);

            return new ServiceDTO
            {
                Id = createdService.Id,
                Name = createdService.Name,
                Description = createdService.Description,
                PriceFrom = createdService.PriceFrom,
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var serviceToDelete = await _repository.GetByIdAsync(id);
            if (serviceToDelete == null)
                return;

            await _repository.DeleteAsync(serviceToDelete);
        }

        public async Task<IEnumerable<ServiceDTO>> GetAllAsync()
        {
            var services = await _repository.GetAllAsync();

            return services.Select(s => new ServiceDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                PriceFrom = s.PriceFrom
            });
        }

        public async Task<ServiceDTO?> GetByIdAsync(Guid id)
        {
            var serviceById = await _repository.GetByIdAsync(id);
            if (serviceById == null)
                return null;

            return new ServiceDTO
            {
                Id = serviceById.Id,
                Name = serviceById.Name,
                Description = serviceById.Description,
                PriceFrom = serviceById.PriceFrom,
            };
        }

        public async Task UpdateAsync(Guid id, ServiceDTO serviceDTO)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service == null)
                return;

            service.Name = serviceDTO.Name;
            service.Description = serviceDTO.Description;
            service.PriceFrom = serviceDTO.PriceFrom;

            await _repository.SaveChangesAsync();
        }
    }
}
