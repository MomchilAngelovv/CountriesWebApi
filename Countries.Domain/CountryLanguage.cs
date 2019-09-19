using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class CountryLanguage
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
