using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TerminalApi
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetIdPeople()
        {
            int res = 0;
            if(_httpContextAccessor.HttpContext != null)
            {
                string resStr = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if(!string.IsNullOrEmpty(resStr))
                {
                    res = int.Parse(resStr);
                }
            }

            return res;
        }
    }
}
