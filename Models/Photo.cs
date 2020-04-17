using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Realty.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }
    }
}