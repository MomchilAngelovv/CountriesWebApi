using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Domain
{
    public class Country
    {
        public Country()
        {
            this.Domains = new List<InternetDomain>();
            this.CallingCodes = new List<CallingCode>();
            this.AlternativeSpellings = new List<AlternativeSpelling>();
            this.TimeZones = new List<CountryTimeZone>();
            this.Borders = new List<CountryBorder>();
            this.Currencies = new List<CountryCurrency>();
            this.Languages = new List<CountryLanguage>();
            this.Blocks = new List<CountryRegionalBlock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<InternetDomain> Domains { get; set; }
        public string Alpha2Code { get; set; }
        public string Aplha3Code { get; set; }
        public virtual List<CallingCode> CallingCodes { get; set; }
        public string Capital { get; set; }
        public virtual List<AlternativeSpelling> AlternativeSpellings { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public double Population { get; set; }

        public int CoordinatesId { get; set; }
        public virtual Coordinates Coordinates { get; set; }

        public string Demonym { get; set; }
        public double? Area { get; set; }
        public double? Gini { get; set; }
        public virtual List<CountryTimeZone> TimeZones { get; set; }
        public virtual List<CountryBorder> Borders { get; set; }
        public string NativeName { get; set; }
        public string NumericCode { get; set; }
        public virtual List<CountryCurrency> Currencies { get; set; }
        public virtual List<CountryLanguage> Languages { get; set; }

        public int TranslationsId { get; set; }
        public virtual Translations Translations { get; set; }

        public string FlagUrl { get; set; }
        public virtual List<CountryRegionalBlock> Blocks { get; set; }
        public string Cioc { get; set; }
    }
}
