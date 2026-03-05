using Mapster;
using RestWithASPNet10.Data.DTO;
using RestWithASPNet10.Model;
using RestWithASPNet10.Repositories;
using RestWithASPNet10.Repositories.Impl;

namespace RestWithASPNet10.Services.Impl
{
    public class BookServiceImpl : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookServiceImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }


        public BookDTO Create(BookDTO book)
        {
            var entity = book.Adapt<Book>();
            entity = _repository.Create(entity);

            return entity.Adapt<BookDTO>();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<BookDTO>>();
        }

        public BookDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BookDTO>();
        }

        public BookDTO Update(BookDTO book)
        {
            var entity = book.Adapt<Book>();
            entity = _repository.Update(entity);

            return entity.Adapt<BookDTO>();
        }
    }
}
