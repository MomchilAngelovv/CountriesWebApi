using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class CountryBorder
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int BorderId { get; set; }
        public virtual Border Border { get; set; }
    }
}
