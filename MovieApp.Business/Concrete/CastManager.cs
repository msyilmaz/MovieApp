using MovieApp.Business.Abstract;
using MovieApp.Data.Abstract;
using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Business.Concrete
{
    public class CastManager : ICastService
    {
        private readonly ICastDal _castDal;
        public CastManager(ICastDal castDal)
        {
            _castDal = castDal;
        }
        public void Add(CastDto castDto)
        {
            var cast = new Cast()
            {
                Id = castDto.Id,
                FullName = castDto.FullName,
                RoleName = castDto.RoleName,
                BirthDay = castDto.BirthDay
            };
            _castDal.Add(cast);
            _castDal.Save();
            
        }

        public void Delete(int Id)
        {
            var entity = _castDal.Get(p => p.Id == Id);

            _castDal.Delete(entity);
            _castDal.Save();
        }

        public CastDto GetCast(Expression<Func<Cast, bool>> condition)
        {
            var entity = _castDal.Get(condition);
            var result = new CastDto()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                RoleName = entity.RoleName,
                BirthDay = entity.BirthDay
            };

            return result;
        }

        public CastDto GetCastByRoleName(string RoleName)
        {
            var entity = _castDal.Get(p => p.RoleName == RoleName);
            var result = new CastDto()
            {
                FullName = entity.FullName
            };
            return result;
        }

        public List<CastDto> GetCasts(Expression<Func<Cast, bool>> condition)
        {
            var casts = _castDal.GetList(condition);

            var result = new List<CastDto>();

            foreach (var item in casts)
            {
                var castDto = new CastDto()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    RoleName = item.RoleName,
                    BirthDay = item.BirthDay

                };
                result.Add(castDto);
            }
            return result;
        }

        public void Update(CastDto castDto)
        {
            var entity = new Cast()
            {
               Id = castDto.Id,
               FullName = castDto.FullName,
               RoleName = castDto.RoleName,
               BirthDay = castDto.BirthDay
            };

            _castDal.Update(entity);
            _castDal.Save();
        }
    }
}
