using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class CountryRegionalBlock
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int RegionalBlockId { get; set; }
        public virtual RegionalBlock RegionalBlock { get; set; }
    }
}
