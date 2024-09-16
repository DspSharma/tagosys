using System;
using System.Collections.Generic;

namespace TagosysWeb.Data.Entities
{
    public partial class Systemsetting
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Mobile { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Logo { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public string MapUrl { get; set; } = null!;
        public bool IsActive { get; set; }
        public string RegisteredOfficeAddress { get; set; } = null!;
        public string OperationalOfficeAddress { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
