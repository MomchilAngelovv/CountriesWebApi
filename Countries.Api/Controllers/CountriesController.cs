using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Countries.Api.Models;
using Countries.Data;
using Countries.Domain;
using Countries.Services;

namespace Countries.Api.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly CountriesDbContext context;
        private readonly ICountriesService countriesService;

        public CountriesController(
            CountriesDbContext context,
            ICountriesService countriesService) 
        {
            this.context = context;
            this.countriesService = countriesService;
        }

        public ActionResult<IEnumerable<CountryApiViewModel>> All()
        {
            var countries = this.countriesService
                .GetAll<CountryApiViewModel>()
                .ToList();

            return countries;
        }

        [HttpGet("{id}")]
        public ActionResult<CountryApiViewModel> GetCountry(int id)
        {
            var country = this.countriesService.GetCountry<CountryApiViewModel>(id);

            if (country == null)
            {
                return this.NotFound();
            }

            return country;
        }

        [HttpGet("populate")]
        public async Task<ActionResult> PopulateDatabase()
        {
            if (this.context.Countries.Any() == false)
            {
                var httpClient = new HttpClient();

                var countriesAsString = await httpClient.GetStringAsync("https://restcountries.eu/rest/v2/all");
                var countriesAsJson = JsonConvert.DeserializeObject<List<CountryCreateApiBindingModel>>(countriesAsString);

                foreach (var countryCreateModel in countriesAsJson)
                {
                    var country = new Country
                    {
                        Name = countryCreateModel.Name,
                        Alpha2Code = countryCreateModel.Alpha2Code,
                        Aplha3Code = countryCreateModel.Aplha3Code,
                        Capital = countryCreateModel.Capital,
                        Region = countryCreateModel.Region,
                        SubRegion = countryCreateModel.SubRegion,
                        Population = countryCreateModel.Population,
                        Demonym = countryCreateModel.Demonym,
                        Area = countryCreateModel.Area,
                        Gini = countryCreateModel.Gini,
                        NativeName = countryCreateModel.NativeName,
                        NumericCode = countryCreateModel.NumericCode,
                        FlagUrl = countryCreateModel.FlagUrl,
                        Cioc = countryCreateModel.Cioc,
                    };

                    foreach (var internetDomainAsString in countryCreateModel.Domains)
                    {
                        var internetDomain = new InternetDomain
                        {
                            Name = internetDomainAsString,
                            Country = country
                        };

                        this.context.InternetDomains.Add(internetDomain);
                    }

                    foreach (var callingCodeAsString in countryCreateModel.CallingCodes)
                    {
                        var callingCode = new CallingCode
                        {
                            Name = callingCodeAsString,
                            CountryId = country.Id
                        };

                        this.context.CallingCodes.Add(callingCode);
                    }

                    foreach (var altSpellingAsString in countryCreateModel.AlternativeSpellings)
                    {
                        var alternativeSpelling = new AlternativeSpelling
                        {
                            Name = altSpellingAsString,
                            Country = country
                        };

                        this.context.AlternativeSpellings.Add(alternativeSpelling);
                    }

                    if (countryCreateModel.Coordinates.Count == 2)
                    {
                        var coordinates = new Coordinates
                        {
                            Latitude = countryCreateModel.Coordinates[0],
                            Longitude = countryCreateModel.Coordinates[1]
                        };

                        country.Coordinates = coordinates;
                    }
                    else
                    {
                        var coordinates = new Coordinates
                        {
                            Latitude = 50,
                            Longitude = 50
                        };

                        country.Coordinates = coordinates;
                    }

                    foreach (var timeZomeAsString in countryCreateModel.TimeZones)
                    {
                        var timeZone = new Countries.Domain.TimeZone
                        {
                            Name = timeZomeAsString
                        };

                        if (this.context.TimeZones.Any(tz => tz.Name == timeZone.Name) == false)
                        {
                            this.context.TimeZones.Add(timeZone);

                            var countryTimeZone = new CountryTimeZone
                            {
                                Country = country,
                                TimeZone = timeZone
                            };

                            this.context.CountryTimeZone.Add(countryTimeZone);
                        }
                    }

                    foreach (var borderAsString in countryCreateModel.Borders)
                    {
                        var border = new Border
                        {
                            Name = borderAsString
                        };

                        if (this.context.Borders.Any(tz => tz.Name == border.Name) == false)
                        {
                            this.context.Borders.Add(border);

                            var countryBorder = new CountryBorder
                            {
                                Country = country,
                                Border = border
                            };

                            this.context.CountryBorder.Add(countryBorder);
                        }
                    }

                    foreach (var currencyCreateModel in countryCreateModel.Currencies)
                    {
                        var currency = new Currency
                        {
                            Code = currencyCreateModel.Code,
                            Name = currencyCreateModel.Name,
                            Symbol = currencyCreateModel.Symbol
                        };

                        if (this.context.Currencies.Any(c => c.Code == currency.Code) == false)
                        {
                            this.context.Currencies.Add(currency);

                            var countryCurrency = new CountryCurrency
                            {
                                Country = country,
                                Currency = currency
                            };

                            this.context.CountryCurrency.Add(countryCurrency);
                        }
                    }

                    foreach (var languageCreateModel in countryCreateModel.Languages)
                    {
                        var language = new Language
                        {
                            Iso639_1 = languageCreateModel.Iso639_1,
                            Iso639_2 = languageCreateModel.Iso639_2,
                            Name = languageCreateModel.Name,
                            NativeName = languageCreateModel.NativeName,
                        };

                        if (this.context.Languages.Any(l => l.Name == language.Name) == false)
                        {
                            this.context.Languages.Add(language);

                            var countryLanguage = new CountryLanguage
                            {
                                Country = country,
                                Language = language
                            };

                            this.context.CountryLanguage.Add(countryLanguage);
                        }
                    }

                    var translations = new Translations
                    {
                        De = countryCreateModel.Translations.De,
                        Es = countryCreateModel.Translations.Es,
                        Fr = countryCreateModel.Translations.Fr,
                        Ja = countryCreateModel.Translations.Ja,
                        It = countryCreateModel.Translations.It,
                        Br = countryCreateModel.Translations.Br,
                        Pt = countryCreateModel.Translations.Pt,
                        Nl = countryCreateModel.Translations.Nl,
                        Hr = countryCreateModel.Translations.Hr,
                        Fa = countryCreateModel.Translations.Fa,
                    };

                    country.Translations = translations;

                    foreach (var blockCreateModel in countryCreateModel.Blocks)
                    {
                        var regionalBlock = new RegionalBlock
                        {
                            Acronym = blockCreateModel.Acronym,
                            Name = blockCreateModel.Name
                        };

                        if (this.context.RegionalBlocks.Any(rb => rb.Name == regionalBlock.Name) == false)
                        {
                            this.context.RegionalBlocks.Add(regionalBlock);

                            var countryRegionalBlock = new CountryRegionalBlock
                            {
                                Country = country,
                                RegionalBlock = regionalBlock
                            };

                            this.context.CountryRegionalBlock.Add(countryRegionalBlock);
                        }
                    }

                    this.context.Countries.Add(country);
                    this.context.SaveChanges();
                }

                return this.Ok($"Successfully populated table with {this.context.Countries.Count()} countries.");
            }

            return this.Ok("Database is already populated.");
        }
    }
}
