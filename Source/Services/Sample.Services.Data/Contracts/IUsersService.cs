namespace Sample.Services.Data.Contracts
{
    using System.Threading.Tasks;
    using Common.Contracts;
    using Server.DataTransferModels.Users;
    using Microsoft.AspNet.Identity;

    public interface IUsersService : IService
    {
        Task<UserDataTransferModel> GetById(string id);
    }
}