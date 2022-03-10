using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleApp1.Data.Utils
{
    // Bünyesinde T Tipinde objeler tutan bir liste barındırır. Bu liste üzerinde CRUD operasyonların olabileceğini
    // belirten soyut class
    public abstract class Table<T>
    {
        protected List<T> Entities { get; }

        public Table(List<T> entities)
        {
            Entities = entities;
        }

        public abstract void Add(T input);
        public abstract void Remove(T input);
        public abstract void Update(T input);
        public abstract T Get(Expression<Func<T, bool>> predicate);
        public abstract List<T> GetList(Expression<Func<T, bool>> predicate = null);
    }
}