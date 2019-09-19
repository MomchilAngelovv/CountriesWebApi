using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class RegionalBlock
    {
        public int Id { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public virtual List<CountryRegionalBlock> Countries { get; set; }
    }
}
