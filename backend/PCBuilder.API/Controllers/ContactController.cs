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
        private readonly IContactRequest _contactRequest;
        public ContactController(IContactRequest contactRequest)
        {
            _contactRequest = contactRequest;
        }
        [HttpPost]
        public async Task<ActionResult<ContactRequest>> CreateContactRequest(ContactRequestDTO contactRequestDTO)
        {
            var createContactRequest = await _contactRequest.CreateContactRequest(contactRequestDTO);
            if (createContactRequest == null)
            {
                return NotFound();
            }
            return Ok(createContactRequest);
        }
    }
}
