using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services.Interfaces;

namespace P7CreateRestApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(int id)
        {
            ApplicationUser user = await _userRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"L'utilisateur {id} n'existe pas");

            return user;
        }

        public async Task CreateUserAsync(ApplicationUser user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
        {
            if (!int.TryParse(user.Id, out int userId))
            {
                throw new ArgumentException($"L'ID utilisateur '{user.Id}' n'est pas un entier valide.");
            }

            ApplicationUser existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null) return null;

            existingUser.Fullname = user.Fullname;
            existingUser.Email = user.Email;

            await _userRepository.UpdateAsync(existingUser);

            return user;
        }

        public async Task DeleteUserAsync(int id)
        {
            ApplicationUser user = await _userRepository.GetByIdAsync(id)
                    ?? throw new KeyNotFoundException($"L'utilisateur {id} n'existe pas");

            await _userRepository.DeleteAsync(id);
        }
    }

}
