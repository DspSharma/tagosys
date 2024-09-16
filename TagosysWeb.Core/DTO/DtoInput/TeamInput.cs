using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoInput
{
    public class TeamInput
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name filed is required")]
        [RegularExpression(@"^([a-zA-Z]+)(\s[a-zA-Z]+)*$", ErrorMessage = "Not a valid Name")]
        public string Name { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
        public string Image { get; set; } = null!;
        [Required(ErrorMessage = "ProfessionField filed is required")]
        public string ProfessionField { get; set; } = null!;
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "City filed is required")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "State filed is required")]
        public string State { get; set; } = null!;
        [Required(ErrorMessage = "Address filed is required")]
        public string Address { get; set; } = null!;
        [Required(ErrorMessage = "Email is required field.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Not a valid Email")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Mobile Number is required field.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Designation { get; set; }
    }
}
