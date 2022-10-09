using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GymManagement.Infrastructure.Authentication.Exceptions
{
    public class AuthorizationProblemDetails : ProblemDetails
    {
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
