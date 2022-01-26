using BlogProject.Infrastructure.Context;
using BlogProject.Infrastructure.Repositories.Interfaces.BaseRepository;
using BlogProject.Model.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _table;

        public BaseRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
            this._table = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _table.Add(entity); // _database.Categories.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public TResult GetByDefault<TResult>(Expression<Func<T, TResult>> selector,
                                             Expression<Func<T, bool>> expression, 
                                             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;

            if (include != null)
            {
                query = include(query);
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query.Select(selector).FirstOrDefault();
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                                    Expression<Func<T, bool>> expression,
                                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            IQueryable<T> query = _table;

            if (include != null)
            {
                query = include(query);
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderby != null)
            {
                return orderby(query).Select(selector).ToList();
            }
            else
            {
                return query.Select(selector).ToList();
            }
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _table.Any(expression);
        }
    }
}
