using System;

namespace People.Infrastructure.Domain
{
    public class PersonLastNameEntity
    {
 
        public static PersonLastNameEntity Create(string firstname, string lastname)
        {
            var entity = new PersonLastNameEntity
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
