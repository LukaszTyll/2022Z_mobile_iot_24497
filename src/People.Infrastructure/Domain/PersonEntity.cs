using System;

namespace People.Infrastructure.Domain
{
    public class PersonEntity
    {
 
        public static PersonEntity Create(string firstname, string lastname)
        {
            var entity = new PersonEntity
            {
                FirstName = firstname,
                LastName = lastname
            };
            return entity;
        }

        public void UpdateLastName(string lastname)
        {
            LastName = lastname;
        }

        public int PersonId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
    }
}
