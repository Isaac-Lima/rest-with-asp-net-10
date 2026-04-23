using RestWithASPNet10.Model;

namespace RestWithASPNet10.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
