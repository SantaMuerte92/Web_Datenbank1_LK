using Web_Datenbank1_LK.Models;
using Web_Datenbank1_LK.IndexViewModels;

namespace Web_Datenbank1_LK.BL

{
    public interface IPersonService
    {
        List<Person> ReadAllPerson();
        Person ReadPersonById(Guid id);
        Person Add(Person person);
        Person Changed(Person person);
        bool Remove(Guid id);
        List<Person> FetchUsersWhoseBirthdayIsInTheNext3Month();

        IndexViewModel GetIndexViewModel();





    }
}
