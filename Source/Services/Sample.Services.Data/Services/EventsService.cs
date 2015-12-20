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

    public class EventsService : IEventsService
    {
        private readonly IRepository<Event> events;

        public EventsService(IRepository<Event> events)
        {
            this.events = events;
        }

        public async Task<int> Add(EventDataTransferModel model)
        {
            var eventToAdd = Mapper.Map<Event>(model);

            this.events.Add(eventToAdd);
            await this.events.SaveChangesAsync();

            return eventToAdd.Id;
        }

        public IQueryable<Event> All()
        {
            return this.events.All();
        }

        public async Task<List<EventDataTransferModel>> GetAll()
        {
            var allEvents = await this.All().ProjectTo<EventDataTransferModel>().ToListAsync();

            return allEvents;
        }

        public async Task<EventDataTransferModel> GetById(int id)
        {
            var eventById = await this.All().SingleOrDefaultAsync(x => x.Id == id);
            var eventModel = Mapper.Map<EventDataTransferModel>(eventById);

            return eventModel;
        }

        public async Task<List<EventDataTransferModel>> GetPage(int page)
        {
            var eventsOnPage = await this.All()
                .Skip((page - 1) * ServicesConstants.ItemsPerPage)
                .Take(ServicesConstants.ItemsPerPage)
                .ProjectTo<EventDataTransferModel>()
                .ToListAsync();

            return eventsOnPage;
        }

        public async Task<bool> Remove(EventDataTransferModel model)
        {
            var eventToRemove = await this.All()
                .SingleOrDefaultAsync(
                    x => 
                        x.Description.Equals(model.Description) &&
                        x.Host.Equals(model.Host) &&
                        x.Country.Name.Equals(model.Country.Name) &&
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
