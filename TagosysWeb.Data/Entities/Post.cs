using System;
using System.Collections.Generic;

namespace TagosysWeb.Data.Entities
{
    public partial class Post
    {
        public Post()
        {
            Postdescriptions = new HashSet<Postdescription>();
        }

        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public int PageId { get; set; }
        public bool IsActive { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Page Page { get; set; } = null!;
        public virtual ICollection<Postdescription> Postdescriptions { get; set; }
    }
}
