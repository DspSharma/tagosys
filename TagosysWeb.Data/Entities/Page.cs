using System;
using System.Collections.Generic;

namespace TagosysWeb.Data.Entities
{
    public partial class Page
    {
        public Page()
        {
            Postdescriptions = new HashSet<Postdescription>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Postdescription> Postdescriptions { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
