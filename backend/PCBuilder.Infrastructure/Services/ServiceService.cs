using Microsoft.EntityFrameworkCore;
using PCBuilder.Domain.Entities;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
using PCBuilder.Infrastructure.Data;
namespace PCBuilder.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ApplicationDbContext _context;
        public ServiceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceDTO> CreateAsync(ServiceDTO serviceDTO)
        {
            var serviceToAdd = new Service
            {
                Name = serviceDTO.Name,
                Description = serviceDTO.Description,
                PriceFrom = serviceDTO.PriceFrom,
            };

            _context.Add(serviceToAdd);
            await _context.SaveChangesAsync();
            serviceDTO.Id = serviceToAdd.Id;
            return new ServiceDTO
            {
                Id = serviceToAdd.Id,
                Name = serviceToAdd.Name,
                Description = serviceToAdd.Description,
                PriceFrom = serviceToAdd.PriceFrom,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var serviceToDelete = await _context.Services.FindAsync(id);
            if (serviceToDelete == null)
            {
                return false;
            }

            _context.Remove(serviceToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceDTO>> GetAllAsync()
        {
            return await _context.Services.Select(s => new ServiceDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                PriceFrom = s.PriceFrom,
            }).ToListAsync();
        }

        public async Task<ServiceDTO?> GetByIdAsync(Guid id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return null;
            }
            return new ServiceDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                PriceFrom = service.PriceFrom,
            };
        }

        public async Task<bool> UpdateAsync(Guid id, ServiceDTO serviceDTO)
        {
            var serviceToUpdate = await _context.Services.FindAsync(id);

            if (serviceToUpdate == null)
            {
                return false;
            }

            serviceToUpdate.Name = serviceDTO.Name;
            serviceToUpdate.Description = serviceDTO.Description;
            serviceToUpdate.PriceFrom = serviceDTO.PriceFrom;

            _context.SaveChangesAsync();
            return true;
        }
    }
}
