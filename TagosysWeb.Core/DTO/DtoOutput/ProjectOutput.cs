using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoOutput
{
    public class ProjectOutput
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } 
        public string Image { get; set; } 
        public string LocalImage { get; set; }
        public string Description { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string ProjectUrl { get; set; } 
    }
}
