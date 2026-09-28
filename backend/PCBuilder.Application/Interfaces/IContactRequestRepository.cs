using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCBuilder.Application.DTOs;
using PCBuilder.Domain.Entities;

namespace PCBuilder.Application.Interfaces
{
    public interface IContactRequestRepository
    {
        public Task<ContactRequest> CreateContactRequest(ContactRequest contactRequest);        
    }
}
