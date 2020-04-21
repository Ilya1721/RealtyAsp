using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Realty.Models
{
    public class WishFlatUserPivot
    {
        public int WishFlatUserPivotID { get; set; }
        public int FlatID { get; set; }
        public string UserName { get; set; }
        
        public virtual Flat Flat { get; set; }
    }
}