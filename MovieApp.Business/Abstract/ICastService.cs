using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Business.Abstract
{
    public interface ICastService
    {
        List<CastDto> GetCasts(Expression<Func<Cast, bool>> condition);
        CastDto GetCast(Expression<Func<Cast, bool>> condition);

        void Add(CastDto castDto);
        void Delete(int Id);
        void Update(CastDto castDto);

        CastDto GetCastByRoleName(string RoleName);

    }
}
