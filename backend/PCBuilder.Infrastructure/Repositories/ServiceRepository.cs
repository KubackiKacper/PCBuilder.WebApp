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
        public async Task<Service> AddAsync(Service serviceToAdd)
        {
            _context.Add(serviceToAdd);
            await _context.SaveChangesAsync();
            return serviceToAdd;
        }
        public async Task<Service?> GetByIdAsync(Guid id)
        {
            var serviceById = await _context.Services.FindAsync(id);            
            return serviceById;
        }
        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }
        public async Task DeleteAsync(Service service)
        {
            _context.Remove(service);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
