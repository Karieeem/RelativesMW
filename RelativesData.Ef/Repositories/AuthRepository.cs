using RelativesData.Core.Models;
using RelativesData.Core.Repositories;
using RepoPattern2.Ef;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelativesData.Ef.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }
        public User Login(User user)
        {
           var result= _context.Users.Find(user.SapNumber);
            return result;
        }

        public User Register(User user)
        {
            var e=_context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
