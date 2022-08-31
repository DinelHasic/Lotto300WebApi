using Loto300WebApi.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebAPI.Storage.Repository
{
    public abstract class ReposiotyBase<T> where T : BaseEntity
    {
        protected readonly ILottoDbContextcs _lottoDbContext;

        protected ReposiotyBase(ILottoDbContextcs lottoDbContextcs)
        {
            _lottoDbContext = lottoDbContextcs;
        }

        protected IQueryable<T> GetById(int id)
        {
            return _lottoDbContext.Set<T>().Where(x => x.Id == id);
        }

        protected IQueryable<T> GetAll()
        {
            return _lottoDbContext.Set<T>();
        }

        protected void InsterEntity(T item)
        {
            _lottoDbContext.Set<T>().Add(item);
        }

        protected void RemoveEntity(T item)
        {
            _lottoDbContext.Set<T>().Remove(item);
        }
    }
}
