using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserAPI_Tanuka.Exceptions;

namespace UserAPI_Tanuka.AOP
{
    public class UserExceptionHandlerAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(DuplicateUserException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(UserNotFoundException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }
            
        }
    }
}
