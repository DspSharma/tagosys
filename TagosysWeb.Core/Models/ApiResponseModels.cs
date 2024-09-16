using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.Models
{
    public class ApiResponseModels<T>
    {
        public bool succeed { get; set; }
        public string message { get; set; }

        public T data { get; set; }
        public string error { get; set; }
        public int TotalCount { get; set; }
    }
}
