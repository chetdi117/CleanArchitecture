using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Authorization
{
    public interface ISecurityContextAccessor
    {
        string UserName { get; }
        string Email { get; }
        string Role { get; }
        string JwtToken { get; }
        string IPAddressClient { get; }
        bool IsAuthenticated { get; }
    }
}
