namespace UserAPI_Tanuka.Exceptions
{
    public class UserNotFoundException: ApplicationException
    {
        public UserNotFoundException()
        {
            
        }
        public UserNotFoundException(string message) : base(message) { }
    }
}
