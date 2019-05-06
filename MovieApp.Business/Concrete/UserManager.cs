using MovieApp.Business.Abstract;
using MovieApp.Data.Abstract;
using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public User GetUserByEmail(string emailaddress)
        {
            return _userDal.Get(p => p.Email == emailaddress);
        }

        public User GetUserByLoginModel(LoginDto loginDto)
        {
            return _userDal.Get(p => p.Email == loginDto.Email && p.Password == loginDto.Password);
        }
    }
}
