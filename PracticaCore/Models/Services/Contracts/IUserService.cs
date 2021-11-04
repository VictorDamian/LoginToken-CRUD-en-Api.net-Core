using PracticaCore.Models.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Models.Services.Contracts
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
