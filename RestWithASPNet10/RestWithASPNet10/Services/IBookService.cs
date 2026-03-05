using RestWithASPNet10.Data.DTO;
using RestWithASPNet10.Model;

namespace RestWithASPNet10.Services
{
    public interface IBookService
    {
        BookDTO Create(BookDTO book);
        BookDTO FindById(long id);
        List<BookDTO> FindAll();
        BookDTO Update(BookDTO book);
        void Delete(long id);
    }
}
