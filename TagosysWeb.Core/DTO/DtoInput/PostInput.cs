using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoInput
{
    public class PostInput
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public int PageId { get; set; }
        public bool IsActive { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Image { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
