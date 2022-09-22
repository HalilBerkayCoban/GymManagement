using GymManagement.Application.Interfaces.Paging;
using GymManagement.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IRepository<T> : IQuery<T> where T : BaseEntity
    {
        T Get(Expression<Func<T, bool>> predicate);
        IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
                         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                         Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                         int index = 0, int size = 10,
                         bool enableTracking = true);

        IPaginate<T> GetListByDynamic(Dynamic.Dynamic dynamic,
                                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                      int index = 0, int size = 10, bool enableTracking = true);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
