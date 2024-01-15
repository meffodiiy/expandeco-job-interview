

using System;
using System.Security.Claims;

namespace Expandeco.JobInterview.Services
{
    public class LoggedUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
    }
    
    public interface ILoggedUserService
    {
        LoggedUser Get();
    }

    public class LoggedUserService : ILoggedUserService
    {
        private ClaimsPrincipal _user;

        public LoggedUserService(ClaimsPrincipal user)
        {
            _user = user;
        }

        public LoggedUser Get()
        {
            if (_user == null)
                return null;

            return new LoggedUser
            {
                Id = Convert.ToInt32(_user.FindFirstValue(ClaimTypes.PrimarySid)),
                Name = _user.Identity.Name,
                TypeId = Convert.ToInt32(_user.FindFirstValue(ClaimTypes.Role))
            };
        }
    }
}
