using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace P7CreateRestApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User FindByUserName(string userName);
        Task<List<User>> FindAll();
        void Add(User user);
        User FindById(int id);
    }
}
