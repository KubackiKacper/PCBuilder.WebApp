using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PCBuilder.Application.DTOs
{
    public class ServiceDTO
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01f,1000f, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal PriceFrom { get; set; }
    }
}
