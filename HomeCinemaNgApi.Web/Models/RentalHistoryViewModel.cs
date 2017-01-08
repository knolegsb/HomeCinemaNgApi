﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinemaNgApi.Web.Models
{
    public class RentalHistoryViewModel
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string Customer { get; set; }
        public string Status { get; set; }
        public DateTime RentalDate { get; set; }
        public Nullable<DateTime> ReturnedDate { get; set; }
    }
}