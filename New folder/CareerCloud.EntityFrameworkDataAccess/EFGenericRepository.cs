using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private CareerCloudContext _context;

        public EFGenericRepository(bool createProxy=true)
        {
            _context = new CareerCloudContext(createProxy);
        }
        public void Add(params T[] items)
        {
            foreach (var item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbquery = _context.Set<T>();
            foreach (var item in navigationProperties)
            {
                dbquery = dbquery.Include<T, object>(item);
            }
            return dbquery.AsNoTracking().ToList<T>();
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbquery = _context.Set<T>();
            foreach (Expression<Func<T, object>> item in navigationProperties)
            {
                dbquery = dbquery.Include<T, object>(item);
            }
            return dbquery.AsNoTracking().Where(where).ToList<T>();
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbquery = _context.Set<T>();
            foreach (Expression<Func<T, object>> item in navigationProperties)
            {
                dbquery = dbquery.Include<T, object>(item);
            }
            return dbquery.AsNoTracking().FirstOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            foreach (var item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (var item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }

}
