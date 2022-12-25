namespace People.Dto.Commands
{
    public class DeletePersonCommand
    {
        protected DeletePersonCommand()
        {

        }
        public DeletePersonCommand(int personid)
        {
            PersonId = personid;
           
        }

        public int PersonId { get; protected set; }

    }
}
