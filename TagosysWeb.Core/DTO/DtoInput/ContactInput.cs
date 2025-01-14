﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.DTO.DtoInput
{
    public class ContactInput
    {
        public int Id { get; set; }
       
        public string Name { get; set; } 
      
        public string Email { get; set; }
        public string Subject { get; set; } 
        public string Message { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
