using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoInput
{
    public class ProjectInput
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name filed is required")]
        public string ProjectName { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
        public string Image { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string ProjectUrl { get; set; } = null!;
    }
}
