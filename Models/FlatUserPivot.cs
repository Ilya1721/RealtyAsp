﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Realty.Models
{
    public class FlatUserPivot
    {
        public int FlatUserPivotID { get; set; }
        public int FlatID { get; set; }
        public int ApplicationUserID { get; set; }

        public virtual Flat Flat { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}