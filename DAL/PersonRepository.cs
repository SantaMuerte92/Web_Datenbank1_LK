using Web_Datenbank1_LK.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;


namespace Web_Datenbank1_LK.DAL
{
    public class PersonRepository : IPersonRepository


    {


      
    private readonly string connString;

        public PersonRepository(IConfiguration configuration)
        {
            connString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Delete(Guid id)
        {
            using (var connection = new SqlConnection(connString))
            {
                var sqlQuery = @"
                                DELETE FROM [dbo].[Person]
                                WHERE PID = @PID;";

                var parameters = new
                {
                    PID = id 
                };

                connection.Open(); 
                var rowsAffected = connection.Execute(sqlQuery, parameters);

                return rowsAffected > 0; 
            }
        }

        public List<Person> GetAllPerson()
        {
            using (var connection = new SqlConnection(connString))
            {
                return connection.Query<Person>("SELECT * FROM Person").ToList();
            }
        }

        public Person GetPersonById(Guid id)
        {
            
            using (var connection = new SqlConnection(connString))

                       {
                var sqlQuery = @"
                                SELECT * 
                                FROM [dbo].[Person]
                                WHERE PID = @PID;"; 

                var parameters = new
                {
                    PID = id
                };

                connection.Open();
                var person = connection.QuerySingleOrDefault<Person>(sqlQuery, parameters);
                return person; 
            }
        }

        public Person Insert(Person person)
        {
            using (var connection = new SqlConnection(connString))
            {
                var sql = "INSERT INTO Person (FirstName, LastName, Birthdate, BodySize, BodyWeight, PersonImage) " +
                          "VALUES (@FirstName, @LastName, @Birthdate, @BodySize, @BodyWeight, @PersonImage);" +
                          "SELECT CAST(SCOPE_IDENTITY() as int)";


                var parameters = new
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Birthdate = person.BirthDate,
                    BodySize = person.BodySize,
                    BodyWeight = person.BodyWeight,
                    PersonImage = person.PersonImage
                };
                connection.Open();
                var newPerson = connection.QuerySingle<Person>(sql, parameters);
                return newPerson;
            }
        }
        public Person Update(Person person)
        {
            using (var connection = new SqlConnection(connString))
            {
                var sqlQuery = @"
                                UPDATE [dbo].[Person]
                                SET 
                                    FirstName = @FirstName,
                                    LastName = @LastName,
                                    Birthdate = @Birthdate,
                                    BodySize = @BodySize,
                                    BodyWeight = @BodyWeight,
                                    PersonImage = @PersonImage
                                OUTPUT INSERTED.*
                                WHERE PID = @PID;"; 

                var parameters = new
                {
                    PID = person.PID, 
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Birthdate = person.BirthDate,
                    BodySize = person.BodySize,
                    BodyWeight = person.BodyWeight,
                    PersonImage = person.PersonImage
                };

                connection.Open();
                var updatedPerson = connection.QuerySingle<Person>(sqlQuery, parameters);
                return updatedPerson;
            }
        }
    }
}
