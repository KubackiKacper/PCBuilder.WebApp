using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
using PCBuilder.Domain.Entities;
using PCBuilder.Infrastructure.Data;

namespace PCBuilder.Application.Services
{
    public class ContactRequestRepository : IContactRequest
    {
        private readonly ApplicationDbContext _context;
        public ContactRequestRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<ContactRequest> CreateContactRequest(ContactRequestDTO contactRequest)
        {
            var newContactRequest = new ContactRequest
            {
                Id = Guid.NewGuid(),
                Email = contactRequest.Email,
                Name = contactRequest.Name,
                Message = contactRequest.Message,
                CreatedAt = DateTime.Now,
            };
            _context.Add(newContactRequest);
            await _context.SaveChangesAsync();

            return newContactRequest;
        }        
    }
}
