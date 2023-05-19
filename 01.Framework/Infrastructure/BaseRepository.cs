using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace _01.Framework.Infrastructure
{
    public class BaseRepository<TKey, TValue> : IRepository<TKey, TValue> where TValue : BaseDomain<TKey>
    {
        private readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TValue entity)
        {
            _dbContext.Add<TValue>(entity);
        }

        public void Update(TValue entity)
        {
            _dbContext.Update<TValue>(entity);
        }

        public TValue GetBy(TKey key)
        {
            return _dbContext.Find<TValue>(key);
        }

        public List<TValue> GetAll()
        {
            return _dbContext.Set<TValue>().ToList();
        }

        public bool IsExist(Expression<Func<TValue, bool>> expression)
        {
            return _dbContext.Set<TValue>().Any(expression);
        }
    }
}
