namespace Sample.Services.Data.Services
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Sample.Data.Models.Models;
    using Sample.Data.Contracts;
    using Server.DataTransferModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public async Task<UserDataTransferModel> GetById(string id)
        {
            var user = await this.users.All().Where(u => u.Id == id)
                .Select(u => new UserDataTransferModel
                {
                    DisplayName = u.DisplayName,
                    Email = u.Email
                })
                .FirstOrDefaultAsync();

            return user;
        }
    }
}