namespace People.Dto.Queries
{
    public class GetPersonByIdQuery
    {

        public GetPersonByIdQuery(int personid)
        {
            PersonId = personid;

        }

        public int PersonId { get; protected set; }
        

    
    }
}