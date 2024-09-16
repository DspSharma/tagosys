using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoInput
{
    public class UserInput
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name filed is required")]
        [RegularExpression(@"^([a-zA-Z]+)(\s[a-zA-Z]+)*$", ErrorMessage = "Not a valid Name")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Email is required field.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Not a valid Email")]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int UserType { get; set; } = 1;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
