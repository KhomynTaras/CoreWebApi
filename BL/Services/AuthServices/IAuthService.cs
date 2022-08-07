using BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.AuthServices
{
    public interface IAuthService
    {
        Task<string> SignIn(string login, string password);
        Task<Guid> SignUp(UserDto user);
    }
}
