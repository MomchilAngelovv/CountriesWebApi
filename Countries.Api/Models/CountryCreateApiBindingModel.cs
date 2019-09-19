using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Api.Models
{
    public class CountryCreateApiBindingModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("topLevelDomain")]
        public List<string> Domains { get; set; }
        [JsonProperty("alpha2Code")]
        public string Alpha2Code { get; set; }
        [JsonProperty("alpha3Code")]
        public string Aplha3Code { get; set; }
        [JsonProperty("callingCodes")]
        public List<string> CallingCodes { get; set; }
        [JsonProperty("capital")]
        public string Capital { get; set; }
        [JsonProperty("altSpellings")]
        public List<string> AlternativeSpellings { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("subregion")]
        public string SubRegion { get; set; }
        [JsonProperty("population")]
        public double Population { get; set; }
        [JsonProperty("latlng")]
        public List<double> Coordinates { get; set; }
        [JsonProperty("demonym")]
        public string Demonym { get; set; }
        [JsonProperty("area")]
        public double? Area { get; set; }
        [JsonProperty("gini")]
        public double? Gini { get; set; }
        [JsonProperty("timezones")]
        public List<string> TimeZones { get; set; }
        [JsonProperty("borders")]
        public List<string> Borders { get; set; }
        [JsonProperty("nativeName")]
        public string NativeName { get; set; }
        [JsonProperty("numericCode")]
        public string NumericCode { get; set; }
        [JsonProperty("currencies")]
        public List<CurrencyCreateApiBindingModel> Currencies { get; set; }
        [JsonProperty("languages")]
        public List<LanguageCreateApiBindingModel> Languages { get; set; }
        [JsonProperty("translations")]
        public TranslationsCreateApiBindingModel Translations { get; set; }
        [JsonProperty("flag")]
        public string FlagUrl { get; set; }
        [JsonProperty("regionalBlocs")]
        public List<RegionalBlockCreateApiBindingModel> Blocks { get; set; }
        [JsonProperty("cioc")]
        public string Cioc { get; set; }
    }
}
