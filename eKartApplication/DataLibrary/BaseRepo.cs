using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        private readonly AppDBContext _context;

        public BaseRepo(AppDBContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Add(obj);
            _context.SaveChangesAsync();
        }

        public void Delete(T obj)
        {
            _context.Remove(obj);
            _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Set<T>().Any(e => e.ID == id);
        }

        public T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(m => m.ID == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            _context.Update(obj);
            _context.SaveChangesAsync();
        }
    }
}
