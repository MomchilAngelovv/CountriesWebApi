﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class CallingCode
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
