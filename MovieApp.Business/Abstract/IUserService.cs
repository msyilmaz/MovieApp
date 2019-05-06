using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Abstract
{
    public interface IUserService
    {
        User GetUserByEmail(string emailaddress);
        User GetUserByLoginModel(LoginDto loginDto);
    }
}
