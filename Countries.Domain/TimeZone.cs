using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class TimeZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<CountryTimeZone> Countries { get; set; }
    }
}
