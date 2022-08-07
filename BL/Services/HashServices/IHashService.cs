using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.HashServices
{
    public interface IHashService
    {
        string HashString(string source);
    }
}
