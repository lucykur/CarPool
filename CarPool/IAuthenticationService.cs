using System;
using CarPool.Models;

namespace CarPool
{
    public interface IAuthenticationService
    {
        User Authenticate(string username, string password);
        User GetUserById(Guid identifier);
    }
}