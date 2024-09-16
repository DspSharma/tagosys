using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoOutput
{
    public class ClientOutput
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Country { get; set; } 
        public string Tittle { get; set; } 
        public string Description { get; set; }
        public string Image { get; set; }
        public string LocalImage { get; set; }
        public string? Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
