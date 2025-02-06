using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace P7CreateRestApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser FindByUserName(string userName);
        Task<List<ApplicationUser>> FindAll();
        void Add(ApplicationUser user);
        ApplicationUser FindById(int id);
    }
}
