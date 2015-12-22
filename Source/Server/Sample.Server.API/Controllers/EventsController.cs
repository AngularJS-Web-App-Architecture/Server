namespace Sample.Server.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Services.Data.Contracts;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using DataTransferModels.Events;
    using Infrastructure.Validation;
    using Data.Common.Constants;
    [RoutePrefix("api/Events")]
    public class EventsController : ApiController
    {
        private IEventsService events;

        public EventsController(IEventsService events)
        {
            this.events = events;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await this.events.GetAll();

            return this.Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await this.events.GetById(id);

            return this.Ok(result);
        }

        [HttpGet]
        [Route("Page/{page}")]
        public async Task<IHttpActionResult> GetByPage(int page)
        {
            var result = await this.events.GetByPage(page);

            return this.Ok(result);
        }

        [HttpPost]
        [Authorize]
        [ValidateRequestModelAttribute]
        public async Task<IHttpActionResult> Post(EventDataTransferModel model)
        {
            var result = await this.events.Add(model);

            if(result == ValidationConstants.EventInsertionFailed)
            {
                return this.BadRequest("Failure");
            }

            return this.Ok(result);
        }

        [HttpDelete]
        [Authorize]
        [ValidateRequestModelAttribute]
        public async Task<IHttpActionResult> Delete(EventDataTransferModel model)
        {
            var isDeleted = await this.events.Remove(model);

            if(!isDeleted)
            {
                return this.BadRequest("The selected event could not be deleted.");
            }

            return this.Ok(isDeleted);
        }
    }
}