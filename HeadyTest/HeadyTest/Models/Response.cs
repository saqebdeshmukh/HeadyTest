using System;
using System.Collections.Generic;
using System.Text;

namespace HeadyTest.Models
{
    public class Response<T>
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public string status_message { get; set; }
        public bool success { get; set; }
        public int status_code { get; set; }
        public T results { get; set; }
    }
}
