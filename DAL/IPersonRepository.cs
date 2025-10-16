using Web_Datenbank1_LK.Models;

namespace Web_Datenbank1_LK.DAL
{
    public interface IPersonRepository 
    {
        List<Person> GetAllPerson();
        Person GetPersonById(Guid id);
        Person Insert(Person person);
        Person Update(Person person);
        bool Delete(Guid id);

   

    }
}
