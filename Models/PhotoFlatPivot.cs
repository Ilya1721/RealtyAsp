using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Realty.Models
{
    public class PhotoFlatPivot
    {
        public int PhotoFlatPivotID { get; set; }
        public int FlatID { get; set; }
        public int PhotoID { get; set; }

        public virtual Flat Flat { get; set; }
        public virtual Photo Photo { get; set; }
    }
}