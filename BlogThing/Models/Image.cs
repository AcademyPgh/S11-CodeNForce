using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogThing.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ComplaintId { get; set; }
        public string FileName { get; set; }
    }
}
