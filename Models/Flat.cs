using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Realty.Models
{
    public class Flat
    {
        public int FlatID { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string DistrictType { get; set; }
        public string House { get; set; }
        public string FlatNumber { get; set; }
        public string Description { get; set; }
        public int PriceDollar { get; set; }
        public int PriceGrn { get; set; }
        public int CurrencyID { get; set; }
        public string UserName { get; set; }
        public int RoomCount { get; set; }
        public double AreaSize { get; set; }
        public int Floor { get; set; }
        public int MaxFloor { get; set; }
        public double KitchenSize { get; set; }
        public int HeaterTypeID { get; set; }
        public int? BuildYear { get; set; }
        public bool IsExhange { get; set; }
        public bool IsBarter { get; set; }
        public DateTime Date { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual HeaterType HeaterType { get; set; }
    }
}