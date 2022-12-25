namespace People.Dto.Commands
{
    public class UpdatePersonCommand
    {
        protected UpdatePersonCommand()
        {

        }
        public UpdatePersonCommand(int personid,string firstname, string lastname)
        {
            PersonId = personid;
            FirstName = firstname;
            LastName = lastname;
        }

        public int PersonId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
    }
}
