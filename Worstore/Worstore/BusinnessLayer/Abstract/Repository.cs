using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Worstore.AccessLayer.Entity;
using Worstore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Worstore.Entities;
using Worstore.Services;

namespace Worstore.BusinnessLayer.Abstract
{
    public class Repository<T> : IRepository<T> where T : class
    {
   
        private DatabaseContext _dbContext ;

        private DbSet<T> _objectSet;

        
        public Repository(DatabaseContext dbContext, UserResolverService manager)
        {
            _dbContext = dbContext;

            _objectSet = _dbContext.Set<T>();
        }


        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public IQueryable<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where);
        }
        public int Save()
        {
            return _dbContext.SaveChanges();
        }
        public int Insert(T obj)
        {
             _objectSet.Add(obj);
            return Save();
        }
        public int Update(T obj)
        {
            return Save();
        }        
        public int Delete(T obj)
        {
             _objectSet.Remove(obj);
            return Save();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }       
        public T GetById(int Id)
        {
            return _objectSet.Find(Id);
        }
    } 
}
