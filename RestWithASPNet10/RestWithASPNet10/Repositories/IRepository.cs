using RestWithASPNet10.Model;
using RestWithASPNet10.Model.Base;

namespace RestWithASPNet10.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);

        bool Exists(long id); 
    }
}
