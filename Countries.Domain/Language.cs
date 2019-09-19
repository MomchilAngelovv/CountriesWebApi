using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class Language
    {
        public int Id { get; set; }
        public string Iso639_1 { get; set; }
        public string Iso639_2 { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public virtual List<CountryLanguage> Countries { get; set; }
    }
}
