using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoOutput
{
    public class SystemsettingOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Mobile { get; set; } 
        public string Email { get; set; }
        public string? Logo { get; set; }
        public string LocalImage { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public string MapUrl { get; set; } 
        public bool IsActive { get; set; }
        public string RegisteredOfficeAddress { get; set; } 
        public string OperationalOfficeAddress { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
