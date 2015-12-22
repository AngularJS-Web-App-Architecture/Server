namespace Sample.Services.Data.Services
{
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Sample.Data.Contracts;
    using Sample.Data.Models.Models;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Server.DataTransferModels.Countries;
    using System;

    public class CountriesService : ICountriesService
    {
        private readonly IRepository<Country> countries;

        public CountriesService(IRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> All()
        {
            return this.countries.All();
        }

        public async Task<List<CountryDataTransferModel>> GetAll()
        {
            var allCountries = await this.countries.All().ProjectTo<CountryDataTransferModel>().ToListAsync();

            return allCountries;
        }
    }
}