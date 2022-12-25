namespace People.Dto.Commands
{
    public class AddPersonCommand
    {
        protected AddPersonCommand()
        {

        }
        public AddPersonCommand(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
    }
}
