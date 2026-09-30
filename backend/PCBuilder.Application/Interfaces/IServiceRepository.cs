using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCBuilder.Application.DTOs;
using PCBuilder.Domain.Entities;

namespace PCBuilder.Application.Interfaces
{
    public interface IServiceRepository
    {
        Task<Service> AddAsync(Service service);
        Task<Service?> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
        Task DeleteAsync(Service service);
        Task<IEnumerable<Service>> GetAllAsync();
    }
}
