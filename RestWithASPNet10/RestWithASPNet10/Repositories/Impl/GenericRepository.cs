using Microsoft.EntityFrameworkCore;
using RestWithASPNet10.Model.Base;
using RestWithASPNet10.Model.Context;

namespace RestWithASPNet10.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MSSQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.Find(id);

        }

        public T Create(T item)
        {
            _context.Add(item);
            _context.SaveChanges();

            return item;
        }

        public void Delete(long id)
        {
            var item = _dataset.Find(id);

            if (item == null)
            {
                return;
            }

            _context.Remove(item);
            _context.SaveChanges();
        }

        public T Update(T item)
        {
            var existingItem = _dataset.Find(item.Id);

            if (existingItem == null)
            {
                return null;
            }

            _context.Entry(existingItem).CurrentValues.SetValues(item);
            _context.SaveChanges();

            return item;
        }

        public bool Exists(long id)
        {
            return _dataset.Any(e => e.Id == id);   
        }
        
    }
}
