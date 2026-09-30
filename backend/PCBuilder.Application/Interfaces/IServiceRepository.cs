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
        Task<Service> AddServiceToDB (Service service);
        Task<Service> FindServiceById(Guid id);
        Task SaveChangesToDbAsync();
        Task DeleteServiceFromDB(Service service);
        Task<IEnumerable<Service>> GetAllServicesFromDbAsync();
    }
}
