namespace Sample.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Sample.Data.Models.Models;
    using Sample.Services.Common.Contracts;
    using Server.DataTransferModels.Countries;

    public interface ICountriesService : IService
    {
        IQueryable<Country> All();

        Task<List<CountryDataTransferModel>> GetAll();
    }
}