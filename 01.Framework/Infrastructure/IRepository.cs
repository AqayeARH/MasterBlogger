using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _01.Framework.Domain;

namespace _01.Framework.Infrastructure
{
    public interface IRepository<in TKey, TValue> where TValue : BaseDomain<TKey>
    {
        void Create(TValue entity);
        void Update(TValue entity);
        TValue GetBy(TKey key);
        List<TValue> GetAll();
        bool IsExist(Expression<Func<TValue, bool>> expression);
    }
}
