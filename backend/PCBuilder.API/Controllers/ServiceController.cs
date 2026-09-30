using Microsoft.AspNetCore.Mvc;
using PCBuilder.Application.Interfaces;
using PCBuilder.Application.DTOs;
namespace PCBuilder.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAll()
        {
            var services = await _serviceService.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetById(Guid id)
        {
            var serviceById = await _serviceService.GetByIdAsync(id);
            if (serviceById == null)
            {
                return NotFound();
            }
            return Ok(serviceById);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> Create(ServiceDTO dto)
        {
            var serviceToCreate = await _serviceService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = serviceToCreate.Id },
                serviceToCreate);
        }

        [HttpPut("{id}")]
        public async Task Update(Guid id, ServiceDTO dto)
        {
            await _serviceService.UpdateAsync(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _serviceService.DeleteAsync(id);
        }
    }
}
