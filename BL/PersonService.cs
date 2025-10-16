using Dapper;
using Web_Datenbank1_LK.DAL;
using Web_Datenbank1_LK.IndexViewModels;
using Web_Datenbank1_LK.Models;


namespace Web_Datenbank1_LK.BL
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }
        public Person Add(Person person)
        {
         return  _personRepository.Insert(person);
        }

        public Person Changed(Person person)
        {
           return _personRepository.Update(person);
        }

              public List<Person> ReadAllPerson()
        {
            return _personRepository.GetAllPerson();
        }

        
       public List<Person> FetchUsersWhoseBirthdayIsInTheNext3Month()
        {
            List<Person> allPersons = _personRepository.GetAllPerson();

            DateTime today = DateTime.Today;
            DateTime month = today.AddDays(91);
            List<Person> personList = new List<Person>();

            foreach (var person in allPersons)
            {
                if (person.BirthDate == null) continue;

                DateTime nextBirthday = new DateTime(today.Year, person.BirthDate.Value.Month, person.BirthDate.Value.Day);
               
                if (nextBirthday < today)
                {
                    nextBirthday = nextBirthday.AddYears(1);
                }

                if (nextBirthday <= month)
                {
                    personList.Add(person);
                }
            }

            return personList;
        }

        public Person ReadPersonById(Guid id)
        {
            return _personRepository.GetPersonById(id);
        }

        public bool Remove(Guid id)
        {
          return  _personRepository.Delete(id);
        }

        public IndexViewModel GetIndexViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
