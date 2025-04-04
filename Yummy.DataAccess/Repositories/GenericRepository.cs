﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;

namespace Yummy.DataAccess.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly YummyContext _context;

        public GenericRepository(YummyContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }

        public int Count()
        {
            return Table.Count();
        }

        public void Create(T entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            Table.Remove(entity);
            _context.SaveChanges();
        }

        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).Count();
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).FirstOrDefault();
        }

        public T GetByID(int id)
        {
            return Table.Find(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public List<T> GetList()
        {
            return Table.ToList();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
            _context.SaveChanges();
        }
    }
}