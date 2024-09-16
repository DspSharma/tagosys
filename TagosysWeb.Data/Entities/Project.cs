using System;
using System.Collections.Generic;

namespace TagosysWeb.Data.Entities
{
    public partial class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string ProjectUrl { get; set; } = null!;
    }
}
