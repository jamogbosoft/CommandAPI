using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.DTOs
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        //You can comment platform as well to remove it from the returned data
        public string Platform { get; set; }
        public string CommandLine { get; set; }
    }
}
