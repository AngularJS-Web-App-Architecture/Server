namespace Sample.Services.Data.Contracts
{
    using Common.Contracts;
    using Sample.Data.Models.Models;
    using Server.DataTransferModels.Events;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IEventsService : IService
    {
        IQueryable<Event> All();

        Task<List<EventDataTransferModel>> GetAll();

        Task<EventDataTransferModel> GetById(int id);

        Task<List<EventDataTransferModel>> GetByPage(int page);

        Task<int> Add(EventDataTransferModel model);

        Task<bool> Remove(EventDataTransferModel model);

        Task<bool> RemoveById(int id);
    }
}