using RestWithASPNet10.Data.DTO;

namespace RestWithASPNet10.Services
{
    public interface IPersonServices 
    {
        PersonDTO Create(PersonDTO person);
        PersonDTO FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO person);
        void Delete(long id);
    }
}
