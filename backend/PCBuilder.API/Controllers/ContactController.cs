using Microsoft.AspNetCore.Mvc;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
using PCBuilder.Domain.Entities;
using PCBuilder.Application.Services;

namespace PCBuilder.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContactController : Controller
    {
        private readonly ContactRequestService _contactRequest;
        public ContactController(ContactRequestService contactRequest)
        {
            _contactRequest = contactRequest;
        }

        [HttpPost]
        public async Task<ActionResult<ContactRequestDTO>> CreateContactRequest(ContactRequestDTO contactRequest)
        {
            var createContactRequest = 
                await _contactRequest.CreateContactRequest(contactRequest);
            
            return Ok(createContactRequest);
        }
    }
}
