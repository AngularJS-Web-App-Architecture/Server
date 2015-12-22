namespace Sample.Services.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Sample.Data.Models.Models;
    using Server.DataTransferModels.Events;
    using Sample.Data.Contracts;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Common.Constants;
    using Sample.Server.Common;
    using Sample.Data.Common.Constants;
    public class EventsService : IEventsService
    {
        private readonly IRepository<Event> events;
        private readonly IRepository<Country> countries;

        public EventsService(IRepository<Event> events, IRepository<Country> countries)
        {
            this.events = events;
            this.countries = countries;
        }

        public IQueryable<Event> All()
        {
            return this.events.All();
        }

        public async Task<int> Add(EventDataTransferModel model)
        {
            Event eventToAdd = null;

            var eventCountry = await this.countries.All().SingleOrDefaultAsync(country => country.Name == model.Country);

            if(eventCountry != null)
            {
                eventToAdd = new Event()
                {
                    Country = eventCountry,
                    Host = model.Host,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };

                this.events.Add(eventToAdd);
                await this.events.SaveChangesAsync();
            }

            return eventToAdd != null ? eventToAdd.Id : ValidationConstants.EventInsertionFailed;
        }

        public async Task<List<EventDataTransferModel>> GetAll()
        {
            var allEvents = await this.events.All().ProjectTo<EventDataTransferModel>().ToListAsync();

            return allEvents;
        }

        public async Task<EventDataTransferModel> GetById(int id)
        {
            var eventById = await this.All().SingleOrDefaultAsync(x => x.Id == id);
            var eventModel = Mapper.Map<EventDataTransferModel>(eventById);

            return eventModel;
        }

        public async Task<List<EventDataTransferModel>> GetByPage(int page)
        {
            var eventsOnPage = await this.All()
                .Skip((page - 1) * ServicesConstants.ItemsPerPage)
                .Take(ServicesConstants.ItemsPerPage)
                .ProjectTo<EventDataTransferModel>()
                .ToListAsync();

            var originalEvent = new Event();

            var eventDataTransferModel = new EventDataTransferModel()
            {
                Country = originalEvent.Country.Name,
                Description = originalEvent.Description,
                Host = originalEvent.Host,
                EndDate = originalEvent.EndDate,
                StartDate = originalEvent.StartDate
            };

            return eventsOnPage;
        }

        public async Task<bool> Remove(EventDataTransferModel model)
        {
            var eventToRemove = await this.All()
                .FirstOrDefaultAsync(
                    x => 
                        x.Description.Equals(model.Description) &&
                        x.Host.Equals(model.Host) &&
                        x.Country.Name.Equals(model.Country) &&
                        DateTime.Equals(x.StartDate, model.StartDate) &&
                        DateTime.Equals(x.EndDate, model.EndDate));

            var modelExistedInDatabase = false;
            var modelStillExists = false;

            if (eventToRemove != null)
            {
                modelExistedInDatabase = true;
                this.events.Delete(eventToRemove);
                await this.events.SaveChangesAsync();

                modelStillExists = await this.All().AnyAsync(s => s.Id == eventToRemove.Id);
            }

            return (modelExistedInDatabase && !modelStillExists);
        }

        public async Task<bool> RemoveById(int id)
        {
            var modelExistedInDatabase = await this.All().AnyAsync(s => s.Id == id);

            if (modelExistedInDatabase)
            {
                this.events.Delete(id);
                await this.events.SaveChangesAsync();
            }

            var modelStillExists = await this.All().AnyAsync(s => s.Id == id);

            return (!modelStillExists && modelExistedInDatabase);
        }
    }
}