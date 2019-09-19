using Countries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Api.Models
{
    public class CountryApiViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Domains { get; set; }
        public string Alpha2Code { get; set; }
        public string Aplha3Code { get; set; }
        public List<string> CallingCodes { get; set; }
        public string Capital { get; set; }
        public List<string> AlternativeSpellings { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public double Population { get; set; }
        public List<double> Coordinates { get; set; }
        public string Demonym { get; set; }
        public double? Area { get; set; }
        public double? Gini { get; set; }
        public List<string> TimeZones { get; set; }
        public List<string> Borders { get; set; }
        public string NativeName { get; set; }  
        public string NumericCode { get; set; }
        public List<CurrencyApiViewModel> Currencies { get; set; }
        public List<LanguageApiViewModel> Languages { get; set; }
        public TranslationsApiViewModel Translations { get; set; }
        public string FlagUrl { get; set; }
        public List<RegionalBlockApiViewModel> Blocks { get; set; }
        public string Cioc { get; set; }
    }
}
