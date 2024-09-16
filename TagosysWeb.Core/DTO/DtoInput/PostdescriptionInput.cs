using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoInput
{
    public class PostdescriptionInput
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int PageId { get; set; }
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
        public string Image { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
