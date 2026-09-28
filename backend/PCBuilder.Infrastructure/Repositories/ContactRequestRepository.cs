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
    public class ContactRequestRepository : IContactRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactRequestRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<ContactRequest> CreateContactRequest(ContactRequest contactRequest)
        {
            _context.Add(contactRequest);
            await _context.SaveChangesAsync();

            return contactRequest;
        }        
    }
}
