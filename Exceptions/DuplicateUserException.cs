namespace UserAPI_Tanuka.Exceptions
{
    public class DuplicateUserException: ApplicationException
    {
        public DuplicateUserException()
        {
            
        }

        public DuplicateUserException(string message) : base(message) { }
    }
}
