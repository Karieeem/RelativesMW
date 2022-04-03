using RelativesData.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelativesData.Core.Repositories
{
    public interface IAuthRepository
    {
        User Login(User user);
        User Register(User user);
    }
}
