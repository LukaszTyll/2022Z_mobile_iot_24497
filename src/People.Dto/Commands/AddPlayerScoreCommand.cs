namespace People.Dto.Commands
{
    public class AddPersonLastNameCommand
    {
        protected AddPersonLastNameCommand()
        {

        }
        public AddPersonLastNameCommand(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
    }
}
