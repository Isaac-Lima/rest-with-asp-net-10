using RestWithASPNet10.Data.Converter.Impl;
using RestWithASPNet10.Data.DTO.V1;
using RestWithASPNet10.Model;
using RestWithASPNet10.Model.Context;
using RestWithASPNet10.Repositories;

namespace RestWithASPNet10.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonServicesImpl(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        } 

        public List<PersonDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Create(entity);

            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PersonDTO Update(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Update(entity);

            return _converter.Parse(entity);
        }
    }
}
