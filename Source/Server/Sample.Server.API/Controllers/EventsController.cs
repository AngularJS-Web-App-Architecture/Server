namespace Sample.Server.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Services.Data.Contracts;

    [RoutePrefix("api/Events")]
    public class EventsController : ApiController
    {
        public EventsController(IEventsService events)
        {

        }
    }
}
