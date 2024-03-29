﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class CountryTimeZone
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int TimeZoneId { get; set; }
        public virtual TimeZone TimeZone { get; set; }
    }
}
