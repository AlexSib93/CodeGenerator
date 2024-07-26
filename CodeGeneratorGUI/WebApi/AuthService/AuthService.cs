using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TerminalApi
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetIdUser()
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
