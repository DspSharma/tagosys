using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoOutput
{
    public class TeamOutput
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Image { get; set; }
        public string LocalImage { get; set; }
        public string ProfessionField { get; set; } 
        public DateTime Dob { get; set; }
        public string City { get; set; } 
        public string State { get; set; } 
        public string Address { get; set; } 
        public string Email { get; set; } 
        public string Mobile { get; set; } 
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Designation { get; set; }
    }
}
