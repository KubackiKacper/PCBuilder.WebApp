using System;
using System.Collections.Generic;
using System.Text;

namespace PCBuilder.Application.DTOs
{
    public class ServiceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PriceFrom { get; set; }
    }
}
