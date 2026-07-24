using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
using PCBuilder.Infrastructure.Data;
namespace PCBuilder.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ApplicationDbContext _context;
        public Task<ServiceDTO> CreateAsync(ServiceDTO serviceDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ServiceDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDTO?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, ServiceDTO serviceDTO)
        {
            throw new NotImplementedException();
        }
    }
}
