using Microsoft.AspNetCore.Mvc;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Interfaces;
using PCBuilder.Domain.Entities;

namespace PCBuilder.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRequestRepository _contactRequest;
        public ContactController(IContactRequestRepository contactRequest)
        {
            _contactRequest = contactRequest;
        }

        [HttpPost]
        public async Task<ActionResult<ContactRequest>> CreateContactRequest(ContactRequest contactRequest)
        {
            var createContactRequest = await _contactRequest.CreateContactRequest(contactRequest);
            
            return Ok(createContactRequest);
        }
    }
}
