using System;
using System.Collections.Generic;

namespace TagosysWeb.Data.Entities
{
    public partial class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string ProfessionField { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Designation { get; set; }
    }
}
