using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
using PCBuilder.Domain.Entities;
using PCBuilder.Infrastructure.Data;

namespace PCBuilder.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Service> AddServiceToDB(Service serviceToAdd)
        {
            _context.Add(serviceToAdd);
            await _context.SaveChangesAsync();
            return serviceToAdd;
        }
        public async Task<Service> FindServiceById(Guid id)
        {
            var serviceById = await _context.Services.FindAsync(id);
            if (serviceById == null)
            {
                throw new NullReferenceException();
            }

            return serviceById;
        }
        public async Task<IEnumerable<Service>> GetAllServicesFromDbAsync()
        {
            return await _context.Services.ToListAsync();
        }
        public async Task DeleteServiceFromDB(Service service)
        {
            _context.Remove(service);
            await SaveChangesToDbAsync();
        }

        public async Task SaveChangesToDbAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
