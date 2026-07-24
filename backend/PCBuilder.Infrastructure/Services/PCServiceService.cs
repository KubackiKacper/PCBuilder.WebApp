using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
using PCBuilder.Infrastructure.Data;
namespace PCBuilder.Application.Services
{
    public class PCServiceService : IServiceService
    {
        private readonly ApplicationDbContext _context;
        public PCServiceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceDTO> CreateAsync(ServiceDTO serviceDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var serviceToDelete = await _context.Services.FindAsync(id);
            if (serviceToDelete == null)
            {
                return false;
            }

            _context.Services.Remove(serviceToDelete);
            _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceDTO>> GetAllAsync()
        {

            return await _context.Services
            .Select(s => new ServiceDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                PriceFrom = s.PriceFrom
            })
            .ToListAsync();
        }

        public async Task<ServiceDTO> GetByIdAsync(Guid id)
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
                PriceFrom = service.PriceFrom
            };
        }

        public Task<bool> UpdateAsync(Guid id, ServiceDTO serviceDTO)
        {
            throw new NotImplementedException();
        }
    }
}
