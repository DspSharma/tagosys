using System;
using System.Collections.Generic;

namespace TagosysWeb.Data.Entities
{
    public partial class Postdescription
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int PageId { get; set; }
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Page Page { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
    }
}
