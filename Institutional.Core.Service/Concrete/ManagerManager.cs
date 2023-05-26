using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
using System.Security.Claims;
namespace Institutional.Core.Service.Concrete
{
    public class ManagerManager : IManagerService
    {
        private readonly IManagerRepository _ManagerRepository;

        public ManagerManager(IManagerRepository ManagerRepository)
        {
            _ManagerRepository = ManagerRepository;
        }

        public async Task DeleteAsync(Manager t)
        {
            await _ManagerRepository.DeleteAsync(t);
        }

        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _ManagerRepository.GetByIdAsync(id);
        }

        public async Task<Manager> GetByNameAsync(string userName)
        {
            return await _ManagerRepository.GetByNameAsync(userName);
        }

        public async Task InsertAsync(Manager t)
        {
            await _ManagerRepository.InsertAsync(t);
        }

        public async Task<Manager> SignInAsync(Manager manager)
        {
            var user = await _ManagerRepository.SignInAsync(manager);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<ClaimsPrincipal> SignInWithClaimAsync(Manager manager)
        {
            var user = await SignInAsync(manager);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
            var userIdentity = new ClaimsIdentity(claims, "SignIn");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
            return claimsPrincipal;
        }

        public async Task<List<Manager>> ToListAsync()
        {
            return await _ManagerRepository.ToListAsync();
        }

        public async Task<List<Manager>> ToListByFilterAsync()
        {
            return await _ManagerRepository.ToListByFilterAsync(b => b.Status == true);
        }

        public async Task UpdateAsync(Manager t)
        {
            await _ManagerRepository.UpdateAsync(t);
        }
    }
}
