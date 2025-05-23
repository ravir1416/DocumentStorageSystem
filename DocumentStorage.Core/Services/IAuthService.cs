using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStorage.Core.Services
{
    public interface IAuthService
    {
        string Register(string username, string password);
        string Login(string username, string password);
    }
}
