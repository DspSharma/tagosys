using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoOutput
{
    public class ImagekitfileOutput
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string LocalImagePath { get; set; }
        public string OriginalFileId { get; set; } = null!;
        public string ThumbnailFileId { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
