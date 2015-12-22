namespace Sample.Server.API.Controllers
{
    using Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    [RoutePrefix("api/Countries")]
    public class CountriesController : ApiController
    {
        private readonly ICountriesService countries;

        public CountriesController(ICountriesService countries)
        {
            this.countries = countries;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var countries = await this.countries.GetAll();

            return this.Ok(countries);
        }
    }
}