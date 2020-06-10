using ArtSofteStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSofteStaff
{
    public interface IUserService
    {
        Task<Person> Authenticate(string username, string password);
        Task<IEnumerable<Person>> GetAll();
    }

    public class AuthService : IUserService
    {
        private List<Person> _persons = new List<Person>
        { new Person { ID = 1, Login = "test", Password = "test" }
        };


        public async Task<Person> Authenticate(string username, string password)
        {
            var person = await Task.Run(() => _persons.SingleOrDefault(x => x.Login == username && x.Password == password));

            
            if (person == null)
                return null;

           
            return person;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await Task.Run(() => _persons);
        }
    }
}
