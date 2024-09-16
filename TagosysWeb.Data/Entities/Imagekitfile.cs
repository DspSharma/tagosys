using System;
using System.Collections.Generic;

namespace TagosysWeb.Data.Entities
{
    public partial class Imagekitfile
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string OriginalFileId { get; set; } = null!;
        public string ThumbnailFileId { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
