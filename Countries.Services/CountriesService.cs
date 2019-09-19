using AutoMapper;
using AutoMapper.QueryableExtensions;
using Countries.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Countries.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly CountriesDbContext context;
        private readonly IMapper mapper;

        public CountriesService(CountriesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var countries = this.context.Countries
                .ProjectTo<T>(mapper.ConfigurationProvider)
                .ToList();

            return countries;
        }

        public T GetCountry<T>(int id)
        {
            var country = this.context.Countries
                .Find(id);

            var mappedCountry = this.mapper.Map<T>(country);
            return mappedCountry;
        }
    }
}
