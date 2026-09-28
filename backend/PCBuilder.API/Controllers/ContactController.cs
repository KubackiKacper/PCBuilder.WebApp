using Microsoft.AspNetCore.Mvc;
using PCBuilder.Application.DTOs;
using PCBuilder.Application.Services;

namespace PCBuilder.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContactController : Controller
    {
        private readonly ContactRequestService _contactRequestService;
        public ContactController(ContactRequestService contactRequestService)
        {
            _contactRequestService = contactRequestService;
        }

        [HttpPost]
        public async Task<ActionResult<ContactRequestDTO>> CreateContactRequest(ContactRequestDTO contactRequest)
        {
            var createContactRequest = 
                await _contactRequestService.CreateContactRequest(contactRequest);
            
            return Ok(createContactRequest);
        }
    }
}
