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

            var createdService = await _repository.AddServiceToDB(serviceToAdd);

            return new ServiceDTO
            {
                Id = serviceToAdd.Id,
                Name = serviceToAdd.Name,
                Description = serviceToAdd.Description,
                PriceFrom = serviceToAdd.PriceFrom,
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var serviceToDelete = await _repository.FindServiceById(id);

            await _repository.DeleteServiceFromDB(serviceToDelete);
        }

        public async Task<IEnumerable<ServiceDTO>> GetAllAsync()
        {
            var services = await _repository.GetAllServicesFromDbAsync();

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
            var serviceById = await _repository.FindServiceById(id);

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
            var service = await _repository.FindServiceById(id);

            service.Name = serviceDTO.Name;
            service.Description = serviceDTO.Description;
            service.PriceFrom = serviceDTO.PriceFrom;

            await _repository.SaveChangesToDbAsync();
        }
    }
}
