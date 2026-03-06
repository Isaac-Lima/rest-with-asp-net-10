using Mapster;
using RestWithASPNet10.Data.DTO.V1;
using RestWithASPNet10.Model;
using RestWithASPNet10.Repositories;

namespace RestWithASPNet10.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        private readonly IRepository<Person> _repository;

        public PersonServicesImpl(IRepository<Person> repository)
        {
            _repository = repository;
        } 

        public List<PersonDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<PersonDTO>>();
        }

        public PersonDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<PersonDTO>();
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = person.Adapt<Person>();
            entity = _repository.Create(entity);

            return entity.Adapt<PersonDTO>();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PersonDTO Update(PersonDTO person)
        {
            var entity = person.Adapt<Person>();
            entity = _repository.Update(entity);

            return entity.Adapt<PersonDTO>();
        }
    }
}
