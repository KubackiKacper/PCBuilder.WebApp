using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCBuilder.Application.DTOs;
using PCBuilder.Domain.Entities;

namespace PCBuilder.Application.Interfaces
{
    public interface IContactRequest
    {
        public Task<ContactRequest> CreateContactRequest(ContactRequestDTO contactRequest);
        
    }
}
