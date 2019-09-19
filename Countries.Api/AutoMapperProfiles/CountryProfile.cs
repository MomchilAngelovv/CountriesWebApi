using AutoMapper;
using Countries.Api.Models;
using Countries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Api.AutoMapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            this.CreateMap<Country, CountryApiViewModel>()
                .ForMember(c => c.Domains, s => s.MapFrom(x => x.Domains.Select(d => d.Name)))
                .ForMember(c => c.CallingCodes, s => s.MapFrom(x => x.CallingCodes.Select(d => d.Name)))
                .ForMember(c => c.AlternativeSpellings, s => s.MapFrom(x => x.AlternativeSpellings.Select(d => d.Name)))
                .ForMember(c => c.Coordinates, s => s.MapFrom(x => new double[] { x.Coordinates.Latitude, x.Coordinates.Longitude }))
                .ForMember(c => c.TimeZones, s => s.MapFrom(x => x.TimeZones.Select(d => d.TimeZone.Name)))
                .ForMember(c => c.Borders, s => s.MapFrom(x => x.Borders.Select(d => d.Border.Name)))
                .ForMember(c => c.Currencies, s => s.MapFrom(x => x.Currencies.Select(d => d.Currency)))
                .ForMember(c => c.Languages, s => s.MapFrom(x => x.Languages.Select(d => d.Language)))
                .ForMember(c => c.Blocks, s => s.MapFrom(x => x.Blocks.Select(d => d.RegionalBlock)))
                .ForMember(c => c.Translations, s => s.MapFrom(x => x.Translations));

            this.CreateMap<Translations, TranslationsApiViewModel>();
            this.CreateMap<Currency, CurrencyApiViewModel>();
            this.CreateMap<Language, LanguageApiViewModel>();
            this.CreateMap<RegionalBlock, RegionalBlockApiViewModel>();
        }
    }
}
