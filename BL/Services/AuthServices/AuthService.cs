using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Auth;

namespace BL.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IGerericRepository<User> _genericClientRepository;
        private readonly IGerericRepository<Role> _genericRoleRepository;

        public AuthService(IGerericRepository<User> genericClientRepository, IGerericRepository<Role> genericRoleRepository)
        {
            _genericClientRepository = genericClientRepository;
            _genericRoleRepository = genericRoleRepository;
        }

        public async Task<string> SignIn(string login, string password)
        {
            var user = await _genericClientRepository.GetByPredicate(x => x.Email == login && x.Password == password);

            if (user == null)
            {
                throw new ArgumentException();
            }

            var role = user.RoleId.HasValue ? (await _genericRoleRepository.GetById(user.RoleId.Value)).Name : Roles.Reader;

            return TokenGenerator.GenerateToken(user.Email, role);
        }
    }
}
