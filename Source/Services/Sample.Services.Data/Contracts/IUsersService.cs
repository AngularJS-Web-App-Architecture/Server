namespace Sample.Services.Data.Contracts
{
    using System.Threading.Tasks;
    using Common.Contracts;
    using Server.DataTransferModels.Users;

    public interface IUsersService : IService
    {
        Task<UserDataTransferModel> GetById(string id);
    }
}