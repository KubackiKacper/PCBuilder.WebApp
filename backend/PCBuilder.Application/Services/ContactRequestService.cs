using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
using PCBuilder.Domain.Entities;

namespace PCBuilder.Application.Services
{
    public class ContactRequestService
    {
        private readonly IContactRequestRepository _repository;

        public ContactRequestService(IContactRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContactRequestDTO> CreateContactRequest(
            ContactRequestDTO contactRequestDTO)
        {
            var newContactRequest = new ContactRequest
            {
                Id = Guid.NewGuid(),
                Email = contactRequestDTO.Email,
                Name = contactRequestDTO.Name,
                Message = contactRequestDTO.Message,
                CreatedAt = DateTime.UtcNow,
            };

            var createdContactRequest =
                await _repository.AddContactRequestAsync(newContactRequest);

            return new ContactRequestDTO
            {
                Name = createdContactRequest.Name,
                Email = createdContactRequest.Email,
                Message = createdContactRequest.Message
            };
        }
    }
}
