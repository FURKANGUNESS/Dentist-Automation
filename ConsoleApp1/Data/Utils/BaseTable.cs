using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ConsoleApp1.Entities.Abstract;

namespace ConsoleApp1.Data.Utils
{
    // Table<T> tipini kalıtım alır ve Table<T> içerisinde yer alan CRUD operasyonların gövdeleri generic
    // bir şekilde tanımlanır.
    public abstract class BaseTable<T> : Table<T>
        where T: Entity
    {
        public BaseTable(List<T> entities) : base(entities)
        {
        }

        public override void Add(T input)
        {
            input.Id = Storage.GetId().Value;
            Entities.Add(input);
        }

        public override void Remove(T input)
        {
            Entities.Remove(input);
        }

        public override void Update(T input)
        {
            var entity = Entities.FirstOrDefault(x => x.Id == input.Id);

            if (entity == null)
            {
                Console.WriteLine($"{input.Id} id'li Doctor bulunamadı.");
            }

            Entities.Remove(entity);
            Entities.Add(input);
        }

        public override T Get(Expression<Func<T, bool>> predicate)
        {
            return Entities.FirstOrDefault(predicate.Compile());
        }

        public override List<T> GetList(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return Entities;
            }
            return Entities.Where(predicate.Compile()).ToList();
        }
    }
}