using MovieApp.Core.Data;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
