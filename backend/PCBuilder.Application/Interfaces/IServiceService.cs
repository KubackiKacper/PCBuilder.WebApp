using System;
using System.Collections.Generic;
using System.Text;
using PCBuilder.Application.DTOs;
namespace PCBuilder.Application.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDTO>> GetAllAsync();
        Task<ServiceDTO> GetByIdAsync(Guid id);
        Task<ServiceDTO> CreateAsync(ServiceDTO serviceDTO);
        Task<bool> UpdateAsync (Guid id, ServiceDTO serviceDTO);
        Task<bool> DeleteAsync (Guid id);
    }
}
