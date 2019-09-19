using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class CountryCurrency
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
